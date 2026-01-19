using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public abstract class GadgetModel
    {
        /// <summary>
        /// Identificador del gadget
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Titulo del gadget
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Nombre corto del gadget(necesario para identificar un gadget en una vista)
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Clase que se le da al gadget para poder ser identificado desde javascript
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// Orden en el que se pinta el gadget
        /// </summary>
        public int Order { get; set; }
    }
}
