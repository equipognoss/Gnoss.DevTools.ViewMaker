using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de grupo
    /// </summary>
    public partial class GroupCardModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Enumeración de tipo de grupo
        /// </summary>
        public enum GroupTypes
        {
            /// <summary>
            /// Tipo de grupo de comunidad
            /// </summary>
            Community,
            /// <summary>
            /// Tipo de grupo de organización
            /// </summary>
            Organization
        }
        /// <summary>
        /// Identificador del grupo
        /// </summary>
        public Guid Clave { get; set; }
        /// <summary>
        /// Nombre del grupo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nombre del grupo
        /// </summary>
        public string CompleteName { get; set; }
        /// <summary>
        /// Descripcion del grupo
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Nombre del grupo
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// URL del grupo
        /// </summary>
        public string UrlGroup { get; set; }
        /// <summary>
        /// URL del grupo
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Tipo de grupo
        /// </summary>
        public GroupTypes GroupType { get; set; }
        /// <summary>
        /// Indica si se puede enviar un mensaje al grupo
        /// </summary>
        public bool AllowSendMessage { get; set; }
        /// <summary>
        /// Indica si se puede abandonar el grupo
        /// </summary>
        public bool AllowLeaveGroup { get; set; }
        /// <summary>
        /// Nombre del proyecto
        /// </summary>
        public Guid ProyectKey { get; set; }
        /// <summary>
        /// Nombre corto del proyecto
        /// </summary>
        public string ProyectShortName { get; set; }
    }
}
