using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class ViewSettingResorceModel
    {

        #region Propiedades

        /// <summary>
        /// Indica las propiedades que se deben mostrar en la vista Listado
        /// </summary>
        public ViewResorceModel ListView { get; set; }

        /// <summary>
        /// Indica las propiedades que se deben mostrar en la vista Mosaico
        /// </summary>
        public ViewResorceModel MosaicView { get; set; }

        /// <summary>
        /// Indica las propiedades que se deben mostrar en la vista Contexto
        /// </summary>
        public ViewResorceModel ContextView { get; set; }

        /// <summary>
        /// Indica las propiedades que se deben mostrar en la vista Mapa
        /// </summary>
        public ViewResorceModel MapView { get; set; }

        /// <summary>
        /// Lista de propiedades semánticas del recurso
        /// </summary>
        public Dictionary<string, List<SemanticPropertieModel>> SemanticProperties { get; set; }

        /// <summary>
        /// Lista de propiedades semánticas personalizasdas del recurso
        /// </summary>
        public List<CustomSemanticPropertiesModel> CustomSemanticProperties { get; set; }

        /// <summary>
        /// Indica el tipo de vista que está por defecto
        /// </summary>
        public TipoVista VistaDefecto { get; set; }

        #endregion
    }
    public enum TipoVista
    {
        /// <summary>
        /// Lista
        /// </summary>
        Lista = 0,
        /// <summary>
        /// Mosaico
        /// </summary>
        Mosaico = 1,
        /// <summary>
        /// Mapa
        /// </summary>
        Mapa = 2,
        /// <summary>
        /// Contexto
        /// </summary>
        Contexto = 3
    }
}
