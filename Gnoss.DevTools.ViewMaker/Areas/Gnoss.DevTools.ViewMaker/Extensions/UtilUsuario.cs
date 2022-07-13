using Microsoft.AspNetCore.Http;
using System;

namespace Gnoss.DevTools.ViewMaker.Extensions
{
    public class UtilUsuario
    {
        private static string mUrlServicioLogin = null;

        /// <summary>
        /// Obtiene la URL del servicio de login
        /// </summary>
        public static string UrlServicioLogin
        {
            get
            {
                if (mUrlServicioLogin == null)
                {
                    return "http://localhost";
                }

                return mUrlServicioLogin;
            }
        }

        /// <summary>
        /// Obtiene un token para que el usuario se pueda loguear
        /// </summary>
        public static string TokenLoginUsuario
        {
            get
            {
                HttpContextAccessor httpContext = new HttpContextAccessor();
              
                if(httpContext.HttpContext.Session.GetString("tokenCookie") == null) {
                    string ticks = DateTime.Now.Ticks.ToString();
                    httpContext.HttpContext.Session.SetString("tokenCookie", ticks);
                }

                return httpContext.HttpContext.Session.GetString("tokenCookie");
                /*
                if (HttpContext.Current.Session["tokenCookie"] == null)
                {
                    string ticks = DateTime.Now.Ticks.ToString();
                    HttpContext.Current.Session["tokenCookie"] = ticks;
                    
                }
                
               return (string)HttpContext.Current.Session["tokenCookie"];*/
                
            }
        }

        private static bool? mJSYCSSunificado = null;

        
        public static bool JSYCSSunificado
        {
            get
            {
                if (mJSYCSSunificado == null)
                {
                    mJSYCSSunificado = false;
                    //if (Conexion.ObtenerParametro("config/gnoss.config", "config/JSYCSSunificado", false) == "1")
                    //{
                    //    mJSYCSSunificado = true;
                    //}
                }
                return (bool)mJSYCSSunificado;
            }
            set
            {
                mJSYCSSunificado = value;
            }
        }

    }
}