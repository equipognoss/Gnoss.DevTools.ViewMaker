using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class CustomSemanticPropertiesModel
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Filas
        /// </summary>
        public List<Dictionary<string, string>> Rows { get; set; }
    }
}
