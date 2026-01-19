using Es.Riam.Semantica.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.Plantillas
{
    /// <summary>
    /// Selector de una entidad como valor de una propiedad.
    /// </summary>

    [Serializable]
    public class SelectorEntidad
    {

        /// <summary>
        /// Url de la entiad contenedora de la instancia buscada.
        /// </summary>
        public string UrlEntContenedora { get; set; }

        /// <summary>
        /// Url de la propiedad para la consulta
        /// </summary>
        public string UrlPropiedad {  get; set; }

        /// <summary>
        /// Url del tipo de entidad solicitada.
        /// </summary>
        public string UrlTipoEntSolicitada { get; set; }
       
        /// <summary>
        /// Propiedades para llenar el combo.
        /// </summary>
        public List<string> PropiedadesEdicion {  get; set; }

        /// <summary>
        /// Propiedades que se mostrarán en la vista previa del formulario.
        /// </summary>
        public List<EstiloPlantillaEspecifProp> PropiedadesLectura { get; set; }

        /// <summary>
        /// Grafo de la entidad solicitada.
        /// </summary>
        public string Grafo {  get; set; }

        /// <summary>
        /// Namespace del grafo de la entidad solicitada.
        /// </summary>
        public string NamespaceGrafo { get; set; }

        /// <summary>
        /// Texto para el 1º elemento de la selección.
        /// </summary>
        public string TextoElemento0 {  get; set; }

        /// <summary>
        /// Tipo de presentación.
        /// </summary>
        public string TipoPresentacion {  get; set; }

        /// <summary>
        /// Tipo de selector.
        /// </summary>
        public string TipoSeleccion {  get; set; }

        public bool Cache { get; set; }

        /// <summary>
        /// Indica si el selecctor es multiidioma o no.
        /// </summary>
        public bool MultiIdioma { get; set; }

        /// <summary>
        /// Tipo de selector.
        /// </summary>
        public bool AnidamientoGnoss {  get; set; }

        /// <summary>
        /// Indica si la entidad debe ser un link al recurso que la contiene.
        /// </summary>
        public bool LinkARecurso { get; set; }

        /// <summary>
        /// Indica el tipo de entidades en las que se aplica LinkARecurso.
        /// </summary>
        public List<string> TipoEntLinkARecurso { get; set; }

        /// <summary>
        /// Indica las propiedades en las que se aplica LinkARecurso.
        /// </summary>
        public List<string> PropLinkARecurso { get; set; }

        /// <summary>
        /// Indica si el link a recurso debe llevar a la comunidad actual o no.
        /// </summary>
        public bool LinkARecursoVaAComunidad {  get; set; }

        /// <summary>
        /// Atributos de un recurso.
        /// </summary>
        public List<string> AtributosRecurso { get; set; }

        /// <summary>
        /// Indica si el link al recurso que la contiene debe abrirse en una nueva pestaña.
        /// </summary>
        public bool NuevaPestanya {  get; set; }

        /// <summary>
        /// Indica si la relación de entidades externas es recíproca.
        /// </summary>
        public bool Reciproca {  get; set; }

        /// <summary>
        /// Propiedad por la que se debe ordenar la consulta recíproca y el tipo de orden.
        /// </summary>
        public KeyValuePair<string, string> PropOrdenRecipocidad { get; set; }

        /// <summary>
        /// Indica el nombre de la propiedad que tendrán las entidades externas recíprocas.
        /// </summary>
        public string PropiedadReciproca {  get; set; }

        /// <summary>
        /// Indica el nombre de la propiedad de la entidad externa que enlaza con la edición de la propiedad actual.
        /// </summary>
        public string PropiedadEdicionReciproca { get; set; }

        /// <summary>
        /// Indica el tipo de la entidad externa que enlaza con la edición de la propiedad actual.
        /// </summary>
        public string EntidadEdicionReciproca { get; set; }

        /// <summary>
        /// Consulta para obtener las entidades externas recíprocas.
        /// </summary>
        public string ConsultaReciproca { get; set; }

        /// <summary>
        /// Consulta para obtener las entidades externas.
        /// </summary>
        public string Consulta {  get; set; }

        /// <summary>
        /// Consulta de edición para obtener las entidades externas.
        /// </summary>
        public string ConsultaEdicion { get; set; }

        /// <summary>
        /// Cadena extra del where de la consulta de autocompletar para obtener las entidades externas.
        /// </summary>
        public string ExtraWhereAutocompletar { get; set; }

        /// <summary>
        /// Cadenas extra de extra del where de la consulta de autocompletar para obtener las entidades externas.
        /// </summary>
        public List<string> ExtraWhereAutocompletarExtras { get; set; }

        /// <summary>
        /// Mensaje para mostrar cuando no hay resultados en la selección de entidad.
        /// </summary>
        public string MensajeNoResultados { get; set; }

        /// <summary>
        /// Número de elementos por página para el selector de entidad.
        /// </summary>
        public int NumElemPorPag {  get; set; }

        /// <summary>
        /// Ruta de la vista personalizada para la paginación en caso de que la haya.
        /// </summary>
        public string VistaPersonalizadaPaginacion { get; set; }

        /// <summary>
        /// Consulta que se debe ejecutar para obtener los sujetos que cumplen la dependecia del selector.
        /// </summary>
        public string ConsultaDependiente { get; set; }

        /// <summary>
        /// ID y Tipo de entidad de la propiedad de la que depende el selector.
        /// </summary>
        public KeyValuePair<string, string> PropiedadDeLaQueDepende {  get; set; }

        /// <summary>
        /// Indica si los contenidos relacionados se mostrarán únicamente en el idioma de navegación del usuario
        /// </summary>
        public bool SoloIdiomaUsuario { get; set; }
    }
}
