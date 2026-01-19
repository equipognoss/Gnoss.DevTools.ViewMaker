using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class ViewResorceModel
    {
        /// <summary>
        /// Indica si se debe mostrar la descripcion
        /// </summary>
        public bool ShowDescription { get; set; }
        /// <summary>
        /// Indica si se deben mostrar las categorias
        /// </summary>
        public bool ShowCategories { get; set; }
        /// <summary>
        /// Indica si se deben mostrar las etiquetas
        /// </summary>
        public bool ShowTags { get; set; }
        /// <summary>
        /// Indica si se debe mostrar el publicador
        /// </summary>
        public bool ShowPublisher { get; set; }
        /// <summary>
        /// Html de los datos semanticos del recurso
        /// </summary>
        public string InfoExtra { get; set; }
    }

}
