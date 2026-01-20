using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Enumeración de ubicaciónes de trozos de html dentro de la página
    /// </summary>
    public enum UbicacionHtmlProyecto
    {
        /// <summary>
        /// Al final de la etiqueta head
        /// </summary>
        EndHead = 0,

        /// <summary>
        /// Al final de la etiqueta body
        /// </summary>
        EndBody = 1,

        /// <summary>
        /// Al inicio de la etiqueta head
        /// </summary>
        BeginHead = 2,

        /// <summary>
        /// Al inicio de la etiqueta body
        /// </summary>
        BeginBody = 3
    }
}
