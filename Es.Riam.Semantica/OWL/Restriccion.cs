using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.OWL
{
    /// <summary>
    /// Representa una restricción sobre una propiedad.
    /// </summary>
    public class Restriccion
    {
        /// <summary>
        /// Obtiene la propiedad sobra la que se impone la restricción.
        /// </summary>
        public string Propiedad { get; set; }

        /// <summary>
        /// Obtiene el tipo de restricción.
        /// </summary>
        public TipoRestriccion TipoRestriccion { get; set; }

        /// <summary>
        /// Obtiene o establece el valor de la restricción.
        /// </summary>
        public string Valor { get; set; }

    }
}
