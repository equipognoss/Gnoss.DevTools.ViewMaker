using Es.Riam.Semantica.OWL;
using Es.Riam.Semantica.Plantillas;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class SemanticEntityModel
    {
        /// <summary>
        /// Modelo semántico del SEM CMS.
        /// </summary>
        public SemanticResourceModel SemanticResourceModel { get; set; }

        /// <summary>
        /// Entidad semántica a la que representa el modelo.
        /// </summary>
        public ElementoOntologia Entity { get; set; }

        /// <summary>
        /// ID de la entidad.
        /// </summary>
        public string Key { get { return Entity.ID; } }

        /// <summary>
        /// Configuración de la plantilla para esta entidad.
        /// </summary>
        public EstiloPlantillaEspecifEntidad SpecificationEntity
        {
            get
            {
                if (Entity != null)
                {
                    return Entity.EspecifEntidad;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Profunidad dentro de la jerarquia de entiades. Dicha profundidad se obtiene mediante su relación através de sus propiedades.
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Título que representa a la entidad actual según su tipo.
        /// </summary>
        public string EntityNameForTitle { get; set; }

        /// <summary>
        /// Instancias de las subclases de la entidad actual.
        /// </summary>
        public List<SemanticEntityModel> SubEntities { get; set; }

        /// <summary>
        /// Instancia de la superclase de la entidad actual.
        /// </summary>
        public SemanticEntityModel SuperEntity { get; set; }

        /// <summary>
        /// En caso de que la entiad tenga subEntidades, si alguna está seleccionada se indica con esta propiedad. Si no será la primera por defecto.
        /// </summary>
        public SemanticEntityModel SelectedSubEntity { get; set; }

        /// <summary>
        /// Indica si el contenedor que representa la entiadad debe pintarse oculto. Por ejemplo si es una subEntidad no seleccionada.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Propiedades que contiene el modelo de la entidad actual.
        /// </summary>
        public List<SemanticPropertyModel> Properties { get; set; }

        /// <summary>
        /// Valor de typeof para el RDFa.
        /// </summary>
        public string TypeofRDFA { get; set; }

        /// <summary>
        /// Valor de about para el RDFa.
        /// </summary>
        public string AboutRDFA { get; set; }

        /// <summary>
        /// Mapa Google que representa la entidad. Sólo tendrá valor en el caso de que se configure que la entidad es un mapa Google.
        /// </summary>
        public GoogleMap GoogleMapInfo { get; set; }

        /// <summary>
        /// Indica que se debe mostrar en modo lectura.
        /// </summary>
        public bool ReadMode { get; set; }

        /// <summary>
        /// Clase que representa un mapa de Google.
        /// </summary>
        [Serializable]
        public class GoogleMap
        {
            /// <summary>
            /// Latitud del mapa. Si hay latitud debe haber logitud. Habiendo estas se descarta el valor de ruta y color.
            /// </summary>
            public string Latitude { get; set; }

            /// <summary>
            /// Longitud del mapa. Si hay logitud debe haber latitud. Habiendo estas se descarta el valor de ruta y color.
            /// </summary>
            public string Longitude { get; set; }

            /// <summary>
            /// Ruta del mapa. Solo se aplica si la latitud y logitud son nulos.
            /// </summary>
            public string Route { get; set; }

            /// <summary>
            /// Color de la ruta del mapa. Solo es aplicable si hay ruta.
            /// </summary>
            public string RouteColor { get; set; }

            /// <summary>
            /// Clave del API Javascript de Google.
            /// </summary>
            public string JsApiGoogleKey { get; set; }
        }

        #region Métodos ayuda vistas

        /// <summary>
        /// Obtiene la propiedad de la entidad actual que coincide con un nombre.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <returns>Propiedad de la entidad actual que coincide con un nombre</returns>
        public SemanticPropertyModel GetProperty(string pName)
        {
            foreach (SemanticPropertyModel propModel in Properties)
            {
                if (propModel.OntologyPropInfo != null)
                {
                    if (propModel.Element.Propiedad != null && (propModel.Element.Propiedad.Nombre == pName || propModel.Element.Propiedad.NombreFormatoUri == pName))
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

            return null;
        }

        /// <summary>
        /// Obtiene una propiedad que contienen alguna de las entidades del SEMCMS indicando el nivel de la propiedad por un path separando las propiedades por los caracteres '@@@'. Ejemplo: http://www.cidoc-crm.org/cidoc-crm#p14_carried_out_by@@@http://www.pradomuseum/201403#author@@@http://www.ecidoc/201403#p131_E82_p102_has_title.
        /// </summary>
        /// <param name="pPath">Path con los nombres de las propiedades</param>
        /// <returns>Propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad indicado por un path</returns>
        public SemanticPropertyModel GetPropertyByPath(string pPath)
        {
            if (pPath.Contains("@@@"))
            {
                string nombrePropActual = pPath.Substring(0, pPath.IndexOf("@@@"));
                SemanticPropertyModel propRelacion = GetProperty(nombrePropActual);

                if (propRelacion != null && propRelacion.Element.Propiedad.Tipo == TipoPropiedad.ObjectProperty && propRelacion.PropertyValues.Count > 0)
                {
                    return propRelacion.FirstPropertyValue.RelatedEntity.GetPropertyByPath(pPath.Substring(pPath.IndexOf("@@@") + 3));
                }
            }
            else
            {
                return GetProperty(pPath);
            }

            return null;
        }


        /// <summary>
        /// Obtiene el primer valor de la propiedad que contienen alguna de las entidades del SEMCMS indicando el nivel de la propiedad por un path separando las propiedades por los caracteres '@@@'. Ejemplo: http://www.cidoc-crm.org/cidoc-crm#p14_carried_out_by@@@http://www.pradomuseum/201403#author@@@http://www.ecidoc/201403#p131_E82_p102_has_title.
        /// </summary>
        /// <param name="pPath">Path con los nombres de las propiedades</param>
        /// <returns>Primer valor de la propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad indicado por un path</returns>
        public string GetFirstValuePropertyByPath(string pPath)
        {
            SemanticPropertyModel propModel = GetPropertyByPath(pPath);

            if (propModel != null && propModel.FirstPropertyValue != null)
            {
                return propModel.FirstPropertyValue.Value;
            }

            return null;
        }

        /// <summary>
        /// Obtiene el RDFa de la propiedad que contienen alguna de las entidades del SEMCMS indicando el nivel de la propiedad por un path separando las propiedades por los caracteres '@@@'. Ejemplo: http://www.cidoc-crm.org/cidoc-crm#p14_carried_out_by@@@http://www.pradomuseum/201403#author@@@http://www.ecidoc/201403#p131_E82_p102_has_title.
        /// </summary>
        /// <param name="pPath">Path con los nombres de las propiedades</param>
        /// <returns>RDFa de la propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad indicado por un path. Ejemplo: about="http://a..." property="dc:title".</returns>
        public string GetRDFAPropertyByPath(string pPath)
        {
            return SemanticResourceModel.GetRDFAProperty(GetPropertyByPath(pPath));
        }

        /// <summary>
        /// Obtiene el RDFa de la entidad.
        /// </summary>
        /// <returns>RDFa de la entidad. Ejemplo: about="http://a..." typeof="http://b...".</returns>
        public string GetRDFA()
        {
            if (AboutRDFA != null && TypeofRDFA != null)
            {
                return string.Concat("about=\"", AboutRDFA, "\" typeof=\"", TypeofRDFA, "\"");
            }

            return null;
        }

        #endregion
    }

}
