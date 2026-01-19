using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{

    /// <summary>
    /// Clase abstracta de la que heredan todos los componentes del CMS
    /// </summary>
    [Serializable]
    public abstract class CMSComponent
    {
        /// <summary>
        /// Identificador del componentes
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Título del componente
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Estilos para incluir en el atributo class del componente 
        /// </summary>
        public string Styles { get; set; }
        /// <summary>
        /// Nombre de la vista que utiliza el componente
        /// </summary>
        public string ViewName { get; set; }
        /// <summary>
        /// Nombre de la vista que utilizan los recursos que aparezcan en el componente
        /// </summary>
        public string ViewNameResources { get; set; }
        /// <summary>
        /// Booleano que indica se el recurso se carga por AJAX
        /// </summary>
        public bool AJAX { get; set; }
    }

}
