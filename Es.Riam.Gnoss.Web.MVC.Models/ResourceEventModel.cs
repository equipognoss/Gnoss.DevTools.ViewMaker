using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de eventos de un recurso
    /// </summary>
    [Serializable]
    public partial class ResourceEventModel
    {
        /// <summary>
        /// Tipo de evento
        /// </summary>
        public enum EventType
        {
            /// <summary>
            /// Votado
            /// </summary>
            Voted = 0,
            /// <summary>
            /// Certificado
            /// </summary>
            Certified = 1,
            /// <summary>
            /// Commentado
            /// </summary>
            Commented = 2
        }


        /// <summary>
        /// Indica si es un evento de comentario, de voto o de certificado
        /// </summary>
        public EventType Type { get; set; }
        /// <summary>
        /// Fecha en la que se ha realizado el evento
        /// </summary>
        public DateTime Date { get; set; }

    }
}
