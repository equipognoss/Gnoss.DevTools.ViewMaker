using Es.Riam.Semantica.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class SemanticPropertieModel
    {
        /// <summary>
        /// Nombre de la propiedad
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Url del filtro de la propiedad
        /// </summary>
        public string Url { get; set; }
    }
}
