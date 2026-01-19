using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS de tipo Destacado
    /// </summary>
    [Serializable]
    public class CMSComponentHot : CMSComponent
    {
        /// <summary>
        /// Subtitulo del componente destacado
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// Url de la imagen del componente destacado
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Html libre para incluir en el componente
        /// </summary>
        public string HTML { get; set; }
        /// <summary>
        /// Enlace al que apunta el componente
        /// </summary>
        public string Link { get; set; }
    }
}
