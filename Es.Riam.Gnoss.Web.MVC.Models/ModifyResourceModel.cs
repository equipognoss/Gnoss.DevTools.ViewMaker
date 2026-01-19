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
    public partial class ModifyResourceModel
    {
        /// <summary>
        /// Modelo superior de edición de recurso.
        /// </summary>
        public EditResourceModel EditResourceModel { get; set; }

        /// <summary>
        /// Indica el sitio actual de la página para un subMenu.
        /// </summary>
        public string CurrentSiteMenuPulg { get; set; }

        /// <summary>
        /// Tipo de documento que se está modificando.
        /// </summary>
        public Es.Riam.Gnoss.Web.MVC.Models.ResourceModel.DocumentType DocumentType { get; set; }

        /// <summary>
        /// Indica si es presentación incrustada.
        /// </summary>
        public bool ItIsEmbeddedPresentation { get; set; }

        /// <summary>
        /// Indica si es video incrustado.
        /// </summary>
        public bool ItIsEmbeddedVideo { get; set; }

        /// <summary>
        /// Modelo de documento de edición.
        /// </summary>
        public DocumentEditionModel DocumentEditionModel { get; set; }

        /// <summary>
        /// Editor del tesauro actual.
        /// </summary>
        public ThesaurusEditorModel ThesaurusEditorModel { get; set; }

        /// <summary>
        /// Indica si la autoría del recurso está disponible.
        /// </summary>
        public bool CopyrightAvailable { get; set; }

        /// <summary>
        /// Indica si la edición del adjunto del recurso está disponible.
        /// </summary>
        public bool EditAttachedAvailable { get; set; }

        /// <summary>
        /// Indica si la edición de las propiedades del recurso está disponible.
        /// </summary>
        public bool EditPropertiesAvailable { get; set; }

        /// <summary>
        /// Indica si la edición del fichero del recurso está disponible.
        /// </summary>
        public bool EditFileAvailable { get; set; }

        /// <summary>
        /// Indica si la edición de la ubicación del recurso está disponible.
        /// </summary>
        public bool EditLocationAvailable { get; set; }

        /// <summary>
        /// Indica si la edición de la url del recurso está disponible.
        /// </summary>
        public bool EditUrlAvailable { get; set; }

        /// <summary>
        /// Indica si la edición del título del recurso está disponible.
        /// </summary>
        public bool EditTitleAvailable { get; set; }

        /// <summary>
        /// Indica si la edición de la descripción del recurso está disponible.
        /// </summary>
        public bool EditDescriptionAvailable { get; set; }

        /// <summary>
        /// Indica si la edición de las respuestas de las encuestas está disponible.
        /// </summary>
        public bool EditPollAnswersAvailable { get; set; }

        /// <summary>
        /// Indica si se está creando una versión del documento.
        /// </summary>
        public bool CreatingVersion { get; set; }

        /// <summary>
        /// Indica si hay multiples usuarios editando el recurso. En caso de ser TRUE se le debe presentar al usuario un mensaje advirtiendole de ello en el caso de que el recurso tenga un adjunto y se reemplece éste.
        /// </summary>
        public bool MultipleEditors { get; set; }

        /// <summary>
        /// Indica si se permite que los recursos sean privados.
        /// </summary>
        public bool PrivateResourcesAvailable { get; set; }

        /// <summary>
        /// Indica si se permiten lectores de comunidad.
        /// </summary>
        public bool CommunityReadersAvailable { get; set; }

        /// <summary>
        /// Indica si se permite que los recursos sean abiertos.
        /// </summary>
        public bool OpenResourcesAvailable { get; set; }

        /// <summary>
        /// Modelo para el selector de usuario para edición.
        /// </summary>
        public UsersSelectorModel UsersSelectorEditionModel { get; set; }

        /// <summary>
        /// Modelo para el selector de usuario para lectra.
        /// </summary>
        public UsersSelectorModel UsersSelectorReadingModel { get; set; }

        /// <summary>
        /// Indica que la visibilidad actual del recurso es para miembros de la comunidad. En función de esta visibilidad, de si el recurso es privado para editores y de si la comunidad permite recursos abiertos, se calculará la visibilidad actual del recurso.
        /// </summary>
        public bool VisibilityMembersCommunity { get; set; }

        /// <summary>
        /// Indica si se permite que se pueda editar los permisos de edición del recurso.
        /// </summary>
        public bool SetPermissionsEditionAvailable { get; set; }

        /// <summary>
        /// Indica si se permite el selector de editores dentro de la configuráción de permisos de edición.
        /// </summary>
        public bool SelectorEditionAvailable { get; set; }

        /// <summary>
        /// Indica si se permite la protección del recurso.
        /// </summary>
        public bool ResourceProtectionAvailable { get; set; }

        /// <summary>
        /// Indica si las propiedades del recurso están disponibles
        /// </summary>
        public bool ResourcePropertiesAvailable { get; set; }

        /// <summary>
        /// Indica si compartir está disponible.
        /// </summary>
        public bool ShareAvailable { get; set; }

        /// <summary>
        /// Modelo para la edición de licencias.
        /// </summary>
        public LicenseEditorModel LicenseEditorModel { get; set; }

        /// <summary>
        /// Nombre del adjunto al recurso subido por un addin como el de Office o Añadir a Gnoss.
        /// </summary>
        public string UploadedAttachedNameByAddin { get; set; }

        /// <summary>
        /// Url para el botón cancelar.
        /// </summary>
        public string UrlCancelButton { get; set; }

        /// <summary>
        /// Url para el botón ir a la home.
        /// </summary>
        public string UrlGoHomeButton { get; set; }

        /// <summary>
        /// Modelo de respuestas para la encuesta.
        /// </summary>
        public PollAnswersModel PollAnswersModel { get; set; }

        /// <summary>
        /// Modelo para editar recursos semánticos. Solo aplica a recursos semánticos.
        /// </summary>
        public SemanticResourceModel SemanticResourceModel { get; set; }

        /// <summary>
        /// Lista con los IDs y nombres de las bases de recursos donde se puede compartir un recurso add to Gnoss.
        /// </summary>
        public Dictionary<Guid, string> AddToGnossShareSites { get; set; }

        /// <summary>
        /// Mensjae que indica que hay una nueva versión del add to Gnoss disponible.
        /// </summary>
        public string NewVersionMessageAddToGnossAvailable { get; set; }

        /// <summary>
        /// Mensjae que indica que hay una nueva versión del adding de Office disponible.
        /// </summary>
        public string NewVersionMessageAddToGnossOfficeAvailable { get; set; }

        /// <summary>
        /// Token del vídeo top
        /// </summary>
        public string TOPTokenID { get; set; }

        /// <summary>
        /// Tipo de documento que es el vídeo/audio del tipo top
        /// </summary>
        public int TOPDocType { get; set; }

        /// <summary>
        /// URL SRC del iframe del vídeo / audio top
        /// </summary>
        public string TOPIframeSRC { get; set; }

        /// <summary>
        /// Subida unificada
        /// </summary>
        public bool SubidaUnificada { get; set; }

        /// <summary>
        /// Edicion unificada.
        /// </summary>
        public bool EdicionUnificada { get; set; }

        /// <summary>
        /// Lista de los recursos vinculados.
        /// </summary>
        public List<String> Vinculados { get; set; }
    }
}
