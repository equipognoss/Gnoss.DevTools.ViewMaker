using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de mensajes
    /// </summary>
    public partial class MessageModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Asunto del mensaje
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Cuerpo del mensaje
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// URL del mensaje
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Indica si el mensaje ha sido leido
        /// </summary>
        public bool Readed { get; set; }
        /// <summary>
        /// Indica si el usuario es el remitente del mensaje
        /// </summary>
        public bool Sent { get; set; }
        /// <summary>
        /// Indica si el usuario es el destinatario del mensaje
        /// </summary>
        public bool Received { get; set; }
        /// <summary>
        /// Indica si el mensaje esta en la papelera
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// Identificador del remitente del mensaje
        /// </summary>
        public Guid SenderKey { get; set; }
        /// <summary>
        /// Identificador del destinaratio del mensaje
        /// </summary>
        public Guid ReceiverKey { get; set; }
        /// <summary>
        /// Lista de identificadores de los destinatarios del mensaje
        /// </summary>
        public List<Guid> ReceiversKey { get; set; }
        /// <summary>
        /// Lista de identificadores de los grupos destinatarios del mensaje
        /// </summary>
        public List<Guid> ReceiversGroupKey { get; set; }
        /// <summary>
        /// Remitente del mensaje
        /// </summary>
        public ProfileModel Sender { get; set; }
        /// <summary>
        /// Lista de destinatarios del mensaje
        /// </summary>
        public List<ProfileModel> Receivers { get; set; }
        /// <summary>
        /// Lista de grupos destinatarios del mensaje
        /// </summary>
        public List<GroupCardModel> ReceiversGroup { get; set; }
        /// <summary>
        /// Fecha y hora de envio del mensaje
        /// </summary>
        public DateTime ShippingDate { get; set; }
        /// <summary>
        /// Identificador del mensaje anterior
        /// </summary>
        public Guid PreviousMessageKey { get; set; }
        /// <summary>
        /// Identificador del mensaje siguiente
        /// </summary>
        public Guid NextMessageKey { get; set; }

    }
}
