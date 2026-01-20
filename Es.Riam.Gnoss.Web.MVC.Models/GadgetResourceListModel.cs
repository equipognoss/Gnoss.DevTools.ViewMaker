using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// Modelo de un gadget de tipo Lista de recursos
    [Serializable]
    public partial class GadgetResourceListModel : GadgetModel
    {
        /// <summary>
        /// Lista de recursos
        /// </summary>
        public List<ResourceModel> Resources { get; set; }

        /// <summary>
        /// Lista de recursos de la segunda pagina
        /// </summary>
        public List<ResourceModel> ResourcesPagers { get; set; }

        /// <summary>
        /// Nombre da la vista de los recursos
        /// </summary>
        public string ViewNameResources { get; set; }

        /// <summary>
        /// Enlace a ver mas recursos
        /// </summary>
        public string UrlViewMore { get; set; }
    }
}
