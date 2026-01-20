using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    /// <summary>
    /// Elemento propiedad o grupo de propiedades ordenado.
    /// </summary>
    /// 
    public class ElementoOrdenado 
    {
        /// <summary>
        /// Indica si es grupo o no.
        /// </summary>
        public bool EsGrupo { get; set; }

        /// <summary>
        /// Propiedades del elemento.
        /// </summary>
        public Propiedad Propiedad { get; set; }

        /// <summary>
        /// Nombre de las propiedades del elemento.
        /// </summary>
        public KeyValuePair<string, Propiedad> NombrePropiedad { get; set; }

        /// <summary>
        /// Clase del grupo.
        /// </summary>
        public string ClaseGrupo { get; set; }

        /// <summary>
        /// ID para el grupo.
        /// </summary>
        public string IdGrupo { get; set; }

        /// <summary>
        /// Clase del grupo para la lectura.
        /// </summary>
        public string ClaseGrupoLectura { get; set; }

        /// <summary>
        /// ID para el grupo para la lectura.
        /// </summary>
        public string IdGrupoLectura { get; set; }

        /// <summary>
        /// Propiedad de entidad hija (tipo entidad hija).
        /// </summary>
        public string PropDeEntHija { get; set; }

        /// <summary>
        /// Indica que solo debe pintarse el 1º valor de la propiedad.
        /// </summary>
        public bool SoloPrimerValor { get; set; }

        /// <summary>
        /// Hijo del grupo
        /// </summary>
        public List<ElementoOrdenado> Hijos { get; set; }

        /// <summary>
        /// Tipo de grupo.
        /// </summary>
        public string TipoGrupo { get; set; }

        /// <summary>
        /// Indica si es literal.
        /// </summary>
        public bool EsLiteral { get; set; }

        /// <summary>
        /// Indica si es literal es importante y debe pintarse siempre.
        /// </summary>
        public bool LiteralImportante { get; set; }

        /// <summary>
        /// Indica si es un especial.
        /// </summary>
        public bool EsEspecial { get; set; }

        /// <summary>
        /// Datos del elemento especial.
        /// </summary>
        public Dictionary<string, object> DatosEspecial { get; set; }

        /// <summary>
        ///Indica si es un selector de grupo.
        /// </summary>
        public bool EsSelectorGrupo { get; set; }

        /// <summary>
        /// Opciones de selector de grupo.
        /// </summary>
        public Dictionary<string, string> OpcionesSelectorGrupo { get; set; }

        /// <summary>
        /// Indica que no se debe pintar el título.
        /// </summary>
        public bool SinTitulo { get; set; }

        /// <summary>
        /// Tipo de presentación.
        /// </summary>
        public string TipoPresentacion { get; set; }

        /// <summary>
        /// Elemento padre.
        /// </summary>
        public ElementoOrdenado ElementoPadre { get; set; }

        /// <summary>
        /// Link a otro lugar.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Target del link a otro lugar.
        /// </summary>
        public string TargetLink { get; set; }

        /// <summary>
        /// Size de la foto.
        /// </summary>
        public string SizeFoto { get; set; }

        /// <summary>
        /// Size de la foto.
        /// </summary>
        public string SizeAumentoFoto { get; set; }

        /// <summary>
        /// Mensaje de ayuda del campo.
        /// </summary>
        public string MensajeAyuda { get; set; }

        /// <summary>
        /// Indica si una propiedad solo debe mostrar su valor en el idioma de navegación del usuario o no mostrarlo.
        /// </summary>
        public bool SoloIdiomaNavegacion { get; set; }

        /// <summary>
        /// Indica que el elemento no es editable en la vista de edición.
        /// </summary>
        public bool? NoEditable { get; set; }

        /// <summary>
        /// Propiedades con sus valores según los cuales debe o no pintarse una entidad.
        /// </summary>
        public Dictionary<string, KeyValuePair<bool, List<string>>> PropsCondicionPintarEntSegunValores { get; set; }
    }
}
