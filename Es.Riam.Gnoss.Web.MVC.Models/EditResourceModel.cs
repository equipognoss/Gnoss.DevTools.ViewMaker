using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para editar recurso.
    /// </summary>
    [Serializable]
    public partial class EditResourceModel
    {
        /// <summary>
        /// Tipo de página que se va a cargar, se debe mostrar una vista u otra en función del tipo de página.
        /// </summary>
        public TypePageEditResource TypePage { get; set; }

        /// <summary>
        /// Nombre de la pestaña actual.
        /// </summary>
        public string TabName { get; set; }

        /// <summary>
        /// Url de la pestaña actual.
        /// </summary>
        public string UrlPestanya { get; set; }

        /// <summary>
        /// Modelo para subir recurso.
        /// </summary>
        public CreateResourceModel CreateResourceModel { get; set; }

        /// <summary>
        /// Modelo para editar recurso.
        /// </summary>
        public ModifyResourceModel ModifyResourceModel { get; set; }

        /// <summary>
        /// Tipos de página para editar recurso.
        /// </summary>
        public enum TypePageEditResource
        {
            /// <summary>
            /// Página de subir recurso.
            /// </summary>
            CreateResource = 0,
            /// <summary>
            /// Página para 2º parte de subir recurso.
            /// </summary>
            CreateResource2 = 1,
            /// <summary>
            /// Página para editar recurso.
            /// </summary>
            EditResource = 2,
            /// <summary>
            /// Página para editar recurso semántico.
            /// </summary>
            CreateSemanticResource = 3,
            /// <summary>
            /// Página para editar recurso semántico.
            /// </summary>
            EditSemanticResource = 4,
            /// <summary>
            /// Página para añadir a GNOSS.
            /// </summary>
            AddToGnossResource = 5,
            /// <summary>
            /// Página para añadir a Comunidad.
            /// </summary>
            AddToCommunityResource = 6,
            /// <summary>
            /// Página de subir recurso completo.
            /// </summary>
            CreateResourceComplete = 7,
            /// <summary>
            /// Página de subir recurso completo.
            /// </summary>
            ModifyResourceComplete = 8,
        }
    }
}
