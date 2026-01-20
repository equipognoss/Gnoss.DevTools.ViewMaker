using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de invitación
    /// </summary>
    [Serializable]
    public partial class InvitationModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Identificador de la invitación
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Asunto de la invitación
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Cuerpo de la invitación
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Tipo de invitación
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Clave del remitente de la invitación
        /// </summary>
        public Guid SenderKey { get; set; }
        /// <summary>
        /// Remitente de la invitación
        /// </summary>
        public ProfileModel Sender { get; set; }
    }
}
