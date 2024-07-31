using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using System.IO.Compression;
using Es.Riam.Gnoss.Web.MVC.Models;
using Es.Riam.Gnoss.Web.MVC.Models.ViewModels;
using Es.Riam.Semantica;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Controllers
{
    [JsonObject(MemberSerialization.OptIn)]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private const string TYPE_JSON = "$type\":\"";

        [Route("/")]
        [Route("/home")]
        public ActionResult Index()
        {


            List<string> lastURLs = UtilConfiguration.GetAutocompleteData("url");
            lastURLs.Reverse();

            ViewBag.LastURLs = lastURLs;
            ViewBag.LastSessionID = UtilConfiguration.GetAutocompleteData("sessionID");
            ViewBag.Session = HttpContext;
            return View("/Areas/Gnoss.DevTools.ViewMaker/Views/Home/Index.cshtml");
        }
        [Route("/LoadURL")]
        public ActionResult LoadURL(string url, string submit, string sessionID, string user, string password, bool contentLocal)
        {
            try
            {
                GestionarDatosSession(url, ref user, ref password);

                if (sessionID != "")
                {
                    UtilConfiguration.SetAutocompleteData("Session", sessionID);
                }

                List<string> urlsAutocomplete = UtilConfiguration.GetAutocompleteData("url");
                if (urlsAutocomplete.Contains(url))
                {
                    urlsAutocomplete.Remove(url);
                }
                else if (urlsAutocomplete.Count > 5)
                {
                    urlsAutocomplete.RemoveAt(0);
                }
                urlsAutocomplete.Add(url);

                UtilConfiguration.SetAutocompleteData("url", urlsAutocomplete);
                ViewBag.Session = HttpContext;
            }
            catch
            {
                return View("/Areas/Gnoss.DevTools.ViewMaker/Views/Home/Error.cshtml");


            }

            string responseFromServer = null;
            string jsonModel = null;

            if (!string.IsNullOrEmpty(url))
            {
                responseFromServer = GetData(url, submit, sessionID, user, password);
            }

            string proyectoSeleccionado;

            if (string.IsNullOrEmpty(responseFromServer))
            {
                return View("/Areas/Gnoss.DevTools.ViewMaker/Views/Home/Error.cshtml");
            }
            else
            {
                jsonModel = GetJson(responseFromServer, contentLocal, out proyectoSeleccionado);
            }

            string[] proyectos = UtilGitFiles.ObtenerProyectosVistas();
            string urlRepo = UtilConfiguration.GetConfiguration("urlApiIntegracionEntornos");
            //if (!proyectos.Contains(AppContext.BaseDirectory + "Views\\ecosistema"))
            if (!proyectos.Contains(AppContext.GetData("rutaBase") + "Views\\ecosistema"))
            {
                if (!string.IsNullOrEmpty(urlRepo))
                {
                    UtilGitFiles.DescargarVistasInicial("ecosistema");
                }
                else
                {
                    //Creamos la estructura de carpetas que tendrian las vistas en local
                    //string rutaDirectorio = $"{AppContext.BaseDirectory}Views/ecosistema";
                    string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/ecosistema";
                    Directory.CreateDirectory(rutaDirectorio);
                    //rutaDirectorio = $"{AppContext.BaseDirectory}Views/ecosistema/Vistas";
                    rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/ecosistema/Vistas";
                    Directory.CreateDirectory(rutaDirectorio);
                }

            }
            if (!proyectos.Contains(AppContext.GetData("rutaBase") + "Views\\" + proyectoSeleccionado))
            {
                if (!string.IsNullOrEmpty(urlRepo))
                {
                    UtilGitFiles.DescargarVistasInicial(proyectoSeleccionado);
                }
                else
                {
                    //Creamos la estructura de carpetas que tendrian las vistas en local
                    string rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyectoSeleccionado}";
                    Directory.CreateDirectory(rutaDirectorio);
                    rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyectoSeleccionado}/Vistas";
                    Directory.CreateDirectory(rutaDirectorio);
                    rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyectoSeleccionado}/Vistas/Views";
                    Directory.CreateDirectory(rutaDirectorio);
                    rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyectoSeleccionado}/Vistas/Recursos";
                    Directory.CreateDirectory(rutaDirectorio);
                    rutaDirectorio = $"{AppContext.GetData("rutaBase")}Views/{proyectoSeleccionado}/Vistas/CMS";
                    Directory.CreateDirectory(rutaDirectorio);
                }

            }
            ViewBag.Session = HttpContext;
            ViewBag.ControllerContexto = ControllerContext.RouteData;
            //actionContextAccessor.RouteData.Values["docID"]
            return GetView(jsonModel, proyectoSeleccionado);
        }

        private void GestionarDatosSession(string url, ref string user, ref string password)
        {
            HttpContext.Session.Remove("ErrorAskURL");

            string domainUri = "";
            try
            {
                domainUri = new Uri(url).Host;
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("ErrorAskURL", " La url no es valida");
                //HttpContext.Session["ErrorAskURL"] = "La url no es valida";
                throw ex;
            }

            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
            {
                UtilConfiguration.GetAuthorization(domainUri, ref user, ref password);
            }
            else
            {
                UtilConfiguration.SetAuthorization(domainUri, user, password);
            }
        }

        private ActionResult GetView(string jsonModel, string proyectoSeleccionado)
        {
            string controllerName = (string)ViewData["ControllerName"];
            string actionName = (string)ViewData["ActionName"];
            if (actionName == null) { actionName = "Index"; }

            string rutaVistasPersonalizadas = $"Views/{proyectoSeleccionado}/Vistas";
            string rutaVistasPersonalizadasEcosistema = $"Views/ecosistema/Vistas";

            ViewBag.rutaVistasPersonalizadas = rutaVistasPersonalizadas;
            ViewBag.rutaVistasPersonalizadasEcosistema = rutaVistasPersonalizadasEcosistema;

            if (!string.IsNullOrEmpty(controllerName))
            {
                object model = DeserializeObject(jsonModel);

                Type modelType = model.GetType();

                if (modelType.Name.Equals("ResourceViewModel") && controllerName.Equals("FichaRecurso"))
                {
                    // Comprobamos si el modelo contiene RdfType y mostramos la vista correspondiente
                    string rdfType = ((ResourceViewModel)model).Resource.RdfType;
                    if (!string.IsNullOrEmpty(rdfType))
                    {
                        string viewName = $"~/{rutaVistasPersonalizadas}/Recursos/{rdfType}.cshtml";
                        if (System.IO.File.Exists(AppContext.GetData("rutaBase") + viewName.Replace("~/", "")))
                        {
                            return View(viewName, model);
                        }
                    }
                    return View($"~/{rutaVistasPersonalizadas}/Views/FichaRecurso/Index.cshtml", model);
                }
                else if (controllerName.Equals("CMSPagina") && modelType.BaseType == typeof(CMSComponent))
                {
                    actionName = "_ComponenteCMS";
                    string view = $"../{controllerName}/{actionName}";

                    return PartialView(view, model);
                }
                else
                {
                    if (controllerName.Equals("BandejaMensajes") && modelType.Name.Equals("ResultadoModel")) { actionName = "Listado"; }
                    //if (controllerName.Equals("HomeComunidad") && modelType.Name.Equals("CMSBlock")) { controllerName = "CMSPagina"; actionName = "Index"; }
                    if (controllerName.Equals("HomeComunidad") && (modelType.Name.Equals("CMSBlock") || modelType.Name.Contains("List"))) { controllerName = "CMSPagina"; actionName = "Index"; }
                    if (controllerName.Equals("Busqueda")) { actionName = "Index"; }
                    if (modelType.Name.Equals("Error404ViewModel")) { controllerName = "Error"; actionName = "Error404"; }
                    if (controllerName.Equals("FichaPerfil") && ViewBag.Perfil.CompleteProfileName == "invitado") { actionName = "_FichaInvitado";}
                    string view = $"~/{rutaVistasPersonalizadas}/Views/{controllerName}/{actionName}.cshtml";

                    if (System.IO.File.Exists(AppContext.GetData("rutaBase") + view.Replace($"~/{rutaVistasPersonalizadas}/Views/", "GenericViews/")))
                    {
                        //Solamente pintamos la vista si existe una vista generica con esta ruta.
                        return  View(view,model);
                    }
                }
            }
            HttpContext.Session.SetString("ErrorAskURL", $"No se ha podido pintar la página de tipo '{controllerName}/{actionName}' con el Modelo de tipo ''");
            //Session["ErrorAskURL"] = $"No se ha podido pintar la página de tipo '{controllerName}/{actionName}' con el Modelo de tipo ''";

            ViewBag.Session = HttpContext;
            return View("/Areas/Gnoss.DevTools.ViewMaker/Views/Home/Error.cshtml");

        }

        private string GetData(string url, string submit, string sessionID, string user, string password)
        {
            string cacheFileName = UtilPageCache.GetFileName(url);

            string pageResult;

            if (submit == "Recargar" || !System.IO.File.Exists(cacheFileName))
            {
                pageResult = UtilPageRequest.GetRequest(url, user, password, sessionID,HttpContext);

                if (!string.IsNullOrWhiteSpace(pageResult))
                {
                    UtilPageCache.SaveCacheFile(cacheFileName, pageResult);
                }
            }
            else
            {
                pageResult = System.IO.File.ReadAllText(cacheFileName);
            }

            return pageResult;
        }

        private string GetJson(string responseFromServer, bool contentLocal, out string proyectoSeleccionado)
        {
            // Dividimos el json obtenido, la primera string para el modelo y la segunda para el ViewBag 
            string[] divideJson = responseFromServer.Split(new string[] { "{ComienzoJsonViewData}" }, StringSplitOptions.None);
            string jsonModel = divideJson[0];
            string jsonViewData = "";
            if (divideJson.Length > 1)
            {
                jsonViewData = divideJson[1];
            }
            
            // Deserializamos ViewData
            JsonSerializerSettings jsonSerializerSettingsSimple = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full
            };
            //proyectoSeleccionado = "testing3";
            Dictionary<string, object> ViewDataDeserializado1 = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonViewData, jsonSerializerSettingsSimple);

            ViewDataDictionary ViewDataDeserializado = new ViewDataDictionary(ViewData) { { "BookId", "prueba" } };

            foreach (var item in ViewDataDeserializado1)
            {

                ViewDataDeserializado[item.Key] = item.Value;
            }

            CommunityModel Comunidad = (CommunityModel)ViewDataDeserializado["Comunidad"];
            Dictionary<string, string> parametrosAplicacion = (Dictionary<string, string>)ViewDataDeserializado["ParametrosAplicacion"];
            //CommunityModel Comunidad = (CommunityModel)ViewDataDeserializado["Comunidad"];

            //Dictionary<string, string> parametrosAplicacion = (Dictionary<string, string>)ViewDataDeserializado["ParametrosAplicacion"];
            //if (parametrosAplicacion.ContainsKey("NombreCortoProyectoPadreEcositema") && Comunidad.ParentKey.HasValue)
            //{
            //    proyectoSeleccionado = parametrosAplicacion["NombreCortoProyectoPadreEcositema"];
            //}
            //else
            //{
                proyectoSeleccionado = Comunidad.ShortName;
            //}

            if (ViewDataDeserializado != null)
            {
                foreach (string item in ViewDataDeserializado.Keys)
                {
                    if (item.Equals("BaseUrlPersonalizacion") && contentLocal)
                    {
                        ViewData.Add(item, $"styles/{proyectoSeleccionado}/Proyectos/{proyectoSeleccionado}/Estilos");
                    }
                    else if (item.Equals("BaseUrlPersonalizacionEcosistema") && contentLocal)
                    {
                        ViewData.Add(item, $"styles/ecosistema/Proyectos/Proyectos/Estilos");
                    }
                    else
                    {
                        if (ViewData.ContainsKey(item))
                        {
                            ViewData[item] = ViewDataDeserializado[item];
                        }
                        else
                        {
                            ViewData.Add(item, ViewDataDeserializado[item]);
                        }
                        
                    }
                }
            }

            return jsonModel;
        }


        //protected override PartialViewResult PartialView (string viewName, object model)
        //{
        //    return HtmlHelper
        //}

        /// <summary>
        /// Se crea un objeto ViewResult utilizando el nombre de la vista, el nombre de la página maestra y el modelo que presenta una vista.
        /// Guarda en ViewBag.ViewPath la ruta relativa de la vista.
        /// </summary>
        //public  new virtual ViewResult View(string viewName, string masterName, object model)
        public  override ViewResult View(string viewName, object model)
        {
            string rutaVistasPersonalizadas = ViewBag.rutaVistasPersonalizadas;

            if (rutaVistasPersonalizadas != null && viewName.Contains(rutaVistasPersonalizadas))
            {
                ViewBag.ViewPath = viewName.Substring(0, viewName.LastIndexOf('/'));

                if (!System.IO.File.Exists(AppContext.GetData("rutaBase") + viewName.Replace("~/", "")))
                {
                    string rutaVistasPersonalizadasEcosistema = ViewBag.rutaVistasPersonalizadasEcosistema;
                    viewName = viewName.Replace($"/{rutaVistasPersonalizadas}/Views/", $"/{rutaVistasPersonalizadasEcosistema}/Views/");

                    if (!System.IO.File.Exists(AppContext.GetData("rutaBase") + viewName.Replace("~/", "")))
                    {
                        viewName = viewName.Replace($"/{rutaVistasPersonalizadasEcosistema}/Views/", "/GenericViews/");
                    }
                }
            }
            //En net core el metodo View solo admite dos parametros
            //return base.View(viewName, masterName, model);
            return base.View(viewName, model);
        }

        /// <summary>
        /// Obtenemos un objeto deserializado con las opciones de deserialización PreserveReferencesHandling.Objects y TypeNameHandling.All
        /// </summary>

        private object DeserializeObject(string json)
        {
            try
            {

               /* MemoryStream mStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(json));
                BinaryFormatter deserializer = new BinaryFormatter();
                object model = deserializer.Deserialize(mStream);*/
                using (MemoryStream input = new MemoryStream(Convert.FromBase64String(json)))
                using (DeflateStream deflateStream = new DeflateStream(input, CompressionMode.Decompress))
                using (MemoryStream output = new MemoryStream())
                {
                    deflateStream.CopyTo(output);
                    deflateStream.Close();
                    output.Seek(0, SeekOrigin.Begin);

                    BinaryFormatter bformatter = new BinaryFormatter();
                    object message = (object)bformatter.Deserialize(output);
                    return message;
                }

                //return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("/validar")]
        public bool IsValidDirName(string dirName)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidPathChars()));

            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return !Regex.IsMatch(dirName, invalidRegStr);
        }
    }



}
