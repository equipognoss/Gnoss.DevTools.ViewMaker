using System;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Gnoss.DevTools.ViewMaker.Areas.Gnoss.DevTools.ViewMaker.Utilidades
{
    public class UtilPageRequest
    {

        internal static string GetRequest(string url, string user, string password, string sessionID, HttpContext httpContext)
        {
            string responseFromServer = null;

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            // Cambiamos la propiedad 'Accept' para aceptar json
            myHttpWebRequest.Accept = "application/json";
            myHttpWebRequest.Timeout = 100000000;

            if (!string.IsNullOrEmpty(user))
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{user}:{password}");
                string base64Auth = System.Convert.ToBase64String(plainTextBytes);
                myHttpWebRequest.Headers.Add(HttpRequestHeader.Authorization, $"Basic {base64Auth}");
            }

            myHttpWebRequest.CookieContainer = new CookieContainer();
            if (!string.IsNullOrEmpty(sessionID))
            {
                myHttpWebRequest.Headers["Cookie"] = ".AspNetCore.Session=" + sessionID;

                //myHttpWebRequest.CookieContainer.Add(new Cookie(".AspNetCore.Session", sessionID, "/", myHttpWebRequest.RequestUri.Host));
            }

            try
            {
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream dataStream = myHttpWebResponse.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Leemos el contenido de la respuesta
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                
                httpContext.Session.SetString("ErrorAskURL", error);
               // HttpContext.Current.Session["ErrorAskURL"] = error;
                responseFromServer = null;
            }

            return responseFromServer;
        }
    }
}