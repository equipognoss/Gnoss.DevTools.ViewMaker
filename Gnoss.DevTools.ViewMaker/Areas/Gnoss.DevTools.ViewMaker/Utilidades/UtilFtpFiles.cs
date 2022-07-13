using System;
using System.IO;
using LibGit2Sharp;
using System.Net;
using System.Collections.Generic;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades
{
    internal static class UtilFtpFiles
    {
        internal static void SubirVistas(string proyectName, string serverURL, string userFTP, string passwordFTP)
        {
            Dictionary<string, FileStatus> listaCambios = UtilGitFiles.GetFilesWithChanges(proyectName);

            foreach(string cambio in listaCambios.Keys)
            {
                FileStatus status = listaCambios[cambio];

                if (status.Equals(FileStatus.DeletedFromWorkdir))
                {
                    DeleteFileFTP(cambio, serverURL, userFTP, passwordFTP);
                }
                else if (status.Equals(FileStatus.ModifiedInWorkdir) || status.Equals(FileStatus.NewInWorkdir))
                {
                    UploadFileFTP(cambio, serverURL, $"{AppContext.GetData("rutaBase")}Views/{proyectName}", userFTP, passwordFTP, proyectName);
                }
            }
        }

        private static void DeleteFileFTP(string fileName, string serverURL, string userFTP, string passwordFTP)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{serverURL}/{fileName}");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(userFTP, passwordFTP);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine(response.StatusDescription);
            }
        }

        private static void UploadFileFTP(string fileName, string serverURL, string repositoryUrl, string userFTP, string passwordFTP, string proyectName)
        {
            try
            {
                using (FileStream fs = File.Open($"{repositoryUrl}/{fileName}", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    string urlFtp = $"ftp://{serverURL}/{proyectName}/{fileName.Replace("Proyectos\\", "")}";

                    FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(urlFtp);
                    ftp.Credentials = new NetworkCredential(userFTP, passwordFTP);
                    ftp.KeepAlive = false;
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    ftp.UseBinary = true;
                    ftp.ContentLength = fs.Length;
                    ftp.Proxy = null;
                    byte[] buff = new byte[fs.Length];
                    fs.Read(buff, 0, buff.Length);
                    fs.Close();
                    Stream ftpstream = ftp.GetRequestStream();
                    ftpstream.Write(buff, 0, buff.Length);
                    ftpstream.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
        
    }
}