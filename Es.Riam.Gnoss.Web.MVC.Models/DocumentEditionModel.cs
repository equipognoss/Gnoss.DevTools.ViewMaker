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
    public partial class DocumentEditionModel
    {
        #region Propiedades para generar vista y para la acción guardar recurso

        /// <summary>
        /// Título del recurso.
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Descripción del recurso. En el caso de se esté enviando la descripción mediante la acción de guardar recurso, esta debe enviarse codificada.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Palabras claves que se pueden asociar a un recurso.
        /// </summary>
        public string Tags { get; set; } = "";

        /// <summary>
        /// Enlace del recurso. Según el tipo del recurso será:
        /// 
        /// Hipervinculo: Enlace a la web.
        /// Referecia a documento fisico: Ubicación del documento.
        /// Archivo fisico: Nombre del adjunto al recurso.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Indica si se puede compartir el recurso. Si es TRUE, el recurso podrá ser compartido y visto en otras comunidades del ecosistema.
        /// </summary>
        public bool ShareAllowed { get; set; }

        /// <summary>
        /// Autores del recurso. Texto en el que se especifican autores del recurso separados por coma.
        /// </summary>
        public string Authors { get; set; } = "";

        /// <summary>
        /// Indica si el recurso es borrador. Si es borrador solo podrá ser visible por el creador del recurso hasta que se publique y deje de ser borrador, entonces será visible según la configuración elegida.
        /// Este elemento se usa para generar la vista y se recoge en la acción de guardar recurso.
        /// </summary>
        public bool Draft { get; set; }

        /// <summary>
        /// Indica si el creador del recurso es el autor del mismo. Cuando se marca un recurso de esta forma, es posible editar la licencia del mismo ya que el creador es la persona que está editando el recurso y tiene derecho intelectual sobre su obra.
        /// </summary>
        public bool CreatorIsAuthor { get; set; }

        /// <summary>
        /// Licencia Creative Commons del recurso. Ségun el valor del string será una licencia u otra:
        /// "00": by
        /// "01": by-sa
        /// "02": by-nd
        /// "10": by-nc
        /// "11": by-nc-sa
        /// "12": by-nc-nd
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Indica si el documento está protegido. Si es asi, solo quien lo ha protegido podrá editarlo. Los demás editores si podrán crear una versión del mismo.
        /// </summary>
        public bool Protected { get; set; }

        #endregion

        #region Propiedades Solo Montar Vista

        /// <summary>
        /// ID del recurso. GUID que identifica el recurso actual de manera única.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Indica si el creador del recurso es la identidad actual conectada. En este caso la identidad tendrá funciones extra sobre el recurso como editar la autoría o seleccionar la licencia del recurso en caso de que éste permita licencias.
        /// </summary>
        public bool ActualIdentityIsCreator { get; set; }

        /// <summary>
        /// Etiquetas que se generan automáticamente para el título. Estas palabras clave serán sugeridas para agregarlas a los Tags del recurso.
        /// </summary>
        public string AutomaticTagsTitle { get; set; }

        /// <summary>
        /// Indica si el documento solo está compartido en un proyecto y este es privado o reservado. En caso de que sea TRUE, el panel para editar la licencia del recurso solo aparecerá en el caso de que el documento tenga la compartición permitida, además de si se indica que el creador es el autor del recurso. Si es FALSE solo se tendrá en cuenta la autoría.
        /// </summary>
        public bool SharedDocumentJustInPrivateProject { get; set; }

        /// <summary>
        /// Indica si el documento de tipo Wiki posee un autoguardado que se puede recuperar. El usuario seleccionará si lo recupera o no.
        /// </summary>
        public bool AutosaveAvailable { get; set; }

        /// <summary>
        /// Url que permite recuperar un autoguardado de un Wiki en el caso en el que exista. Si el usuario elige recurperar el autoGuardado habría que llevarle a esta Url.
        /// </summary>
        public string UrlRecoverAutosave { get; set; }



        /// <summary>
        /// Indica si el recurso es privado para editores. Si es así, solo los editores y lectores del recurso podrán ver el recurso.
        /// </summary>
        public bool PrivateEditors { get; set; }

        /// <summary>
        /// Información acerca de quien ha protegido el recurso si así es: Nombre del protector, Fecha protección.
        /// </summary>
        public KeyValuePair<string, string> ProtectionInfo { get; set; }

        /// <summary>
        /// Indica si la modificación de la protección del recurso está disponible para el usuario actual.
        /// </summary>
        public bool ModificationProtectionAvailable { get; set; }

        /// <summary>
        /// Url de descarga del archivo adjunto al recurso.
        /// </summary>
        public string UrlDownloadAttached { get; set; }

        /// <summary>
        /// Indica si el recurso permite tener licencia. Si es así, y el usuario marca que es el autor del recurso aparecerá el editor de licencia.
        /// </summary>
        public bool AllowsLicense { get; set; }

        #endregion

        #region Propiedades para la acción guardar recurso

        /// <summary>
        /// Indica si se deben omitir las alertas por repetición de atributos del recurso actual y el cambio de privacidad que impiden guardar.
        /// Debería adquirir el valor TRUE cuando el usuario acepte la advertencia.
        /// </summary>
        public bool SkipRepeat { get; set; }

        /// <summary>
        /// Indica si se va a hacer una redirección por concurrencia. Se debe producir cuando dos usuarios está editando el mismo recurso a la vez y el 2º usuario elige que quiere sobrescribir el mismo.
        /// </summary>
        public bool? RedirectionByConcurrency { get; set; }

        /// <summary>
        /// Indica si se va a crear una versión a causa de concurrencia. Se debe producir cuando dos usuarios está editando el mismo recurso a la vez y el 2º usuario elige que quiere crear una nueva versión del mismo.
        /// </summary>
        public bool? CreateVersionByConcurrency { get; set; }

        /// <summary>
        /// Indica si el guardado que se está haciendo es un autoGuardado de Wiki.
        /// </summary>
        public bool? AutoSave { get; set; }

        /// <summary>
        /// Nombre del adjunto temporal previamente subido al recurso. Debe comenzar por un GUID aleatorio seguido del nombre del fichero (Ej: Si tenemos el fichero "prueba.txt" será "f5e51472-1e3d-47d3-b035-f8170cef3da3prueba.txt".
        /// </summary>
        public string TemporalFileName { get; set; }

        /// <summary>
        /// Categorías del tesauro seleccionadas. Deberá contener los GUIDs de las categorías separadas por comas.
        /// </summary>
        public string SelectedCategories { get; set; }

        /// <summary>
        /// Indica si los editores del recurso son unos especificados (TRUE) o si es el publicador del recurso (FALSE).
        /// </summary>
        public bool SpecificResourceEditors { get; set; }

        /// <summary>
        /// Editores específicos del recurso separados por comas.
        /// Los editores pueden ser perfiles o grupos.
        /// Para el perfil editor se guardará un GUID con el ID del perfil y en el caso de un grupo, el GUID de grupo editor precedido de los caracteres "g_" (Ej: "g_f5e51472-1e3d-47d3-b035-f8170cef3da3").
        /// </summary>
        public string ResourceEditors { get; set; }

        /// <summary>
        /// Visibilidad del recurso en la comunidad.
        /// </summary>
        public ResourceVisibility ResourceVisibility { get; set; }

        /// <summary>
        /// Lectores específicos del recurso separados por comas.
        /// Los lectores pueden ser perfiles o grupos.
        /// Para el perfil lector se guardará un GUID con el ID del perfil y en el caso de un grupo, el GUID de grupo lector precedido de los caracteres "g_" (Ej: "g_f5e51472-1e3d-47d3-b035-f8170cef3da3").
        /// </summary>
        public string ResourceReaders { get; set; }

        /// <summary>
        /// Indica si se debe crear una nueva versión del recurso a causa de que el documento tiene un adjunto, tiene varios editores, el editor actual ha reemplazado el archivo y tras aparecerle un mensaje indicandole que no es el único editor del recuro ha dedicido crear una nueva versión.
        /// </summary>
        public bool CreateVersionByReplaceAttachment { get; set; }

        /// <summary>
        /// Enlaces automáticos que se generar para los tags separados por "&&&".
        /// </summary>
        public string TagsLinks { get; set; }

        /// <summary>
        /// Indica si la Newsletter es manual, es decir con texto plano rellenado por el usuario en la descripción. En caso de ser FALSE, indica que se ha subido un archivo de html como adjunto a la Newsletter.
        /// </summary>
        public bool NewsletterManual { get; set; }

        /// <summary>
        /// Indica si se quiere proteger la nueva versión de un documento que ser va a crear porque el original estaba previamente protegido.
        /// </summary>
        public bool? ProtectDocumentProtected { get; set; }

        /// <summary>
        /// Respuestas de la encuesta separadas por "[[&]]".
        /// </summary>
        public string PollResponses { get; set; }

        /// <summary>
        /// Valor RDF del recurso en un formato especial para el guardado GNOSS. Solo se aplica a recursos de tipo semántico.
        /// </summary>
        public string RdfValue { get; set; }

        /// <summary>
        /// Valor de la imagen representante del recurso. Contendrá la url de la imagen con sus tamaños. Solo se aplica a recursos de tipo semántico.
        /// </summary>
        public string ImageRepresentativeValue { get; set; }

        /// <summary>
        /// Indica si se deben omitir las alertas por repetición de los valores de las propiedades configuradas en el XML de la ontología como de único valor.
        /// Debería adquirir el valor TRUE cuando el usuario acepte la advertencia.
        /// </summary>
        public bool SkipSemanticPropertyRepeat { get; set; }

        /// <summary>
        /// ID del recurso masivo que se está editando dentro de una carga masiva.
        /// </summary>
        public Guid EditingMassiveResourceID { get; set; }

        /// <summary>
        /// Información auxiliar acerca de los recursos masivos que se están editando dentro de una carga masiva.
        /// </summary>
        public string MassiveResourceLoadInfo { get; set; }

        /// <summary>
        /// Información de las imágenes con su ancho y alto separados por '|' para procesarlas con OpenSeaDragon.
        /// </summary>
        public string OpenSeaDragonInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de las ontologías externas editables dentro del recurso para la edición del SEM CMS.
        /// </summary>
        public string SubOntologiesExtInfo { get; set; }

        /// <summary>
        /// Información auxiliar con los IDs de las entidades en la edición del SEM CMS.
        /// </summary>
        public string EntityIDRegisterInfo { get; set; }

        #endregion
    }
}
