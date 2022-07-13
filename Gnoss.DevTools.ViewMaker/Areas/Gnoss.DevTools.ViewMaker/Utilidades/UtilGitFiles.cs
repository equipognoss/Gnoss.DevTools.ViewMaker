using System;
using System.IO;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System.Net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades
{
    public class UtilGitFiles
    {
        [ThreadStatic]
        private static CredentialsHandler mCredential;

        private static CredentialsHandler Credential
        {
            get
            {
                if (mCredential == null)
                {
                    string rootUser = UtilConfiguration.GetConfiguration("usuarioRootRepositorio/user");
                    string rootPassword = UtilConfiguration.GetConfiguration("usuarioRootRepositorio/password");

                    mCredential = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = rootUser, Password = rootPassword };
                }
                return mCredential;
            }
        }

        internal static string[] ObtenerProyectosVistas()
        {
           // return Directory.GetDirectories(AppContext.BaseDirectory + "Views");
            return Directory.GetDirectories(AppContext.GetData("rutaBase") + "Views");
        }

        internal static string ObrenerRamaRepositorioLocal(string proyecto)
        {
            string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";
            try
            {
                using (var repo = new Repository(rutaDirectorio))
                {
                    return repo.Head.FriendlyName;
                }
            }
            catch (RepositoryNotFoundException ex)
            {
                return null;
            }
        }

        private static string GetProyectRepository(string proyecto)
        {
             //Pedirselo al api de integracioncontinua

            string urlRepo = UtilConfiguration.GetConfiguration("urlApiIntegracionEntornos");

            string peticion = urlRepo + $"/config/urlrepo?pNombreCorto={proyecto}";
            byte[] byteData = Encoding.UTF8.GetBytes("");
            string urlEnvironment = JsonConvert.DeserializeObject<string>(WebRequest("POST", peticion, byteData));

            return urlEnvironment;
        }

       
        private static string GetActualBranchRepository(string proyecto)
        {
            //Pedirselo al api de integracioncontinua

            string urlRepo = UtilConfiguration.GetConfiguration("urlApiIntegracionEntornos");

            string peticion = urlRepo + $"/config/rama?pNombreCorto={proyecto}";
            byte[] byteData = Encoding.UTF8.GetBytes("");
            string ramaActual = JsonConvert.DeserializeObject<string>(WebRequest("POST", peticion, byteData));

            return ramaActual;
        }

        public static string WebRequest(string httpMethod, string url, byte[] byteData)
        {
            HttpWebRequest webRequest = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = httpMethod;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 600000;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            if (httpMethod == "POST")
            {
                webRequest.ContentLength = 0;

                if (byteData != null)
                {
                    webRequest.ContentLength = byteData.Length;

                    Stream dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteData, 0, byteData.Length);
                    dataStream.Close();
                }
            }
            try
            {
                responseData = WebResponseGet(webRequest);
            }
            catch (WebException ex)
            {
                string message = url;
                try
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                    message += "\r\nError: " + sr.ReadToEnd();
                }
                catch { }

                // Error reading the error response, throw the original exception
                throw new Exception(message, ex);
            }

            webRequest = null;

            return responseData;
        }

        /// <summary>
        /// Make a http get request
        /// </summary>
        /// <param name="pWebRequest">HttpWebRequest object</param>
        /// <returns>Server response</returns>
        private static string WebResponseGet(HttpWebRequest pWebRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(pWebRequest.GetResponse().GetResponseStream(), Encoding.UTF8);
                responseData = responseReader.ReadToEnd();
            }
            finally
            {
                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }
            }
            return responseData;
        }

        internal static void DescargarVistasInicial(string proyecto)
        {
            string repositorio = GetProyectRepository(proyecto);
            string ramaActual = GetActualBranchRepository(proyecto);
            if (!string.IsNullOrEmpty(ramaActual))
            {
                string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";

                Directory.CreateDirectory(rutaDirectorio);

                ForkRespositorio(new Uri(repositorio), rutaDirectorio, ramaActual);
            }
        }

        internal static void DescargarVistas(string proyecto)
        {
            string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";

            using (var repo = new Repository(rutaDirectorio))
            {
                try
                {
                    // Comprobar que la rama actual es la última
                     string ramaActual = GetActualBranchRepository(proyecto);
                     Branch rama = FindBranch(ramaActual, repo);

                    var fetchOptions = new FetchOptions()
                    {
                        CredentialsProvider = Credential
                    };

                    PullOptions options = new PullOptions();
                    options.FetchOptions = fetchOptions;
                    var signature = new LibGit2Sharp.Signature(
                    new Identity("MERGE_USER_NAME", "MERGE_USER_EMAIL"), DateTimeOffset.Now);

                    MergeResult merge = Commands.Pull(repo, signature, options);
                }
                catch(Exception ex)
                {
                    //repo.Info.WorkingDirectory
                }
            }
        }

        internal static void ActualizarUltimaRama(string proyecto)
        {
            string ramaActual = GetActualBranchRepository(proyecto);

            string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";

            using (var repo = new Repository(rutaDirectorio))
            {
                Branch rama = FindBranch(ramaActual, repo);

                if (rama == null)
                {
                    // Let's get a reference on the remote tracking branch...
                    string trackedBranchName = "origin/" + ramaActual;
                    Branch trackedBranch = repo.Branches[trackedBranchName];

                    // ...and create a local branch pointing at the same Commit
                    Branch branch = repo.CreateBranch(ramaActual, trackedBranch.Tip);


                    // So, let's configure the local branch to track the remote one.
                    rama = repo.Branches.Update(branch,
                        b => b.TrackedBranch = trackedBranch.CanonicalName);
                }

                CheckoutOptions option = new CheckoutOptions();
                option.CheckoutModifiers = CheckoutModifiers.None;

                Commands.Checkout(repo, rama, option);
                repo.Index.Write();
            }
        }
        
        private static void ForkRespositorio(Uri pURL, string pPathDirectorio, string pNombreRama)
        {
            CloneOptions option = new CloneOptions();
            if (!string.IsNullOrEmpty(pNombreRama))
            {
                option.BranchName = pNombreRama;
            }
            option.CredentialsProvider = Credential;

            Repository.Clone(pURL.ToString(), pPathDirectorio, option);
        }

        private static Branch FindBranch(string pBranchName, Repository pRepo)
        {
            return pRepo.Branches.FirstOrDefault(x => x.FriendlyName == pBranchName);
        }

        internal static Dictionary<string, FileStatus> GetFilesWithChanges(string proyecto)
        {
            Dictionary<string, FileStatus> cambios = new Dictionary<string, FileStatus>();

            string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";

            using (var repo = new Repository(rutaDirectorio))
            {
                RepositoryStatus status = repo.RetrieveStatus();

                foreach (var item in status)
                {
                    cambios.Add(item.FilePath, item.State);
                }
            }
            return cambios;
        }

        internal static bool CheckServerChanges(string proyecto)
        {
            string ramaActual = GetActualBranchRepository(proyecto);

            string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyecto}";

            using (var repo = new Repository(rutaDirectorio))
            {
                var fetchOptions = new FetchOptions()
                {
                    CredentialsProvider = Credential
                };

                string logMessage = "";
                var remote = repo.Network.Remotes["origin"];
                IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                Commands.Fetch(repo, "origin", refSpecs, fetchOptions, logMessage);

                Branch rama = FindBranch(ramaActual, repo);
                return rama == null || rama.TrackingDetails.BehindBy > 0;
            }
        }

        internal static bool CheckBranchChange(string proyecto)
        {
            string ramaRepositorio = GetActualBranchRepository(proyecto);

            string ramaLocal = ObrenerRamaRepositorioLocal(proyecto);

            return !ramaRepositorio.Equals(ramaLocal);
        }
        
    }
}