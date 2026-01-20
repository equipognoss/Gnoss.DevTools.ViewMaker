using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para subir recurso.
    /// </summary>
    [Serializable]
    public partial class CreateResourceModel
    {
        /// <summary>
        /// Lista con los nombres url de las ontologías disponibles para subir recurso.
        /// </summary>
        public SortedDictionary<string, KeyValuePair<string, string>> OntologyNameUrls { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de ficheros.
        /// </summary>
        public bool FileAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de referencias a recursos.
        /// </summary>
        public bool DocumentReferenceAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de hipervinculos.
        /// </summary>
        public bool LinkAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de videos de BrightCove.
        /// </summary>
        public bool BrightcoveVideoAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de videos de Top.
        /// </summary>
        public bool TOPVideoAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de notas.
        /// </summary>
        public bool NoteAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de wikis.
        /// </summary>
        public bool WikiAvailable { get; set; }

        /// <summary>
        /// Indica si está disponible la subida de semánticos.
        /// </summary>
        public bool SemanticResourceAvailable { get; set; }

        /// <summary>
        /// Src para el iframe que se genera para Brightcove.
        /// </summary>
        public string SrcIframeBrightcove { get; set; }

        /// <summary>
        /// Url para video que se genera para Brightcove y TOP.
        /// </summary>
        public string UrlVideoIframe { get; set; }

        /// <summary>
        /// Url para audio que se genera para Brightcove y TOP.
        /// </summary>
        public string UrlAudioIframe { get; set; }

        /// <summary>
        /// Src para el iframe que se genera para TOP.
        /// </summary>
        public string SrcIframeTOP { get; set; }
    }
}
