namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de "Enviar invitación a la comunidad" 
    /// </summary>
    public class SendInvitationComViewModel
    {
        /// <summary>
        /// Indica si permite enviar invitaciones a grupos
        /// </summary>
        public bool AllowGroupsInvitations { get; set; }
        /// <summary>
        /// Indica si permite enviar invitaciones a tus contactos
        /// </summary>
        public bool AllowInviteContacts { get; set; }
        /// <summary>
        /// Indica si permite enviar invitaciones por email
        /// </summary>
        public bool AllowInviteEmail { get; set; }
        /// <summary>
        /// Indica si se puede personalizar el mensaje de invitación a la comunidad
        /// </summary>
        public bool AllowPersonlizeMessage { get; set; }
        /// <summary>
        /// Mensaje de invitación a la comunidad
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Identificadores y emails de los invitados, separados por comas
        /// </summary>
        public string Guests { get; set; }
        /// <summary>
        /// Identificadores de los grupos invitados, separados por comas
        /// </summary>
        public string Groups { get; set; }

    }
}
