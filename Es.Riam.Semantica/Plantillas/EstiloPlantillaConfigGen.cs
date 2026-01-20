
using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    public class EstiloPlantillaConfigGen : EstiloPlantilla
    {
        #region Propiedades

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Campo de orden que se va a utilizar en el autocompletado
        /// </summary>
        public string OrdenAutocompletar { get; set; }

        /// <summary>
        /// Tipo de orden que se va a usar en el autocompletado, true para ascendente, false para descendente
        /// </summary>
        public bool OrdenAutocompletarIsAsc { get; set; }

        /// <summary>
        /// Lista de idiomas
        /// </summary>
        public List<string> ListaIdiomas { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es titulo (Propiedad / Entidad).
        /// </summary>
        public KeyValuePair<string, string> PropiedadTitulo { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es titulo (Propiedad / Entidad).
        /// </summary>
        public Dictionary<string, string> PropiedadesTitulo { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es descripción. 
        /// </summary>
        public KeyValuePair<string, string> PropiedadDescripcion { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es imagen representante formulario. 
        /// </summary>
        public KeyValuePair<string, string> PropiedadImagenRepre { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es imagen a partir de una URL.
        /// </summary>
        public List<KeyValuePair<string, string>> PropiedadImagenFromURL { get; set; }

        /// <summary>
        /// Nombre de las propiedades que contendrán imágenes para realizar el procesado OpenSeaDragon.
        /// </summary>
        public List<KeyValuePair<string, string>> PropiedadesOpenSeaDragon { get; set; }

        /// <summary>
        /// Ontología.
        /// </summary>
        public Ontologia Ontologia { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el titulo, la descripción y la imagen en la ficha del recurso.
        /// </summary>
        public bool OcultarTituloDescpEImg { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el recruso.
        /// </summary>
        public bool OcultarRecursoAUsuarioInvitado { get; set; }

        /// <summary>
        /// Indica si debe ocultarse la fecha de la ficha del recurso.
        /// </summary>
        public bool OcultarFechaRec { get; set; }

        /// <summary>
        /// Idica si se debe ocultar la autoría.
        /// </summary>
        public bool OcultarAutoria { get; set; }

        /// <summary>
        /// Indica si debe mostrarse la fecha de la ficha del recurso.
        /// </summary>
        public bool MostrarFechaRec { get; set; }

        /// <summary>
        /// Indica si debe mostrarse el menú del recurso abajo.
        /// </summary>
        public bool? MenuDocumentoAbajo { get; set; }

        /// <summary>
        /// Categorías del tesauro por defecto para los documentos de esta plantilla.
        /// </summary>
        public List<string> CategoriasPorDefecto { get; set; }

        /// <summary>
        /// Indica si hay que ocultar el Tesauro
        /// </summary>
        public bool OcultarTesauro { get; set; }


        /// <summary>
        /// Indica si se debe incluir el icono de GNOSS o no.
        /// </summary>
        public bool IncluirIconoGnoss { get; set; }

        /// <summary>
        /// Indica si el CKEditor de comentario debe ser completo o no.
        /// </summary>
        public bool CKEditorComentariosCompleto { get; set; }

        /// <summary>
        /// Nombre de los grupos de editores que deben serlo.
        /// </summary>
        public Dictionary<string, List<string>> GruposEditoresFijos { get; set; }

        /// <summary>
        /// Nombre de los grupos de editores que deben serlo.
        /// </summary>
        public Dictionary<string, List<string>> GruposEditoresPrivacidad { get; set; }

        /// <summary>
        /// Tipo de visibilidad de la edición del recurso.
        /// </summary>
        public string TipoVisiblidadEdicionRec { get; set; }

        /// <summary>
        /// Nombre de los grupos de lectores que deben serlo.
        /// </summary>
        public Dictionary<string, List<string>> GruposLectoresFijos { get; set; }

        /// <summary>
        /// Indica si hay que usar el HTML nuevo o no.
        /// </summary>
        public short HtmlNuevo { get; set; }

        /// <summary>
        /// Indica si no es obligatorio categorizar sobre el tesauro de GNOSS.
        /// </summary>
        public bool CategorizacionTesauroGnossNoObligatoria { get; set; }

        /// <summary>
        /// Indica si no es obligatorio etiquetar un recurso semantico.
        /// </summary>
        public bool EtiquetacionGnossNoObligatoria { get; set; }

        /// <summary>
        /// Nombre de la propiedad que es archivo para la carga masiva. 
        /// </summary>
        public KeyValuePair<string, string> PropiedadArchivoCargaMasiva { get; set; }

        /// <summary>
        /// Diccionario con listas de diccionarios con las propiedades de las etiquetas HTML meta de la ontología por idioma.
        /// </summary>
        public Dictionary<string, List<Dictionary<string, string>>> MetasHTMLOntologia { get; set; }

        /// <summary>
        /// Indica si el formulario es multiidioma.
        /// </summary>
        public bool MultiIdioma { get; set; }

        /// <summary>
        /// Indexado para los bots.
        /// </summary>
        public string IndexRobots { get; set; }

        /// <summary>
        /// Titulo para los que no son miembros de la comunidad.
        /// </summary>
        public Dictionary<string, string> TituloSoloMiembros { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el publicador del recurso.
        /// </summary>
        public bool OcultarPublicadorDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse utils del recurso.
        /// </summary>
        public bool OcultarUtilsDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse las acciones del recurso.
        /// </summary>
        public bool OcultarAccionesDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse las categorías del recurso.
        /// </summary>
        public bool OcultarCategoriasDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse las etiquetas del recurso.
        /// </summary>
        public bool OcultarEtiquetasDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse los editores del recurso.
        /// </summary>
        public bool OcultarEditoresDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse los autores del recurso.
        /// </summary>
        public bool OcultarAutoresDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse las visitas del recurso.
        /// </summary>
        public bool OcultarVisitasDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse los votos del recurso.
        /// </summary>
        public bool OcultarVotosDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el compartido en del recurso.
        /// </summary>
        public bool OcultarCompartidoDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el compartido en del recurso.
        /// </summary>
        public bool OcultarCompartidoEnDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse los votos del recurso.
        /// </summary>
        public bool OcultarLicenciaDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse la versión del recurso.
        /// </summary>
        public bool OcultarVersionDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón editar del recurso.
        /// </summary>
        public bool OcultarBotonEditarDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón crear versión del recurso.
        /// </summary>
        public bool OcultarBotonCrearVersionDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón enviar enlace del recurso.
        /// </summary>
        public bool OcultarBotonEnviarEnlaceDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón vincular del recurso.
        /// </summary>
        public bool OcultarBotonVincularDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón eliminar del recurso.
        /// </summary>
        public bool OcultarBotonEliminarDoc { get; set; }

        /// <summary>
        /// Devuelve la condición que debe evaluarse para ocultar el botón eliminar del recurso.
        /// </summary>
        public string OcultarBotonEliminarDocCondicion { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón restaurar versión del recurso.
        /// </summary>
        public bool OcultarBotonRestaurarVersionDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón agregar categoría del recurso.
        /// </summary>
        public bool OcultarBotonAgregarCategoriaDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón agregar etiquetas del recurso.
        /// </summary>
        public bool OcultarBotonAgregarEtiquetasDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón historial del recurso.
        /// </summary>
        public bool OcultarBotonHistorialDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón bloquear comentarios del recurso.
        /// </summary>
        public bool OcultarBotonBloquearComentariosDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón certificar del recurso.
        /// </summary>
        public bool OcultarBotonCertificarDoc { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el botón añadir a mi espacio personal.
        /// </summary>
        public bool OcultarCompartirEspecioPersonal { get; set; }

        /// <summary>
        /// Indica si deben ocultarse los comentarios del recurso.
        /// </summary>
        public bool OcultarComentarios { get; set; }

        /// <summary>
        /// Indica si debe ocultarse el bloque de privacidad y seguridad en la edición del recurso
        /// </summary>
        public bool OcultarBloquePrivacidadSeguridadEdicion { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el bloque de compartir en la edición del recurso
        /// </summary>
        public bool OcultarBloqueCompartirEdicion { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el bloque de propiedad intelectual en la edición del recurso
        /// </summary>
        public bool OcultarBloquePropiedadIntelectualEdicion { get; set; }

        /// <summary>
        /// Indica si hay entidades seleccionables.
        /// </summary>
        public bool HayEntidadesSelecc { get; set; }

        /// <summary>
        /// Indica si hay entidades seleccionables editables desde el propio recurso.
        /// </summary>
        public bool HayEntidadesSeleccEditables { get; set; }

        /// <summary>
        /// Indica si hay valores grafodependientes.
        /// </summary>
        public bool HayValoresGrafoDependienets { get; set; }

        /// <summary>
        /// Propiedades repetidas para que se duplique el campo.
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, List<string>> PropsRepetidas { get; set; }

        /// <summary>
        /// Propiedades que son Tesauros Semánticos.
        /// </summary>
        public List<KeyValuePair<string, string>> PropiedadesTesSem { get; set; }

        /// <summary>
        /// Devuelve o establece si hay jcrop en la plantilla
        /// </summary>
        public bool HayJcrop { get; set; }

        /// <summary>
        /// Indica si hay una propiedad de fecha con hora.
        /// </summary>
        public bool HayFechaConHora { get; set; }

        /// <summary>
        /// Propiedades que debe comprobarse si están ya introduccidas en la ontología o en la comunidad.
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, KeyValuePair<bool, short>> PropsComprobarRepeticion { get; set; }

        public List<Guid> PrivadoParaGrupoEditores { get; set; }

        /// <summary>
        /// Lista con las Propiedad,Entidad de las que dependen la lista de Propiedad,Entidad.
        /// </summary>
        public Dictionary<KeyValuePair<string, string>, List<KeyValuePair<string, string>>> PropsSelecEntDependientes { get; set; }

        /// <summary>
        /// Lista con los grafos simples para autocompletar.
        /// </summary>
        public List<string> GrafosSimplesAutocompletar { get; set; }

        /// <summary>
        /// Diccionario con las propiedades que puede tener la ontología
        /// </summary>
        public Dictionary<string, string> PropiedadesOntologia { get; set; }

        /// <summary>
        /// Condiciones de la plantilla.
        /// </summary>
        public Dictionary<string, CondicionSemCms> Condiciones { get; set; }

        /// <summary>
        /// Acciones de la plantilla.
        /// </summary>
        public Dictionary<string, AccionSemCms> Acciones { get; set; }

        /// <summary>
        /// Indica si hay configurado algún campo orden en alguna entidad auxiliar.
        /// </summary>
        public bool HayCampoOrden { get; set; }

        #endregion
    }
}
