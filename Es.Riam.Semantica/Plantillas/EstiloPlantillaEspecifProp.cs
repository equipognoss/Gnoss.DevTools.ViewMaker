using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    public class EstiloPlantillaEspecifProp : EstiloPlantilla
    {
        /// <summary>
        /// Nombre de la entidad.
        /// </summary>
        public string NombreEntidad {  get; set; }


        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public string NombreRealPropiedad { get; set; }

        /// <summary>
        /// Tipo del campo de la propiedad que puede ser null. 
        /// Se usa para poder deserializar TipoCampo.
        /// </summary>
        public TipoCampoOntologia? TipoCampoSetter { get; set; }

        /// <summary>
        /// Valor del tipo del campo de la propiedad. 
        /// Se usa para poder obtener el valor de TipoCampo al deserializar.
        /// </summary>
        public int TipoCampoINT {  get; set; }

        /// <summary>
        /// Tipo del campo de la propiedad.
        /// </summary>
        public TipoCampoOntologia? TipoCampo {  get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TieneValor_TipoCampo { get; set; }

        /// <summary>
        /// Propiedad ontológica.
        /// </summary>
        public Propiedad Propiedad { get; set; }

        /// <summary>
        /// Comprueba si deben mostrarse checks y radioButtoms para una propiedad.
        /// </summary>
        public bool EsPropiedadConValoresCheck {  get; set; }

        /// <summary>
        /// Devuelve o establece la lista de valores permitidos de la propiedad (One Of).
        /// </summary>
        public List<string> ListaValoresPermitidos { get; set; }

        /// <summary>
        /// Contiene el valor por defecto que debe tener la propiedad, pero que no es correcto para la misma (Ej: valor gris combo).
        /// </summary>
        public string ValorDefectoNoSeleccionable { get; set; }

        /// <summary>
        /// Restricción del número de caracteres.
        /// </summary>
        public RestriccionNumCaracteres RestrNumCaract {  get; set; }

        /// <summary>
        /// Texto que se debe mostrar a la hora de eliminar un elemento seleccionado.
        /// </summary>
        public string TextoEliminarElemSel {  get; set; }

        /// <summary>
        /// Establece si la imagen se recorta con jCrop.
        /// </summary>
        public bool UsarJcrop { get; set; }

        /// <summary>
        /// Anchura y altura mínimas para el recorte del Jcrop. Por defecto es '75,75'.
        /// </summary>
        public KeyValuePair<int, int> MinSizeJcrop { get; set; }

        /// <summary>
        /// Anchura y altura máximas para el recorte del Jcrop. No hay máximo por defeto.
        /// </summary>
        public KeyValuePair<int, int> MaxSizeJcrop { get; set; }

        /// <summary>
        /// Imagen mini de la propiedad.
        /// </summary>
        public ImagenMini ImagenMini { get; set; }

        /// <summary>
        /// Parametros de galería si la propiedad debe ser una galería de imágenes, NULL en caso contrario.
        /// </summary>
            public string GaleriaImagenes { get; set; }

        /// <summary>
        /// Propiedad ancho y propiedad alto para procesar OpenSeaDragon en el caso de que lo tenga.
        /// </summary>
        public KeyValuePair<string, string> OpenSeaDragon {  get; set; }

        /// <summary>
        /// Clase CSS para el título de la propiedad.
        /// </summary>
        public string ClaseCssPanelTitulo { get; set; }

        /// <summary>
        /// Nombre del tag para el título en edición.
        /// </summary>
        public string TagNameTituloEdicion {  get; set; }

        /// <summary>
        /// Nombre del tag para el título en lectura.
        /// </summary>
        public string TagNameTituloLectura { get; set; }

        /// <summary>
        /// Nombre de la propiedad en edición.
        /// </summary>
        public Dictionary<string, string> AtrNombre {  get; set; }
        /// <summary>
        /// Si la propiedad puede o no permitir scripts para evitar xss
        /// </summary>
        public bool PermitirScript { get; set; }
        /// <summary>
        /// Nombre de la propiedad en lectura.
        /// </summary>
        public Dictionary<string, string> AtrNombreLectura { get; set; }

        /// <summary>
        /// Nombre de la propiedad en edición.
        /// </summary>
        public string Nombre {  get; set; }

        /// <summary>
        /// Nombre de la propiedad en edición.
        /// </summary>
        public string NombreLectura { get; set; }

        /// <summary>
        /// Indica que los valores de la propiedad se introducirán separados por comas.
        /// </summary>
        public bool ValoresSepComas { get; set; }

        /// <summary>
        /// Indica que los valores de la propiedad se introducirán separados por comas.
        /// </summary>
        public bool ValoresSepComasAlmacenado { get; set; }

        /// <summary>
        /// Indica si el formato de la fecha es mes-año.
        /// </summary>
        public bool FechaMesAnio { get; set; }

        /// <summary>
        /// Indica si el formato de la fecha es libre, para introducir lo que quieras.
        /// </summary>
        public bool FechaLibre {  get; set; }

        /// <summary>
        /// Indica si el formato de la fecha debe incluir la hora.
        /// </summary>
        public bool FechaConHora { get; set; }

        /// <summary>
        /// Indica si la fecha debe guardarse en formato entero (26/11/2011 14:18:20 -> 20111126141820).
        /// </summary>
        public bool GuardarFechaComoEntero { get; set; }

        /// <summary>
        /// Valor del grafo autocompletar del campo.
        /// </summary>
        public string GrafoAutocompletar {  get; set; }

        /// <summary>
        /// Valor del tipo de resultado autocompletar del campo.
        /// </summary>
        public string TipoResulAutocompletar { get; set; }

        /// <summary>
        /// Indica si se deben guardasr los nuevos valores para proximas llamadas a autocompletar.
        /// </summary>
        public bool GuardarValoresAutocompletar { get; set; }

        /// <summary>
        /// Indica si no se deben permitir los nuevos valores que no devuelva el autocompletar.
        /// </summary>
        public bool NoPermitirNuevosValores { get; set; }

        /// <summary>
        /// Tipo de campo para lectura.
        /// </summary>
        public string TipoCampoLectura { get; set; }

        /// <summary>
        /// Indica si el campo debe aparecer deshabilitado.
        /// </summary>
        public bool CampoDeshabilitado { get; set; }

        /// <summary>
        /// Clase CSS para el campo de la propiedad.
        /// </summary>
        public string ClaseCss { get; set; }

        /// <summary>
        /// Texto para el botón de agregar elemento.
        /// </summary>
        public string TextoAgregarElem { get; set; }

        /// <summary>
        /// Texto para el botón de guardar elemento.
        /// </summary>
        public string TextoBotonAceptarElemento { get; set; }

        /// <summary>
        /// Indica is hay que mostrar la vista previa de la propiedad en edición.
        /// </summary>
        public bool VistaPrevEnEdicion {  get; set; }

        /// <summary>
        /// Clase panel contenedor css.
        /// </summary>
        public string ClaseCssPanel { get; set; }

        /// <summary>
        /// Texto para el botón de cancelar elemento.
        /// </summary>
        public string TextoCancelarElem { get; set; }

        /// <summary>
        /// Texto para el botón de editar elemento.
        /// </summary>
        public string TextoEdicionEntSel {  get; set; }

        /// <summary>
        /// Valor de microdatos.
        /// </summary>
        public string Microdatos {  get; set; }

        /// <summary>
        /// Valor de CapturarFlash.
        /// </summary>
        public KeyValuePair<string, string> CapturarFlash { get; set; }

        /// <summary>
        /// Valor del Html plantilla para el objeto incrustado.
        /// </summary>
        public string HtmlObjeto {  get; set; }

        /// <summary>
        /// Valor de microformatos.
        /// </summary>
        public Dictionary<string, string> Microformatos { get; set; }

        /// <summary>
        /// Selector de entidad.
        /// </summary>
        public SelectorEntidad SelectorEntidad { get; set; }

        /// <summary>
        /// Link que debe tener el valor de la propiedad.
        /// </summary>
        public string UrlLinkDelValor { get; set; }

        /// <summary>
        /// Indica si el link al recurso que la contiene debe abrirse en una nueva pestaña.
        /// </summary>
        public bool NuevaPestanya { get; set; }

        /// <summary>
        /// Nombre del grafo del que dependen el valor de la propiedad.
        /// </summary>
        public string GrafoDependiente { get; set; }

        /// <summary>
        /// Tipo de la entidad de la que dependen el valor de la propiedad.
        /// </summary>
        public string TipoEntDependiente { get; set; }

        /// <summary>
        /// ID y tipo de entidad de la propiedad cuyo valor condiciona el de la actual que dependen el valor de la propiedad.
        /// </summary>
        public KeyValuePair<string, string> PropDependiente { get; set; }

        /// <summary>
        /// Tipo del campo (Autocompletar, combo).
        /// </summary>
        public string TipoDependiente { get; set; }

        /// <summary>
        /// Lista con las propiedades auxiliares de la propiedad.
        /// </summary>
        public List<EstiloPlantillaEspecifProp> PropiedadesAuxiliares { get; set; }

        /// <summary>
        /// Elemento ordenado auxiliar de la propiedad.
        /// </summary>
        public ElementoOrdenado ElementoOrdenadoAuxiliar { get; set; }

        /// <summary>
        /// Valor por defecto para la propiedad.
        /// </summary>
        public string ValorPorDefecto { get; set; }

        /// <summary>
        /// Expresión regular para aplicar al valor de una propiedad.
        /// </summary>
        public string ExpresionRegular {  get; set; }

        /// <summary>
        /// Indica si solo se debe mostrar la primera coincidencia de la expresión regular.
        /// </summary>
        public bool PrimeraCoincidenciaExpresionRegular { get; set; }

        /// <summary>
        /// Indica si NO hay multiIdioma.
        /// </summary>
        public bool NoMultiIdioma { get; set; }

        /// <summary>
        /// Indica que es privada para los miembros de la comunidad.
        /// </summary>
        public bool PrivadoPrivadoParaMiembrosComunidad { get; set; }

        public List<Guid> PrivadoParaGrupoEditores { get; set; }

        /// <summary>
        /// Número de elementos por página para la paginación de las entidades auxiliares de la propiedad.
        /// </summary>
        public int NumElemPorPag {  get; set; }

        /// <summary>
        /// Ruta de la vista personalizada para la paginación en caso de que la haya.
        /// </summary>
        public string VistaPersonalizadaPaginacion { get; set; }

        /// <summary>
        /// Indica que es un selector de entidad dentro de otro selector de entidad. NO SE AGREGA AL CONSTRUCTOR.
        /// </summary>
        public bool EsSelectorEntidadInterno { get; set; }
    }

}
