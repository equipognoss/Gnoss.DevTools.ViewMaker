using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Clase que representa a los recursos vinculados a un selector de entidad.
    /// </summary>
    [Serializable]
    public class ResourceLinkedToEntitySelector
    {
        /// <summary>
        /// Key del recurso
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Link del recurso
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Título del recurso.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Texto del label título para el recurso.
        /// </summary>
        public string TitleLabel { get; set; }

        /// <summary>
        /// URl de la imagen del recurso.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Texto del label imagen para el recurso.
        /// </summary>
        public string ImageUrlLabel { get; set; }

        /// <summary>
        /// Descripción del recurso.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Texto del label descripción para el recurso.
        /// </summary>
        public string DescriptionLabel { get; set; }

        /// <summary>
        /// Autores del recurso. Key: Nombre del autor. Value: Link del autor.
        /// </summary>
        public Dictionary<string, string> Authors { get; set; }

        /// <summary>
        /// Texto del label autores para el recurso.
        /// </summary>
        public string AuthorsLabel { get; set; }
    }
}
