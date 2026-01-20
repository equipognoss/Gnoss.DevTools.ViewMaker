using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View Model de la pagina Home
    /// </summary>
    [Serializable]
    public class NotificationViewModel
    {
        /// <summary>
        /// URL para aceptar una invitación
        /// </summary>
        public string UrlActionAcceptInvitation { get; set; }
        /// <summary>
        /// URL para rechazar una invitación
        /// </summary>
        public string UrlActionRejectInvitation { get; set; }
        /// <summary>
        /// URL para marcar comentarios como leídos
        /// </summary>
        public string UrlActionMarkReadComment { get; set; }
    }
}
