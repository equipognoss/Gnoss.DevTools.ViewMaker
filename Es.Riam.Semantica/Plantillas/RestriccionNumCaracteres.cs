using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica
{
    /// <summary>
    /// Restricción del número de caracteres de una propiedad.
    /// </summary>
    [Serializable]
    public class RestriccionNumCaracteres
    {
        /// <summary>
        /// Tipo de restricción.
        /// </summary>
        public string TipoRestricion {  get; set; }

        /// <summary>
        /// Valor restricción
        /// </summary>
        public int Valor {  get; set; }

        /// <summary>
        /// Valor máximo para la restricción entre X e Y.
        /// </summary>
        public int ValorHasta {  get; set; }

    }
}
