using Es.Riam.Semantica.OWL;
using Es.Riam.Semantica.Plantillas;
using Newtonsoft.Json;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo que representa una propiedad que posee un modelo de entidad de la ontología. Puede ser un propiedad ontológica, un grupo de propiedades, un literal, ect.
    /// </summary>
    public class SemanticPropertyModel
    {
        /// <summary>
        /// Elemento de la propiedad.
        /// </summary>
        public ElementoOrdenado Element { get; set; }

        /// <summary>
        /// Modelo de entidad padre del modelo actual.
        /// </summary>
        public SemanticEntityModel EntityParent { get; set; }

        /// <summary>
        /// Profunidad dentro de la jerarquia de entiades y propiedades. Dicha profundidad se obtiene mediante su relación através de sus propiedades.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Indica si el contenedor que representa la propiedad debe pintarse oculto. Por ejemplo si es un grupo dentro de un selector de grupos y no está visible.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Propiedades que contiene el modelo de la propiedad actual.
        /// </summary>
        public List<SemanticPropertyModel> Properties { get; set; }

        /// <summary>
        /// Grupo que representa la propiedad actual. Sólo tendrá valor en el caso de que la propiedad actual sea un grupo.
        /// </summary>
        public Group GroupInfo { get; set; }

        /// <summary>
        /// Literal que representa la propiedad actual. Sólo tendrá valor en el caso de que la propiedad actual sea un Literal.
        /// </summary>
        public Literal LiteralInfo { get; set; }

        /// <summary>
        /// Dato especial que representa la propiedad actual. Sólo tendrá valor en el caso de que la propiedad actual sea un dato especial.
        /// </summary>
        public EspecialProp EspecialPropInfo { get; set; }

        /// <summary>
        /// Propiedad ontológica que representa la propiedad actual. Sólo tendrá valor en el caso de que la propiedad actual sea una propiedad ontológica.
        /// </summary>
        public OntologyProp OntologyPropInfo { get; set; }

        /// <summary>
        /// Indica que se debe mostrar en modo lectura.
        /// </summary>
        public bool ReadMode { get; set; }

        /// <summary>
        /// Especificación de la propiedad semántica actual. Sólo tendrá valor en el caso de que la propiedad actual sea una propiedad ontológica.
        /// </summary>
        public EstiloPlantillaEspecifProp SpecificationProperty { get; set; }

        /// <summary>
        /// Clase que aglutina información de la propiedad ontológica, que es la propiedad actual.
        /// </summary>
        public class OntologyProp
        {
            /// <summary>
            /// Devuelve el tipo de campo de la propiedad de una ontología.
            /// </summary>
            public TipoCampoOntologia FieldType { get; set; }

            /// <summary>
            /// ID del control que representa a la propiedad.
            /// </summary>
            public string ControlID { get; set; }

            /// <summary>
            /// Valores de la propiedad ontológica.
            /// En el caso de ser propiedad de tipo Tesauro Semántico en su vista por defecto, contiene los nombre de las categorías ordenadas de padré a último hijo de la jerarquía.
            /// </summary>
            public List<PropertyValue> PropertyValues { get; set; }

            /// <summary>
            /// Valores multiIdioma de la propiedad ontológica.
            /// </summary>
            public Dictionary<string, List<PropertyValue>> PropertyLanguageValues { get; set; }

            /// <summary>
            /// Grafo para una propiedad grafo dependiente. Solo se aplica a Propiedades ontológicas configuradas como GrafoDependiente.
            /// </summary>
            public string PropDependentGraph { get; set; }

            /// <summary>
            /// Valor del control auxiliar de la propiedad ontológica. El control auxiliar es necesario par propiedades como las GrafoDependiente.
            /// </summary>
            public string AuxiliaryControlValue { get; set; }

            /// <summary>
            /// Indica si el control auxiliar de la propiedad ontológica debe estar deshabilitado por defecto. El control auxiliar es necesario par propiedades como las GrafoDependiente.
            /// </summary>
            public bool AuxiliaryControlDisabled { get; set; }

            /// <summary>
            /// Valor por defecto no seleccionable.
            /// </summary>
            public string DefaultUnselectableValue { get; set; }

            /// <summary>
            /// Título para el label de la propiedad.
            /// </summary>
            public string LabelTitle { get; set; }

            /// <summary>
            /// Texto de ayuda de la propiedad.
            /// </summary>
            public string HelpText { get; set; }

            /// <summary>
            /// URL about del RDFA de la propiedad.
            /// </summary>
            public string AboutRDFA { get; set; }

            /// <summary>
            /// URL property del RDFA de la propiedad.
            /// </summary>
            public string PropertyRDFA { get; set; }

            /// <summary>
            /// Indica si la propiedad solo puede tener un solo valor.
            /// </summary>
            public bool UniqueValue { get; set; }

            public int MinCardinality { get; set; }
            public int MaxCardinality { get; set; }

            public bool FunctionalProperty { get; set; }

            /// <summary>
            /// Indica si la propiedad admite más valores de los que tiene.
            /// </summary>
            public bool ItIsPossibleToSddMoreValues { get; set; }

            /// <summary>
            /// Titulos de las entidades representantes de una propiedad de tipo objeto multiple.
            /// </summary>
            public List<string> RepresentativeEntityTitles { get; set; }

            /// <summary>
            /// Selector de entidad de un propiedad de tipo Objeto con un selector de entidad configurado.
            /// </summary>
            public EntitySelector EntitySelector { get; set; }

            /// <summary>
            /// Indica si la propiedad es multiitioma.
            /// </summary>
            public bool MultiLanguage { get; set; }

            /// <summary>
            /// Indica si la propiedad es multiitioma.
            /// </summary>
            public bool MultiLanguageWithTabs { get; set; }

            /// <summary>
            /// Número de entidades auxiliares por página o 0 si no hay paginación.
            /// </summary>
            public int NumEntitiesForPage { get; set; }

            /// <summary>
            /// Número total de entidades auxiliares para paginar o 0 si no hay paginación.
            /// </summary>
            public int TotalEntitiesPagination { get; set; }
        }

        /// <summary>
        /// Clase que representa el valor de una propiedad.
        /// </summary>
        public class PropertyValue
        {
            /// <summary>
            /// Texto con el valor de la propiedad ontológica.
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// Idioma del valor seleccionado, NULL si no tiene idioma.
            /// </summary>
            public string LanguageOfValue { get; set; }

            /// <summary>
            /// Modelo de la entidad relacionado con la propiedad. Solo puede tener valor para propiedades de tipo Objeto.
            /// </summary>
            public SemanticEntityModel RelatedEntity { get; set; }

            /// <summary>
            /// URL de descarga del archivo adjunto a la propiedad. Solo se aplica a Propiedades ontológicas configuradas como adjunto (Archivo, ArchivoLink) o Link o una normal configurada con UrlLinkDelValor TRUE.
            /// </summary>
            public string DownloadUrl { get; set; }

            /// <summary>
            /// Url para el objeto embebido de Youtube. Solo se aplica a Propiedades ontológicas configuradas como EmbebedLink (Youtube, Vimeo y Slideshare).
            /// </summary>
            public string EmbebedLinkYoutube { get; set; }

            /// <summary>
            /// Url para el objeto embebido de Vimeo. Solo se aplica a Propiedades ontológicas configuradas como EmbebedLink (Youtube, Vimeo y Slideshare).
            /// </summary>
            public string EmbebedLinkVimeo { get; set; }

            /// <summary>
            /// Url para el objeto embebido de Slideshare. Solo se aplica a Propiedades ontológicas configuradas como EmbebedLink (Youtube, Vimeo y Slideshare).
            /// </summary>
            public string EmbebedLinkSlideshare { get; set; }

            /// <summary>
            /// Html del objeto embebido. Solo se aplica a Propiedades ontológicas configuradas como EmbebedObject.
            /// </summary>
            public string EmbebedObject { get; set; }

            /// <summary>
            /// Url para el control auxiliar link que debe envolver la propiedad principal.
            /// </summary>
            public string UrlAuxiliaryLinkControl { get; set; }

            /// <summary>
            /// Propiedad a la que pertenece el valor.
            /// </summary>
            public SemanticPropertyModel Property { get; set; }

            /// <summary>
            /// Titulos representantes de la entidad de esta propiedad. Solo aplicable si la propiedad es de tipo objeto multiple.
            /// </summary>
            public List<string> RepresentativeEntityTitles { get; set; }

            /// <summary>
            /// Valores hijos de un valor que es una categoría semántica. Solo se aplica el valor pertenece a una propiedad configurada como un selector de entidad de tipo tesuaro semántico y tipo de presentación árbol.
            /// </summary>
            public List<PropertyValue> ThesaurusSemanticTreeChildren { get; set; }
        }

        /// <summary>
        /// Clase que representa el selector de entidad de un propiedad de tipo Objeto con un selector de entidad configurado.
        /// </summary>
        public class EntitySelector
        {
            /// <summary>
            /// Valores de las entiadades del selector para la edición.
            /// </summary>
            public Dictionary<string, string> EditionEntitiesValues { get; set; }

            /// <summary>
            /// Título extra para el control de autocompletar del selector de entidad.
            /// </summary>
            public string ExtraTitleAutoComplete { get; set; }

            /// <summary>
            /// Grafo del selector de entidad.
            /// </summary>
            public string Graph { get; set; }

            /// <summary>
            /// Url de la entidad solicitada para el selector de entidad.
            /// </summary>
            public string EntityRequestedUrl { get; set; }

            /// <summary>
            /// Url de la propiedad que enlaza con la entidad solicitada para el selector de entidad.
            /// </summary>
            public string PropertyRequestedUrl { get; set; }

            /// <summary>
            /// Url del tipo de la entidad solicitada para el selector de entidad.
            /// </summary>
            public string EntityTypeRequestedUrl { get; set; }

            /// <summary>
            /// Propiedades de edición de la entidad.
            /// </summary>
            public List<string> EditionProperties { get; set; }

            /// <summary>
            /// Extra para el where del control de autocompletar del selector de entidad.
            /// </summary>
            public string ExtraWhereAutoComplete { get; set; }

            /// <summary>
            /// Idioma del selector de entidad.
            /// </summary>
            public string Language { get; set; }

            /// <summary>
            /// Título y wheres extras adicionales para el selector.
            /// </summary>
            public List<KeyValuePair<string, string>> AdditionalExtraTitleWhereAutoCompletes { get; set; }

            /// <summary>
            /// IDs de entidades que tienen hijos.
            /// </summary>
            public List<string> EntitiesWithChildren { get; set; }

            /// <summary>
            /// Valor ya agregado al tesauro semántico. Key: Valor original. Value: Valor tratado para la presentación al usuario.
            /// </summary>
            public KeyValuePair<string, string> SemanticThesaurusAddedValue { get; set; }

            /// <summary>
            /// Lista con los IDs y tipos entidad que dependen de la propiedad selector actual.
            /// </summary>
            public List<KeyValuePair<string, string>> DependentProperties { get; set; }

            #region Edicion Selector Personas y Grupos

            /// <summary>
            /// ID de la organización del perfil de usuario para el selector de usuarios y grupos.
            /// </summary>
            public string OrganizationID { get; set; }

            /// <summary>
            /// Tipo de consulta para el selector de usuarios y grupos.
            /// </summary>
            public string QueryType { get; set; }

            #endregion

            #region Lectura

            /// <summary>
            /// Recursos vinculados al selector de entidad, en el caso de que el selector sea de tipo "UrlRecurso".
            /// </summary>
            public List<ResourceLinkedToEntitySelector> LinkedResources { get; set; }

            /// <summary>
            /// Número de entidades por página o 0 si no hay paginación.
            /// </summary>
            public int NumEntitiesForPage { get; set; }

            /// <summary>
            /// Número total de entidades para paginar o 0 si no hay paginación.
            /// </summary>
            public int TotalEntitiesPagination { get; set; }

            #endregion
        }

        /// <summary>
        /// Clase que representa a los recursos vinculados a un selector de entidad.
        /// </summary>
        public class ResourceLinkedToEntitySelector
        {
            /// <summary>
            /// Key del recurso
            /// </summary>
            public Guid Key { get; set; }

            /// <summary>
            /// Link del recurso
            /// </summary>
            public string Link { get; set; }

            /// <summary>
            /// Título del recurso.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Texto del label título para el recurso.
            /// </summary>
            public string TitleLabel { get; set; }

            /// <summary>
            /// URl de la imagen del recurso.
            /// </summary>
            public string ImageUrl { get; set; }

            /// <summary>
            /// Texto del label imagen para el recurso.
            /// </summary>
            public string ImageUrlLabel { get; set; }

            /// <summary>
            /// Descripción del recurso.
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Texto del label descripción para el recurso.
            /// </summary>
            public string DescriptionLabel { get; set; }

            /// <summary>
            /// Autores del recurso. Key: Nombre del autor. Value: Link del autor.
            /// </summary>
            public Dictionary<string, string> Authors { get; set; }

            /// <summary>
            /// Texto del label autores para el recurso.
            /// </summary>
            public string AuthorsLabel { get; set; }
        }

        /// <summary>
        /// Clase que aglutina información del grupo, que es la propiedad actual.
        /// </summary>
        public class Group
        {
            /// <summary>
            /// Indica si se debe incluir el icono de GNOSS en el grupo. Si el grupo es de tipo "titulo" puede incluirlo.
            /// </summary>
            public bool IncludeGnossIcon { get; set; }

            /// <summary>
            /// Indica que el icono de Gnoss debe reflejar que el recurso es privado para editores y lectores.
            /// </summary>
            public bool GnossIconIsPrivate { get; set; }

            /// <summary>
            /// Nombre semántico para el icono GNOSS.
            /// </summary>
            public string GnossIconName { get; set; }

            /// <summary>
            /// Nombre del grupo.
            /// </summary>
            public string GroupName { get; set; }

            /// <summary>
            /// Clase del nombre del grupo.
            /// </summary>
            public string GroupNameClass { get; set; }

            /// <summary>
            /// Etiqueta HTML del nombre del grupo.
            /// </summary>
            public string GroupNameTag { get; set; }
        }

        #region Propiedades auxiliares vistas

        /// <summary>
        /// Valores de la propiedad ontológica. Solo tendrá valores si la propiedad es ontológica y ésta tiene valores.
        /// En el caso de ser propiedad de tipo Tesauro Semántico en su vista por defecto, contiene los nombre de las categorías ordenadas de padré a último hijo de la jerarquía.
        /// </summary>
        [JsonIgnore]
        public List<PropertyValue> PropertyValues
        {
            get
            {
                if (OntologyPropInfo != null)
                {
                    return OntologyPropInfo.PropertyValues;
                }
                else
                {
                    return new List<PropertyValue>();
                }
            }
        }

        /// <summary>
        /// Primer valor de la propiedad ontológica. Solo tendrá valor si la propiedad es ontológica y ésta tiene algún valor.
        /// En el caso de ser propiedad de tipo Tesauro Semántico en su vista por defecto, contiene los nombre de las categorías ordenadas de padré a último hijo de la jerarquía.
        /// </summary>
        [JsonIgnore]
        public PropertyValue FirstPropertyValue
        {
            get
            {
                if (OntologyPropInfo?.PropertyValues?.Count > 0)
                {
                    return OntologyPropInfo.PropertyValues[0];
                }
                return null;
            }
        }

        /// <summary>
        /// Obtiene el RDFa de la entidad.
        /// </summary>
        /// <returns>RDFa de la entidad. Ejemplo: about="http://a..." typeof="http://b...".</returns>
        public string GetRDFA()
        {
            if (OntologyPropInfo.AboutRDFA != null && OntologyPropInfo.PropertyRDFA != null)
            {
                string rdfa = string.Concat("about=\"", OntologyPropInfo.AboutRDFA, "\" ");

                if (Element.Propiedad.Tipo == TipoPropiedad.ObjectProperty || SpecificationProperty.TipoCampo == TipoCampoOntologia.Imagen)
                {
                    rdfa = string.Concat(rdfa, "rel=\"", OntologyPropInfo.PropertyRDFA, "\"");
                }
                else
                {
                    rdfa = string.Concat(rdfa, "property=\"", OntologyPropInfo.PropertyRDFA, "\"");
                }

                return rdfa;
            }

            return null;
        }

        /// <summary>
        /// Obtiene la propiedad de la entidad actual que coincide con un nombre.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <returns>Propiedad de la entidad actual que coincide con un nombre</returns>
        public SemanticPropertyModel GetProperty(string pName)
        {
            if (OntologyPropInfo == null && Properties != null)
            {
                foreach (SemanticPropertyModel propModel in Properties)
                {
                    if (propModel.OntologyPropInfo != null)
                    {
                        if (propModel.Element.Propiedad.Nombre == pName || propModel.Element.Propiedad.NombreFormatoUri == pName)
                        {
                            return propModel;
                        }
                    }
                    else
                    {
                        SemanticPropertyModel propHija = propModel.GetProperty(pName);

                        if (propHija != null)
                        {
                            return propHija;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }

}
