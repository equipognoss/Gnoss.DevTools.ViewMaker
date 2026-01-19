using Es.Riam.Semantica.Plantillas;

namespace Es.Riam.Semantica.OWL
{
    public enum TipoPropiedad
    {
        /// <summary>
        /// Tipo de propiedad cuyos valores van a ser un tipo de valor conocido
        /// </summary>
        DatatypeProperty,

        /// <summary>
        /// Tipo de propiedad cuyos valores van a ser un tipo de valor definido en la ontología
        /// </summary>
        ObjectProperty
    }

    public class Propiedad
    {
        private const string NAMESPACE_XMLSCHEMA = "http://www.w3.org/2001/XMLSchema#";

        #region Propiedades

        /// <summary>
        /// Obtiene o establece el tipo de propiedad
        /// </summary>
        public TipoPropiedad Tipo { get; set; }

        /// <summary>
        /// Indica si la propiedad será visible para el usuario.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre real de la propiedad, con acentos y espacios.
        /// </summary>
        public virtual string NombreReal { get; set; }

        /// <summary>
        /// Indica si la propiedad ha sido heredada de una entidad superior.
        /// </summary>
        public bool Heredada { get; set; }

        /// <summary>
        /// Obtiene o establece los valores que adquiere la propiedad en una determinada entidad.
        /// </summary>
        public Dictionary<string, ElementoOntologia> ListaValores { get; set; }

        /// <summary>
        /// Obtiene o establece los valores que adquiere la propiedad en una determinada entidad.
        /// </summary>
        public Dictionary<string, ElementoOntologia> ListaValoresOrdCampoEntidad { get; set; }

        /// <summary>
        /// Indica si las entiades hijas de la propiedad actual se ordenan por una propiedad o no.
        /// </summary>
        public bool EntidadesHijasConOrden { get; set; }

        /// <summary>
        /// Obtiene el único valor de la propiedad en caso de que ésta sea funcional
        /// </summary>
        public KeyValuePair<string, ElementoOntologia> UnicoValor { get; set; }

        /// <summary>
        /// Obtiene los valores según el idioma seleccionado.
        /// </summary>
        public Dictionary<string, Dictionary<string, ElementoOntologia>> ListaValoresIdioma { get; set; }

        /// <summary>
        /// Devuelve el string que corresponde al 1º valor de la propiedad sea del tipo que sea.
        /// </summary>
        public string PrimerValorPropiedad { get; set; }

        /// <summary>
        /// Lista de valores usados por la propiedad.
        /// </summary>
        public List<string> ListaValoresUsados { get; set; }

        /// <summary>
        /// Propiedad de la cual se repite la actual.
        /// </summary>
        public string NombrePropiedadRepetidaDe { get; set; }

        /// <summary>
        /// Propiedad de la cual se repite la actual.
        /// </summary>
        public Propiedad PropiedadRepetidaDe { get; set; }

        /// <summary>
        /// Obtiene o establece los dominios de entidades que puede tener esta propiedad.
        /// </summary>
        public List<string> Dominio { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de dato al que pertenecerá el valor de la propiedad.
        /// </summary>
        public string Rango { get; set; }

        /// <summary>
        /// Indica si esta propiedad tiene un selector de entidad definido
        /// </summary>
        public bool TieneSelectorEntidad { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo RELATIVO (Sin #) de dato al que pertenecerá el valor de la propiedad.
        /// </summary>
        public string RangoRelativo { get; set; }

        /// <summary>
        /// Obtiene o establece si la propiedad es funcional o no
        /// </summary>
        public bool FunctionalProperty { get; set; }

        /// <summary>
        /// Obtiene el nombre de la propiedad
        /// </summary>
        public virtual string Nombre { get; set; }

        /// <summary>
        /// Obtiene el nombre de la propiedad incluyendo el namespace
        /// </summary>
        public virtual string NombreConNamespace { get; set; }

        /// <summary>
        /// Devuelve el nombre con formato de URI.
        /// </summary>
        public string NombreFormatoUri { get; set; }

        /// <summary>
        /// Obtiene el nombre de la propiedad para generar los ids de las propiedades.
        /// </summary>
        public virtual string NombreGeneracionIDs { get; set; }

        /// <summary>
        /// Obtiene el nombre de la propiedad para generar el nombre de las clases.
        /// </summary>
        public virtual string NombreGeneracionClases { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de selección de la propiedad.
        /// </summary>
        public bool Seleccionada { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad inversa de ésta.
        /// </summary>
        public Propiedad PropiedadInversa { get; set; }

        /// <summary>
        /// Obtiene todas las propiedades pertenecientes a otras entidades que son inversas a ésta
        /// </summary>
        public IList<Propiedad> ListaPropiedadesInversas { get; set; }

        /// <summary>
        /// Obtiene o establece el elemento de ontología al que pertenece.
        /// </summary>
        public ElementoOntologia ElementoOntologia { get; set; }

        /// <summary>
        /// Obtiene o establece la propiedad equivalente a ésta.
        /// </summary>
        public Propiedad PropiedadEquivalente { get; set; }

        /// <summary>
        /// Devuelve o establece la lista de valores permitidos de la propiedad (One Of).
        /// </summary>
        public List<string> ListaValoresPermitidos { get; set; }

        /// <summary>
        /// Contiene el valor por defecto que debe tener la propiedad, pero que no es correcto para la misma (Ej: valor gris combo).
        /// </summary>
        public string ValorDefectoNoSeleccionable { get; set; }

        /// <summary>
        /// Indica si el rango de la propiedad es numérico.
        /// </summary>
        public bool RangoEsNumerico { get; set; }

        /// <summary>
        /// Indica si el rango de la propiedad es entero.
        /// </summary>
        public bool RangoEsEntero { get; set; }

        /// <summary>
        /// Indica si el rango de la propiedad es un número real.
        /// </summary>
        public bool RangoEsFloat { get; set; }

        /// <summary>
        /// Indica si el rango de la propiedad es de tipo fecha.
        /// </summary>
        public bool RangoEsFecha { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si el elemento se imprimirá
        /// </summary>
        public bool SeDebeImprimir { get; set; }

        /// <summary>
        /// Obtiene o establece el valor que indica si el elemento ya se imprimió en el documento
        /// </summary>
        public bool EstaImpreso { get; set; }

        /// <summary>
        /// Devuelve TRUE si la cardinalidad es menor o igual que uno, FALSE si no posee la restriccion o la cardinalidad es diferente.
        /// </summary>
        public bool CardinalidadMenorOIgualUno { get; set; }

        public int CardinalidadMinima { get; set; }

        public int CardinalidadMaxima { get; set; }

        /// <summary>
        /// Indica si la propiedad solo puede tener un valor.
        /// </summary>
        /// 

        public bool ValorUnico { get; set; }

        /// <summary>
        /// Devuelve el tipo de entidad al que representa la propiedad en un formulario semántico.
        /// </summary>
        public string TipoEntidadRepresenta { get; set; }

        /// <summary>
        /// Ontología a la que pertenece el elemento.
        /// </summary>
        public Ontologia Ontologia { get; set; }

        /// <summary>
        /// SuperPropiedades de la propiedad.
        /// </summary>
        public List<string> SuperPropiedades { get; set; }

        /// <summary>
        /// Obtiene o establece los valores que adquiere la propiedad en una determinada entidad.
        /// </summary>
        public Dictionary<string, ElementoOntologia> ValoresUnificados { get; set; }

        /// <summary>
        /// Label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Label.
        /// </summary>
        public Dictionary<string, string> LabelIdioma { get; set; }

        #region Estilos plantilla

        /// <summary>
        /// Configuración de la plantilla.
        /// </summary>
        public EstiloPlantillaEspecifProp EspecifPropiedad { get; set; }

        #endregion

        #endregion

        /// <summary>
        /// Crea una propiedad a partir de otra.
        /// </summary>
        /// <param name="pPropiedad">propiedad que se tomará como referencia.</param>
        public Propiedad(Propiedad pPropiedad)
        {
            if (pPropiedad != null)
            {
                Tipo = pPropiedad.Tipo;
                ListaValores = new Dictionary<string, ElementoOntologia>();
                foreach (string valor in pPropiedad.ListaValores.Keys)
                {
                    ListaValores.Add(valor, pPropiedad.ListaValores[valor]);
                }
                UnicoValor = pPropiedad.UnicoValor;
                ListaValoresIdioma = new Dictionary<string, Dictionary<string, ElementoOntologia>>();
                foreach (string valor in pPropiedad.ListaValoresIdioma.Keys)
                {
                    ListaValoresIdioma.Add(valor, new Dictionary<string, ElementoOntologia>());

                    foreach (string valorInt in pPropiedad.ListaValoresIdioma[valor].Keys)
                    {
                        pPropiedad.ListaValoresIdioma[valor].Add(valorInt, pPropiedad.ListaValoresIdioma[valor][valorInt]);
                    }
                }
                Dominio = pPropiedad.Dominio;
                Rango = pPropiedad.Rango;
                FunctionalProperty = pPropiedad.FunctionalProperty;
                Nombre = pPropiedad.Nombre;
                Seleccionada = true;
                Heredada = pPropiedad.Heredada;

                Visible = pPropiedad.Visible;
                PropiedadInversa = pPropiedad.PropiedadInversa;
                ListaPropiedadesInversas = pPropiedad.ListaPropiedadesInversas;
                ElementoOntologia = pPropiedad.ElementoOntologia;
                PropiedadEquivalente = pPropiedad.PropiedadEquivalente;
                ListaValoresPermitidos = pPropiedad.ListaValoresPermitidos;
                Ontologia = pPropiedad.Ontologia;
                SuperPropiedades = pPropiedad.SuperPropiedades;
                NombrePropiedadRepetidaDe = pPropiedad.NombrePropiedadRepetidaDe;
                ListaValoresUsados = pPropiedad.ListaValoresUsados;
                Label = pPropiedad.Label;
                LabelIdioma = pPropiedad.LabelIdioma;
            }
            else
                throw new ArgumentNullException("pPropiedad", "El argumento no puede ser nulo.");
        }

        public Propiedad()
        {
            
        }
    }

}
