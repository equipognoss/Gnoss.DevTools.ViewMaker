using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    /// <summary>
    /// Clase para gestionar los estilos de un elemento de la plantilla.
    /// </summary>
    [Serializable]
    public class EstiloPlantillaEspecifEntidad : EstiloPlantilla
    {
        /// <summary>
        /// Entidad.
        /// </summary>
        public ElementoOntologia Entidad { get; set; }

        /// <summary>
        /// Lista elementos ordenados.
        /// </summary>
        public List<ElementoOrdenado> ElementosOrdenados { get; set; }

        /// <summary>
        /// Lista elementos ordenados para la lectura.
        /// </summary>
        public List<ElementoOrdenado> ElementosOrdenadosLectura { get; set; }

        /// <summary>
        /// Lista elementos ordenados.
        /// </summary>
        public Dictionary<string, List<ElementoOrdenado>> ElementosOrdenadosPorCondicion { get; set; }

        /// <summary>
        /// Lista elementos ordenados para la lectura.
        /// </summary>
        public Dictionary<string, List<ElementoOrdenado>> ElementosOrdenadosLecturaPorCondicion { get; set; }

        /// <summary>
        /// Atribrutos representantes de la entidad.
        /// </summary>
        public List<Representante> AtrRepresentantes { get; set; }

        /// <summary>
        /// Representantes de la entidad.
        /// </summary>
        public List<Representante> Representantes { get; set; }

        /// <summary>
        /// Clase CSS para el panel de la entidad.
        /// </summary>
        public string ClaseCssPanel { get; set; }

        /// <summary>
        /// Clase CSS para el título de la entidad.
        /// </summary>
        public string ClaseCssPanelTitulo { get; set; }

        /// <summary>
        /// Nombre del tag para el título en edición.
        /// </summary>
        public string TagNameTituloEdicion { get; set; }

        /// <summary>
        /// Nombre del tag para el título en lectura.
        /// </summary>
        public string TagNameTituloLectura { get; set; }

        /// <summary>
        /// Nombre de la entidad en edición.
        /// </summary>
        public Dictionary<string, string> AtrNombre { get; set; }

        public bool PermitirScript { get; set; }

        /// <summary>
        /// Nombre de la entidad en lectura.
        /// </summary>
        public Dictionary<string, string> AtrNombreLectura { get; set; }

        /// <summary>
        /// Nombre de la entidad en edición.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre de la entidad en edición.
        /// </summary>
        public string NombreLectura { get; set; }

        /// <summary>
        /// Texto del link editar despliegue.
        /// </summary>
        public string TextoLinkEditarDespliegue { get; set; }

        /// <summary>
        /// Propiedad que vincula la entidad actual con alguna hija.
        /// </summary>
        public string PropiedadVinculanteConEntidadHija { get; set; }

        /// <summary>
        /// Indica si el div que contiene la entidad es desplegable.
        /// </summary>
        public bool DivEntidadDesplegable { get; set; }

        /// <summary>
        /// Valor de microdatos.
        /// </summary>
        public string Microdatos { get; set; }

        /// <summary>
        /// Valor de microformatos.
        /// </summary>
        public Dictionary<string, string> Microformatos { get; set; }

        /// <summary>
        /// Pinta un mapa.
        /// </summary>
        public bool EsMapaGoogle { get; set; }

        /// <summary>
        /// Propiedades con la latitud y longitud para el mapa.
        /// </summary>
        public KeyValuePair<string, string> PropiedadesDatosMapa { get; set; }

        /// <summary>
        /// Propiedad de la ruta de los mapas y su color.
        /// </summary>
        public KeyValuePair<string, string> PropiedadesDatosMapaRuta { get; set; }

        /// <summary>
        /// Indica si hay que sustituir la entidad en el mapa de google.
        /// </summary>
        public bool NoSustituirEntidadEnMapaGoogle { get; set; }

        /// <summary>
        /// Campo por el que se debe ordenar la entidad.
        /// </summary>
        public string CampoOrden { get; set; }

        /// <summary>
        /// Campo en el que se debe pintar el orden que tiene la entidad.
        /// </summary>
        public string CampoRepresentanteOrden { get; set; }

        /// <summary>
        /// Propiedades con sus valores según los cuales debe o no pintarse una entidad.
        /// </summary>
        public Dictionary<string, KeyValuePair<bool, List<string>>> PropsCondicionPintarEntSegunValores { get; set; }

        public List<Guid> PrivadoParaGrupoEditores { get; set; }

        /// <summary>
        /// Devuelve el nombre de la entidad.
        /// </summary>
        /// <param name="pVistaPrevia">Indica si estamos en vista previa o no</param>
        /// <returns>nombre de la entidad</returns>
        public string NombreEntidad(bool pVistaPrevia)
        {
            if (pVistaPrevia)
            {
                return NombreLectura;
            }
            else
            {
                return Nombre;
            }
        }
    }
}
