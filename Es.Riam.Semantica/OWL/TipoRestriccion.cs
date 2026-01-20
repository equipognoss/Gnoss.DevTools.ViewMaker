using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.OWL
{
    /// <summary>
    /// Enumeración de tipos de restricción
    /// </summary>
    public enum TipoRestriccion
    {
        /// <summary>
        /// Todos los valores de un tipo
        /// </summary>
        AllValuesFrom,
        /// <summary>
        /// Cardinalidad de la propiedad
        /// </summary>
        Cardinality,
        /// <summary>
        /// Máxima cardinalidad
        /// </summary>
        MaxCardinality,
        /// <summary>
        /// Mínima cardinalidad
        /// </summary>
        MinCardinality,
        /// <summary>
        /// Algunos valores son del tipo
        /// </summary>
        SomeValuesFrom
    }
}
