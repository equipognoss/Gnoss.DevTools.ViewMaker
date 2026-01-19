using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.Plantillas
{
    public class CondicionSemCms
    {
        #region Propiedades

        /// <summary>
        /// ID de la condición.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Variables a partir de las propiedades. Key = Nombre de la variable. Value = Propiedades con entidad separadas por coma y separado todo ello por | si hay jerarquia de propiedades.
        /// </summary>
        public Dictionary<string, string> VariablesProp { get; set; }

        /// <summary>
        /// Clausula para que se cumplan las condiciones.
        /// </summary>
        public ClausulaSemCms Clausula { get; set; }

        #endregion

        /// <summary>
        /// Clausula para la condición.
        /// </summary>
        public class ClausulaSemCms
        {
            /// <summary>
            /// Tipo de clausula. Puede ser: 'Or', 'And', 'Igual', 'Distinto', 'PerteneceAGrupo'.
            /// </summary>
            public string Tipo { get; set; }

            /// <summary>
            /// Clausulas hijas de la clausula actual.
            /// </summary>
            public List<ClausulaSemCms> Clausulas { get; set; }

            public List<string> Valores { get; set; }
        }
    }
}
