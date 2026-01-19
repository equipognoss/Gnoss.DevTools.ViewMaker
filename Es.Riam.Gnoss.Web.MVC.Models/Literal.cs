using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Clase que aglutina información del literal, que es la propiedad actual.
    /// </summary>
    [Serializable]
    public class Literal
    {
        /// <summary>
        /// Link que se debe agregar al literal.
        /// </summary>
        public string LiteralLink { get; set; }

        /// <summary>
        /// Texto del literal.
        /// </summary>
        public string LiteralName { get; set; }
    }
}
