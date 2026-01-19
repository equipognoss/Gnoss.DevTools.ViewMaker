using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.Plantillas
{
    public enum TipoRepresentacion
    {
        /// <summary>
        /// TipoEntidadMasID.
        /// </summary>
        TipoEntidadMasID = 0,
        /// <summary>
        /// SoloID.
        /// </summary>
        SoloID = 1,
        /// <summary>
        /// TodosLosCaracteres.
        /// </summary>
        TodosLosCaracteres = 2,
        /// <summary>
        /// NumCaracteresExactos
        /// </summary>
        NumCaracteresExactos = 3
    }
}
