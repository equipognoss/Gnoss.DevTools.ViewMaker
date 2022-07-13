using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gnoss.DevTools.ViewMaker
{
    public class MyViewLocationExpander: IViewLocationExpander
    {
        
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //DirectoryInfo directorioVistas = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views"));
            DirectoryInfo directorioVistas = new DirectoryInfo(Path.Combine((string)AppContext.GetData("rutaBase"), "Views"));
            DirectoryInfo[] directoriosVistas = directorioVistas.GetDirectories();
            string[] locations = new string[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/CMSPagina/{0}.cshtml",
                "~/GenericViews/{1}/{0}.cshtml",
                "~/GenericViews/Shared/{0}.cshtml",
                "~/GenericViews/CMSPagina/{0}.cshtml"
            };
           
           
            foreach (DirectoryInfo directorio in directoriosVistas)
            {
               locations.Append($"~/Views/{directorio.Name}/{{0}}" + RazorViewEngine.ViewExtension);
               locations.Append($"~/GenericViews/{directorio.Name}/{{0}}" + RazorViewEngine.ViewExtension);
            }

            return locations.Union(viewLocations);
            
            
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
            throw new NotImplementedException();
        }
    }
}
