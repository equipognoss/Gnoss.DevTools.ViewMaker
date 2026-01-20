using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de contacto
    /// </summary>
    [Serializable]
    public partial class ContactModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Tipos de contacto
        /// </summary>
        [Serializable]
        public enum ContactType
        {
            /// <summary>
            /// Contacto de tipo persona
            /// </summary>
            Person = 0,
            /// <summary>
            /// Contacto de tipo organización
            /// </summary>
            Organization = 1,
            /// <summary>
            /// Grupo de contactos
            /// </summary>
            Group = 2
        }
        /// <summary>
        /// Identificador del contacto
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Tipo de contacto
        /// </summary>
        public ContactType Type { get; set; }
        /// <summary>
        /// Nombre del contacto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Foto del contacto
        /// </summary>
        public string Foto { get; set; }
        /// <summary>
        /// Url del contacto
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Lista de grupos a los que pertenece el contacto
        /// </summary>
        public Dictionary<string, string> ListGroups { get; set; }
        /// <summary>
        /// Lista de miembros del contacto si es de tipo grupo
        /// </summary>
        public Dictionary<string, string> ListMembers { get; set; }
    }
}
