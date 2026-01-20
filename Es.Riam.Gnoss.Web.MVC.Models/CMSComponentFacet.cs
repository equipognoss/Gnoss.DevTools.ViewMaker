using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Faceta
    /// </summary>
    [Serializable]
    public class CMSComponentFacet : CMSComponent
    {
        #region Enumeraciones
        /// <summary>
        /// Enumeración para distinguir tipos de presentacion de las facetas
        /// </summary>
        public enum CMSComponentFacetPresentation
        {
            /// <summary>
            /// Normal
            /// </summary>
            Normal = 0,
            /// <summary>
            /// Barras
            /// </summary>
            Bars = 1,
            /// <summary>
            /// Sectores
            /// </summary>
            Sectors = 2
        }
        #endregion

        /// <summary>
        /// Modelo de faceta
        /// </summary>
        public FacetModel FacetModel { get; set; }

        public CMSComponentFacetPresentation PresentatioType { get; set; }

        /// <summary>
        /// URL del buscador
        /// </summary>
        public string UrlSearcherCMS { get; set; }
    }
}
