using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la home catalogo de la comunidad
    /// </summary>
    [Serializable]
    public class HomeCatalogoViewModel
    {
        public List<SectionHome> Sections { get; set; }

        /// <summary>
        /// Modelo de una seccion
        /// </summary>
        [Serializable]
        public class SectionHome
        {
            /// <summary>
            /// Tipos de vista
            /// </summary>
            public enum ResourceViewType
            {
                /// <summary>
                /// Listado
                /// </summary>
                List = 0,

                /// <summary>
                /// Mosaicp
                /// </summary>
                Grid = 1,
            }

            /// <summary>
            /// Titulo de la seccion
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Tipo de vista
            /// </summary>
            public ResourceViewType ViewType { get; set; }
            /// <summary>
            /// Lista de recursos de la seccion
            /// </summary>
            public List<ResourceModel> Resources { get; set; }
        }
    }
}
