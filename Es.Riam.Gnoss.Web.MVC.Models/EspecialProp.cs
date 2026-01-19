using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Clase que aglutina información del dato especial, que es la propiedad actual.
    /// </summary>
    [Serializable]
    public class EspecialProp
    {
        #region Especial Faceta

        /// <summary>
        /// Nombre de la faceta del dato especial.
        /// </summary>
        public string Facet { get; set; }

        /// <summary>
        /// Grafo para la faceta del dato especial.
        /// </summary>
        public string Graph { get; set; }

        /// <summary>
        /// Parámetros para la búsqueda del dato especial.
        /// </summary>
        public string Parameters { get; set; }

        #endregion

        #region Especial Botón

        /// <summary>
        /// ID de la acción del botón.
        /// </summary>
        public string ActionID { get; set; }

        /// <summary>
        /// Nombre del botón.
        /// </summary>
        public string ButtonName { get; set; }

        /// <summary>
        /// ID de la entidad de la acción.
        /// </summary>
        public string ActionEntityID { get; set; }

        #endregion
    }
}
