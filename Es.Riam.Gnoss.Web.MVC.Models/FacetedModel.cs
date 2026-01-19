using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo del buscador facetado
    /// </summary>
    [Serializable]
    public partial class FacetedModel
    {
        /// <summary>
        /// Lista de facetas
        /// </summary>
        public List<FacetModel> FacetList { get; set; }
        /// <summary>
        /// Lista de filtros
        /// </summary>
        public List<FacetItemModel> FilterList { get; set; }
    }
}
