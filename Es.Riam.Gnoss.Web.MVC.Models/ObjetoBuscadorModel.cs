using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public abstract class ObjetoBuscadorModel
    {
        /// <summary>
        /// Url para las búsquedas
        /// </summary>
        public string UrlSearch { get; set; }

        public int CacheVersion { get; set; }
    }
}
