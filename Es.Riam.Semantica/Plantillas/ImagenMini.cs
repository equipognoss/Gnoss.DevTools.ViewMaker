using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica
{
    /// <summary>
    /// Imagén miniatura para un propiedad de tipo imagen.
    /// </summary>

    [Serializable]
    public class ImagenMini
    {

        /// <summary>
        /// Tamaños de la imágenes
        /// </summary>
        public Dictionary<int, int> Tamanios {  get; set; }

        /// <summary>
        /// Tipo de recorte o redimensión.
        /// </summary>
        public Dictionary<int, string> Tipo {  get; set; }
    }
}
