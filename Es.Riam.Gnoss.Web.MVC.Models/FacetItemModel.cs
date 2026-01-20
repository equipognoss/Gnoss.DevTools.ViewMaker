using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Item de una faceta
    /// </summary>
    public partial class FacetItemModel
    {
        /// <summary>
        /// Título
        /// </summary>
        public string Tittle { get; set; }
        /// <summary>
        /// Indica si está seleccinado en los filtros el ítem de la faceta
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Indica el número de resultados con ese filtro
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Filtro a aplicar
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Listadeo de ítem dentro del propio ítem(facetas anidadas)
        /// </summary>
        public List<FacetItemModel> FacetItemlist { get; set; }

        /// <summary>
        /// Propiedad que indica si la faceta es hija de otra faceta (Recursividad)
        /// </summary>
        public bool IsChildren { get; set; }
    }
}
