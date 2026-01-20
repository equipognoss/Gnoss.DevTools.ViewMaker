using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para la selección de usuarios.
    /// </summary>
    [Serializable]
    public partial class UsersSelectorModel
    {

        /// <summary>
        /// Texto informativo para el selector de usuarios.
        /// </summary>
        public string TextInfoSelectUsers { get; set; }

        /// <summary>
        /// Texto informativo los usuarios seleccionados.
        /// </summary>
        public string TextSelectUsers { get; set; }

        /// <summary>
        /// ID del perfil que crea un documento.
        /// </summary>
        public Guid DocumentCreatorProfileId { get; set; }

        /// <summary>
        /// IDs con los perfiles seleccionados.
        /// </summary>
        public Dictionary<Guid, string> SelectedProfilesList { get; set; }

        /// <summary>
        /// IDs con los grupos seleccionados.
        /// </summary>
        public Dictionary<Guid, string> SelectedGroupsList { get; set; }
    }
}
