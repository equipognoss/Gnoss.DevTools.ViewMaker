using Es.Riam.Interfaces;
using Es.Riam.Semantica.Plantillas;
using Newtonsoft.Json;


namespace Es.Riam.Semantica.OWL
{
    public class ElementoOntologia
    {
        /// <summary>
        /// Devuelve o establece la Url de la ontología.
        /// </summary>
        public string UrlOntologia { get; set; }

        /// <summary>
        /// Devuelve o establece el namespace de la ontología.
        /// </summary>
        public string NamespaceOntologia { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la entidad
        /// </summary>
        public virtual string TipoEntidad { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la entidad
        /// </summary>
        [JsonIgnore]
        public virtual string TipoEntidadGeneracionIDs
        {
            get
            {
                return TipoEntidad?.Replace("/", "_").Replace(":", "_").Replace(".", "_").Replace("#", "_");
            }
        }

        /// <summary>
        /// Obtiene o establece el tipo de la entidad para generar el nombre de las clases.
        /// </summary>
        [JsonIgnore]
        public virtual string TipoEntidadGeneracionClases
        {
            get
            {
                if (TipoEntidad.Contains("#"))
                {
                    return TipoEntidad.Substring(TipoEntidad.LastIndexOf("#") + 1);
                }
                else if (TipoEntidad.Contains("/"))
                {
                    return TipoEntidad.Substring(TipoEntidad.LastIndexOf("/") + 1);
                }
                else
                {
                    return TipoEntidad;
                }
            }
        }

        /// <summary>
        /// Obtiene el tipo de la entidad sin apaños para repeticiones.
        /// </summary>
        [JsonIgnore]
        public string TipoEntidadLimpioDeApanioRepeticiones
        {
            get
            {
                return ObtenerTiposEntidadLimpiaDeApanioRepeticiones(TipoEntidad);
            }
        }

        /// <summary>
        /// Indica si la entidad es path de un tesauro semántico.
        /// </summary>
        public bool EsEntidadPathTesSemantico { get; set; }


        /// <summary>
        /// Nombre de la propiedad nodo del tesauro semántico, ya que esta entidad es un path del mismo.
        /// </summary>
        public string PropiedadNodoTesSemantico { get; set; }

        /// <summary>
        /// Tipo de entidad si la URL completa, es decir, relavito.
        /// </summary>
        public string TipoEntidadRelativo { get; set; }

        /// <summary>
        /// Nos indica si hemos procesado las propiedades que había que ordenar
        /// </summary>
        public bool ProcesadoOrdenEntidad { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la entidad
        /// </summary>
        public virtual string TipoEntidadConNamespace { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de la entidad
        /// </summary>
        public virtual string TipoEntidadCrearRdf { get; set; }

        /// <summary>
        /// Obtiene o establece el elemento gnoss al que hace referencia.
        /// </summary>
        public IElementoGnoss Elemento { get; set; }

        /// <summary>
        /// Obtiene las propiedades que posee la entidad
        /// </summary>
        public List<Propiedad> Propiedades { get; set; }

        /// <summary>
        /// Obtiene una lista ordenada (primero las funcionales de tipo DataProperty) de propiedades
        /// </summary>
        public List<Propiedad> PropiedadesOrdenadas { get; set; }

        /// <summary>
        /// Obtiene las restricciones sobre las propiedades
        /// </summary>
        public List<Restriccion> Restricciones { get; set; }

        /// <summary>
        /// Obtiene o establece las superclases de la entidad
        /// </summary>
        public virtual List<string> Superclases { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de subclases de la entidad
        /// </summary>
        public List<string> Subclases { get; set; }

        /// <summary>
        /// Obtiene o establece las superclases útiles de la entidad
        /// </summary>
        [JsonIgnore]
        public List<string> SuperclasesUtiles
        {
            get
            {
                SuperclasesUtiles = new List<string>();

                foreach (string superClase in Superclases)
                {
                    if (superClase != "Thing" && !superClase.Contains("#Thing") && !EsClaseOntologiaImportada(superClase))
                    {
                        SuperclasesUtiles.Add(superClase);
                    }
                }


                return this.SuperclasesUtiles;
            }
            set { }
        }

        /// <summary>
        /// Obtiene o establece la lista de relaciones que especializan a la entidad.
        /// </summary>
        public List<string> Especializaciones { get; set; }

        /// <summary>
        /// Obtiene o establece la relación que generaliza la entidad.
        /// </summary>
        public string Generalizacion { get; set; }

        /// <summary>
        /// Obtiene o establece el ID de la entidad.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Devuelve la Uri del elemento.
        /// </summary>
        [JsonIgnore]
        public virtual string Uri
        {
            get
            {
                if (Ontologia.UsoIDsRelativos)
                {
                    return GestionOWL.ObtenerUrlEntidad(TipoEntidad) + ID;
                }
                else
                {
                    return ID;
                }
            }
        }

        /// <summary>
        /// Obtiene la lista de entidades que están relacionadas con la entidad.
        /// </summary>
        public List<ElementoOntologia> EntidadesRelacionadas { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción o el nombre del elemento que facilita la identificación del mismo por el usuario
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Obtiene o establece si la entidad se debe exportar/importar o no.
        /// </summary>
        public bool EntidadValida { get; set; }

        /// <summary>
        /// Obtiene o establece el padre de la entidad.
        /// </summary>
        public IElementoGnoss Padre { get; set; }

        /// <summary>
        /// Verdad si la entidad puede tener un padre.
        /// </summary>
        public bool PermitePadre { get; set; }

        /// <summary>
        /// Obtiene la lista de propiedades imprimibles
        /// </summary>
        public List<Propiedad> ListaPropiedadesImprimibles { get; set; }

        /// <summary>
        /// Verdad si se han obtenido todas las entidades relacionadas con esta entidad
        /// </summary>
        public bool EstaCompleta { get; set; }

        /// <summary>
        /// Ontología a la que pertenece el elemento.
        /// </summary>
        public Ontologia Ontologia { get; set; }

        /// <summary>
        /// Propiedades equivalentes con SameAs.
        /// </summary>
        public List<string> OWLSameAs { get; set; }

        /// <summary>
        /// Label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Label.
        /// </summary>
        public Dictionary<string, string> LabelIdioma { get; set; }

        /// <summary>
        /// Indica si alguna propiedad de la entidad posee valor.
        /// </summary>
        public bool TienePropiedadesConValor { get; set; }

        public bool IdiomaUsuarioEnAlgunaPropiedad { get; set; }

        public bool IdiomaNoUsuarioEnAlgunaPropiedad { get; set; }

        #region Estilos plantilla

        /// <summary>
        /// Configuración de la plantilla.
        /// </summary>
        public EstiloPlantillaEspecifEntidad EspecifEntidad { get; set; }

        /// <summary>
        /// Orden de la entidad especificado por una de sus propiedades.
        /// </summary>
        public int OrdenEntiad { get; set; }

        /// <summary>
        /// Orden de la entidad en texto especificado por una de sus propiedades.
        /// </summary>
        public string OrdenEntiadTexto { get; set; }

        /// <summary>
        /// Indica si la entidad cumple la condición de que alguna de sus propiedades tenga un determinado valor.
        /// </summary>
        public bool CumpleCondicionesMostrar { get; set; }

        /// <summary>
        /// Indica si la entidad contiene una propiedad que es tesauro semántico y además está configurado con vista árbol.
        /// </summary>
        public bool ContienePropiedadTesSemArbol { get; set; }

        #endregion

        /// <summary>
        /// Construye un elemento de ontología a partir de otro pasado por parámetro
        /// </summary>
        /// <param name="pEntidad">Elemento de ontología a partir del cual se creará uno nuevo</param>
        public ElementoOntologia(ElementoOntologia pEntidad)
        {
            TipoEntidad = pEntidad.TipoEntidad;
            Propiedades = new List<Propiedad>();

            foreach (Propiedad propiedad in pEntidad.Propiedades)
            {
                Propiedad propiedadNueva = new Propiedad(propiedad);
                Propiedades.Add(propiedadNueva);
            }
            //this.mRestricciones = new List<Restriccion>();

            //foreach(Restriccion restriccion in pEntidad.Restricciones)
            //{
            //    this.mRestricciones.Add(restriccion);
            //}
            Restricciones = pEntidad.Restricciones;
            Superclases = pEntidad.Superclases;
            SuperclasesUtiles = pEntidad.SuperclasesUtiles;
            EntidadesRelacionadas = new List<ElementoOntologia>();

            foreach (ElementoOntologia entidad in pEntidad.EntidadesRelacionadas)
            {
                EntidadesRelacionadas.Add(new ElementoOntologia(entidad));
            }
            ID = pEntidad.ID;
            Descripcion = pEntidad.Descripcion;
            Subclases = pEntidad.Subclases;
            Especializaciones = pEntidad.Especializaciones;
            Generalizacion = pEntidad.Generalizacion;
            EntidadValida = pEntidad.EntidadValida;
            Padre = pEntidad.Padre;
            PermitePadre = pEntidad.PermitePadre;
            UrlOntologia = pEntidad.UrlOntologia;
            NamespaceOntologia = pEntidad.NamespaceOntologia;
            Ontologia = pEntidad.Ontologia;
            Label = pEntidad.Label;
            LabelIdioma = pEntidad.LabelIdioma;
        }

        /// <summary>
        /// Crea una entidad a partir de un tipo de entidad.
        /// </summary>
        /// <param name="pTipoEntidad">tipo de entidad.</param>
        /// <param name="pNamespaceOntologia">Namespace de la ontología</param>
        /// <param name="pUrlOntologia">Url de la ontología</param>
        /// <param name="pOntologia">Ontología a la que pertenece el elemento</param>
        public ElementoOntologia(string pTipoEntidad, string pUrlOntologia, string pNamespaceOntologia, Ontologia pOntologia)
        {
            TipoEntidad = pTipoEntidad;
            Propiedades = new List<Propiedad>();
            Restricciones = new List<Restriccion>();
            Superclases = new List<string>();
            EntidadesRelacionadas = new List<ElementoOntologia>();
            ID = "";
            Descripcion = pTipoEntidad;
            Subclases = new List<string>();
            Especializaciones = new List<string>();
            Generalizacion = null;
            EntidadValida = true;
            Padre = null;
            PermitePadre = true;
            UrlOntologia = pUrlOntologia;
            NamespaceOntologia = pNamespaceOntologia;
            Ontologia = pOntologia;
        }
        public ElementoOntologia()
        {

        }

        /// <summary>
        /// Indica si una clase pertenece a una ontología importada.
        /// </summary>
        /// <param name="pClase">Nombre de la clase</param>
        /// <returns>TRUE si la clase pertenece a una ontología importada, FALSE si no</returns>
        public bool EsClaseOntologiaImportada(string pClase)
        {
            foreach (string ontoImport in Ontologia.UrlOntologiasImportadas)
            {
                if (pClase.StartsWith(ontoImport))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene el tipo de la entidad sin apaños para repeticiones.
        /// </summary>
        /// <param name="pTipoEntidad">Tipo entidad</param>
        /// <returns>Tipo de la entidad sin apaños para repeticiones</returns>
        public static string ObtenerTiposEntidadLimpiaDeApanioRepeticiones(string pTipoEntidad)
        {
            if (pTipoEntidad.Contains("_bis"))
            {
                return pTipoEntidad.Substring(0, pTipoEntidad.IndexOf("_bis"));
            }

            return pTipoEntidad;
        }
    }

}
