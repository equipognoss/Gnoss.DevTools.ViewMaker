using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.Plantillas
{
    /// <summary>
    /// Representa una acción para evaluar en el SEM CMS.
    /// </summary>
    [Serializable]
    public class AccionSemCms
    {
        #region Propiedades

        /// <summary>
        /// ID de la Acción.
        /// </summary>
        public string ID { get; set; }

        public List<Accion> Acciones { get; set; }

        #endregion

        /// <summary>
        /// Acción interna de una acción del SEMCMS.
        /// </summary>
        [Serializable]
        public class Accion
        {
            public TipoAccion TipoAccion { get; set; }

            #region Servicio Externo

            /// <summary>
            /// Url del servicio externo.
            /// </summary>
            public string UrlServExterno { get; set; }

            #endregion
        }

        /// <summary>
        /// Tipo de acción interna de una acción del SEMCMS.
        /// </summary>
        [Serializable]
        public enum TipoAccion
        {
            /// <summary>
            /// Acción de enviar un documento a un servicio externo.
            /// </summary>
            EnviarServExterno = 0
        }
    }
}
