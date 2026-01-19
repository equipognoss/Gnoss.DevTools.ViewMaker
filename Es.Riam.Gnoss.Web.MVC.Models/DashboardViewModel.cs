using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// View model de las pagina de dashboard
    /// </summary>
    [Serializable]
    public class DashboardViewModel
    {
        /// <summary>
        /// Nombre de la pagina de busqueda
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// Título de la pagina de busqueda
        /// </summary>
        public string PageTittle { get; set; }
        public string TipoPagina { get; set; }
        /// <summary>
        /// Lista con los asistentes
        /// </summary>
        public List<AsistenteModel> ListAsistente { get; set; }
        /// <summary>
        /// Modelo de asistente
        /// </summary>
        [Serializable]
        public partial class AsistenteModel
        {
            /// <summary>
            /// Identificador del asistente
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// Nombre del asistente
            /// </summary>
            public string AsistenteName { get; set; }

            public int[] Ordenes { get; set; }

            public int Orden { get; set; }
            /// <summary>
            /// Barras horizontales
            /// </summary>
            public bool PropExtra { get; set; }
            /// <summary>
            /// Tamaño del asistente
            /// </summary>
            public string Tamanyo { get; set; }
            /// <summary>
            /// Tipo del asistente
            /// </summary>
            public int Tipo { get; set; }
            /// <summary>
            /// Mostrar titulo en el gráfico
            /// </summary>
            public bool Titulo { get; set; }
            /// <summary>
            /// Lista de dataset
            /// </summary>
            public List<DatasetModel> ListDataset { get; set; }
            /// <summary>
            /// Modelo de dataset
            /// </summary>
            public partial class DatasetModel
            {
                /// <summary>
                /// Identificador del dataset
                /// </summary>
                public Guid Key { get; set; }

                /// <summary>
                /// Nombre del dataset
                /// </summary>
                public string Nombre { get; set; }
                /// <summary>
                /// Color del dataset
                /// </summary>
                public string Color { get; set; }
            }
        }
    }
}
