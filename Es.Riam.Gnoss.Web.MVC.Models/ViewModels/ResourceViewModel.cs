using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View Model de la pagina de un recurso
    /// </summary>
    [Serializable]
    public class ResourceViewModel
    {
        /// <summary>
        /// Recurso que queremos mostrar
        /// </summary>
        public ResourceModel Resource { get; set; }
        /// <summary>
        /// Nombre que se le ha dado al espacio personal en este ecosistema / comunidad
        /// </summary>
        public string PersonalSpace { get; set; }
        /// <summary>
        /// Url para editar el recurso
        /// </summary>
        public string UrlEdit { get; set; }
        /// <summary>
        /// Url para crear una nueva versión del recurso
        /// </summary>
        public string UrlNewVersion { get; set; }
        /// <summary>
        /// Url para ver el historial de un recurso
        /// </summary>
        public string UrlHistorial { get; set; }
        /// <summary>
        /// Indica si el usuario que ve el recurso es editor del documento
        /// </summary>
        public bool IsDocumentEditor { get; set; }
        /// <summary>
        /// Indica si el usuario tiene permiso para editar los tags
        /// </summary>
        public bool AllowEditTags { get; set; }
        /// <summary>
        /// Indica si el usuario tiene permiso para editar las categorias
        /// </summary>
        public bool AllowEditCategories { get; set; }
        /// <summary>
        /// Lista de categorias de la comunidad, se cargan al activar la accion de añadir categorias
        /// </summary>
        public List<CategoryModel> Categories { get; set; }//pasarlas a comunidadModel?
        /// <summary>
        /// Lista de bases de recursos, se carga al activar la accion de compartir
        /// </summary>
        public Dictionary<Guid, KeyValuePair<string, string>> ResourceBases { get; set; }
        /// <summary>
        /// Lista de bases de recursos, se carga al activar la accion de compartir
        /// </summary>
        public Dictionary<string, KeyValuePair<string, string>> UserComunities { get; set; }
        /// <summary>
        /// Accion que estamos realizando
        /// </summary>
        public string Action { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool PintarUtilsDoc { get; set; }

        /// <summary>
        /// Url IntraGnoss
        /// </summary>
        public string UrlIntragnoss { get; set; }

        /// <summary>
        /// Modelo del SEMCMS del recurso.
        /// </summary>
        public SemanticResourceModel SemanticFrom { get; set; }

        /// <summary>
        /// Indica si se deben ocultar las visitas.
        /// </summary>
        public bool HideWebsiteVisits { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el panel de utils del recurso.
        /// </summary>
        public bool HideUtilsResource { get; set; }

        /// <summary>
        /// Indica si se debe ocultar las comunidades donde está compartido el recurso.
        /// </summary>
        public bool HideSharedCommunities { get; set; }

        /// <summary>
        /// Lista de acciones disponibles en la vista del recurso
        /// </summary>
        public Dictionary<string, string> ListActions { get; set; }

        /// <summary>
        /// Indica si el sitio que estamos viendo permite verlo en modo palco
        /// </summary>
        public bool AllowPalco { get; set; }

        /// <summary>
        /// Id de la categoria que acabamos de crear, para poder marcarla en la vista.
        /// </summary>
        public Guid NewCategory { get; set; }

        /// <summary>
        /// Listado de versiones que tiene un determinado Recurso.
        /// </summary>
        public List<ResourceModel> HistorialRecursos { get; set; }
    }
}
