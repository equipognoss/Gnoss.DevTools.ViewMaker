using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// Modelo que contiene una categoría de cookie con su estado (0 -> Pendiente, 1 -> Aceptada, 2 -> Denegada)
    /// </summary>
    [Serializable]
    public class PersonalizacionCategoriaCookieModel
    {
        /// <summary>
        /// Categoría de la cookie
        /// </summary>
        public CategoriaProyectoCookieViewModel CategoriaCookie { get; set; }

        /// <summary>
        /// Estado de la categoría
        /// </summary>
        public short Estado { get; set; }
    }
}
