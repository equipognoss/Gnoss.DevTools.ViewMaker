using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class CategoryModel
    {
        public short Obligatoria { get; set; }

        public short Estructurante { get; set; }

        /// <summary>
        /// Idioma del usuario
        /// </summary>
        public string Lang { set { } } 
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        public Guid Key { get; set; }

        public string Image { get; set; }

        public ImagenCategoria Imagen { get; set; }

        /// <summary>
        /// Nombre de la categoria con todos los idiomas
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Orden de la categoria
        /// </summary>
        public short Order { get; set; }

        /// <summary>
        /// Indica si la categoria es obligatoria
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Identificador de la categoría padre
        /// </summary>
        public Guid ParentCategoryKey { get; set; }
        /// <summary>
        /// Identificador string de la categoría padre
        /// </summary>
        public string ParentCategoryStringKey { get; set; }
        /// <summary>
        /// Número de recursos de la categoria
        /// </summary>
        public int NumResources { get; set; }
        /// <summary>
        /// Indica si la categoria esta selecccionada
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Identificador de la categoria en texto.
        /// </summary>
        public string StringKey { get; set; }

        /// <summary>
        /// Lista de categorías hijas
        /// </summary>
        public List<CategoryModel> Subcategories { get; set; }
    }
}
