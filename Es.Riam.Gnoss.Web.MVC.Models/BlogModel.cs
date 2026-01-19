using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de blog
    /// </summary>
    [Serializable]
    public partial class BlogModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Identificador del blog
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Nombre del blog
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nombre corto del blog
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Descripcion del blog
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// URL del blog
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Identificador del publicador del blog
        /// </summary>
        public Guid PublisherKey { get; set; }
        /// <summary>
        /// Publicador del blog
        /// </summary>
        public ProfileModel Publisher { get; set; }
    }
}
