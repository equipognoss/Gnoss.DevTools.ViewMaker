using Es.Riam.Gnoss.Web.MVC.Models;
using Es.Riam.Semantica.OWL;
using Es.Riam.Semantica.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class SemanticResourceModel
    {
        /// <summary>
        /// Indica si se está haciendo una carga masiva de recursos semánticos.
        /// </summary>
        public bool MassiveResourceLoad { get; set; }

        /// <summary>
        /// Indica si se está editando un recurso dentro de una carga masiva de recursos semánticos.
        /// </summary>
        public bool EditingMassiveResourceLoad { get; set; }

        /// <summary>
        /// ID del recurso que se está editando dentro de una carga masiva de recursos semánticos.
        /// </summary>
        public Guid EditingMassiveResourceID { get; set; }

        /// <summary>
        /// Url para editar las categorías del tesauro en otra comunidad. Tendrá valor en caso de que no se puedan editar las categoriás en la comunidad actual y hay que editarlas en la url indicada.
        /// </summary>
        public string OtherCommunityEditCategoriesUrl { get; set; }

        /// <summary>
        /// Indica que las categorias del tesauro no son obligatorias, por lo que no deberá pintarse el control para seleccionar categorías.
        /// </summary>
        public bool ThesaurusCategoryNotRequired { get; set; }

        /// <summary>
        /// Indica si las etiquetas de un recurso semántico no son obligatorias, por lo que no deberá realizar la validación de etiquetas.
        /// </summary>
        public bool TagsNotRequired { get; set; }

        /// <summary>
        /// Indica que el formulario semánico contiene el título y la descripción del
        /// </summary>
        public bool SemCmsContainsTitleAndDescription { get; set; }

        /// <summary>
        /// Indica si se debe generar el SEM CMS para su lectura, es decir, en la ficha del recurso o para su edición si es FALSE.
        /// </summary>
        public bool ReadMode { get; set; }

        /// <summary>
        /// Indica si se debe ocultar la información puesto que el usuario actual no es miembro de la comunidad y no debe ver el SEM CMS.
        /// </summary>
        public bool HideInfoIsNotMember { get; set; }

        /// <summary>
        /// Título de la información para los no miembros de la comunidad
        /// </summary>
        public string TitleInfoIsNotMember { get; set; }

        /// <summary>
        /// Link de registro de la información para los no miembros de la comunidad
        /// </summary>
        public string RegisterLinkInfoIsNotMember { get; set; }

        /// <summary>
        /// Namespace de la ontología.
        /// </summary>
        public string OntologyNamespace { get; set; }

        /// <summary>
        /// Url de la ontología.
        /// </summary>
        public string OntologyUrl { get; set; }

        /// <summary>
        /// Namespaces definidos en la ontología.
        /// </summary>
        public Dictionary<string, string> OntologyNamespaces { get; set; }

        /// <summary>
        /// Propiedad RDF que vincula un formulario semántico con un recurso.
        /// </summary>
        public string DocSemCmsProperty { get; set; }

        /// <summary>
        /// Entidades raíz del SEM CMS. Son las que no son hijas de ninguna otra entidad de la ontología.
        /// </summary>
        public List<SemanticEntityModel> RootEntities { get; set; }

        /// <summary>
        /// Valor de la imagen representante del recurso. Contendrá la url de la imagen con sus tamaños.
        /// </summary>
        public string ImageRepresentativeValue { get; set; }

        /// <summary>
        /// Idioma por defecto de la ontología, solo tiene valor si la edición es multiIdioma.
        /// </summary>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// Idioma disponibles para la ontología, solo tiene valor si la edición es multiIdioma.
        /// </summary>
        public Dictionary<string, string> AvailableLanguages { get; set; }

        /// <summary>
        /// Título de la página configurado en el XML de configuración de la ontología.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Información extra de las características de los elementos para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryElementsFeaturesInfo { get; set; }

        /// <summary>
        /// RDF auxiliar para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryRDFInfo { get; set; }

        /// <summary>
        /// Herencias entre entidades para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryInheritancesInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de los IDs de los controles para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryIDRegisterInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de los nombre de las categorias de tesauros semánticos para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryCategoryTesSemNameInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de los valores grafo dependientes para la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryDependentGraphValuesInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de las ontologías externas editables dentro del recurso para la edición del SEM CMS.
        /// </summary>
        public string AuxiliarySubOntologiesExtInfo { get; set; }

        /// <summary>
        /// Información auxiliar acerca de los IDs de las entidades en la edición del SEM CMS.
        /// </summary>
        public string AuxiliaryEntityIDRegisterInfo { get; set; }

        /// <summary>
        /// Indica si el SEMCMS debe pintarse encima del menú de la ficha del recurso.
        /// </summary>
        public bool SemCmsDrawOverMenu { get; set; }

        /// <summary>
        /// Indica si se debe ocultar el título del recurso GNOSS.
        /// </summary>
        public bool HideResourceTitle { get; set; }

        /// <summary>
        /// Título del recurso al que está vinculado el SEMCMS.
        /// </summary>
        public string DocumentTitle { get; set; }

        /// <summary>
        /// IDs separados por comas de los controles de las propiedades que están configuradas como título del recurso.
        /// </summary>
        public string TitlePropretyIDs { get; set; }

        /// <summary>
        /// IDs separados por comas de los controles de las propiedades que están configuradas como descripción del recurso.
        /// </summary>
        public string DescriptionPropretyIDs { get; set; }

        /// <summary>
        /// Error en la generación del SEM CMS para el administrador de la comunidad.
        /// </summary>
        public string AdminGenerationError { get; set; }

        /// <summary>
        /// Indica si alguna propiedad del SEM CMS tiene configurado el JCROP.
        /// </summary>
        public bool JcropAvailable { get; set; }

        /// <summary>
        /// Indica que hay alguna propiedad en la ontología en la que se muestra un selector de fecha con hora.
        /// </summary>
        public bool DateWithTimeAvailable { get; set; }

        /// <summary>
        /// Indica si el formulario es vitual, por lo que los datos RDF se guardarán en un servicio configurado externo a GNOSS.
        /// </summary>
        public bool VirtualForm { get; set; }

        /// <summary>
        /// Url del javascript de la ontología.
        /// </summary>
        public string OntologyJS { get; set; }

        /// <summary>
        /// Url del CSS de la ontología.
        /// </summary>
        public string OntologyCSS { get; set; }

        /// <summary>
        /// Url para realizar las acciones de MCV.
        /// </summary>
        public string MvcActionsUrl { get; set; }

        /// <summary>
        /// Indica si tiene agregado un mapa
        /// </summary>
        public bool MapAgregated { get; set; }

        #region Métodos ayuda vistas

        /// <summary>
        /// Obtiene una propiedad que contienen las entidades principales del SEMCMS.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <returns></returns>
        public SemanticPropertyModel GetMainProperty(string pName)
        {
            foreach (SemanticEntityModel entModel in RootEntities)
            {
                SemanticPropertyModel propModel = entModel.GetProperty(pName);

                if (propModel != null)
                {
                    return propModel;
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
            foreach (SemanticEntityModel entModel in RootEntities)
            {
                SemanticPropertyModel propModel = entModel.GetPropertyByPath(pPath);

                if (propModel != null)
                {
                    return propModel;
                }
            }

            return null;
        }

        public void HidePropertyByPath(string pPath)
        {
            foreach (SemanticEntityModel entModel in RootEntities)
            {
                SemanticPropertyModel propModel = entModel.GetPropertyByPath(pPath);
                if (propModel != null)
                {
                    propModel.Hidden = true;
                    return;
                }
            }

        }

        /// <summary>
        /// Obtiene el primer valor de la propiedad que contienen alguna de las entidades del SEMCMS indicando el nivel de la propiedad por un path separando las propiedades por los caracteres '@@@'. Ejemplo: http://www.cidoc-crm.org/cidoc-crm#p14_carried_out_by@@@http://www.pradomuseum/201403#author@@@http://www.ecidoc/201403#p131_E82_p102_has_title.
        /// </summary>
        /// <param name="pPath">Path con los nombres de las propiedades</param>
        /// <returns>Primer valor de la propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad indicado por un path</returns>
        public string GetFirstValuePropertyByPath(string pPath)
        {
            SemanticPropertyModel propModel = null;
            foreach (SemanticEntityModel entModel in RootEntities)
            {
                propModel = entModel.GetPropertyByPath(pPath);

                if (propModel != null)
                {
                    break;
                }
            }

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
            return GetRDFAProperty(GetPropertyByPath(pPath));
        }

        /// <summary>
        /// Obtiene el RDFa de una propiedad.
        /// </summary>
        /// <param name="pPropiedad">Propiedad</param>
        /// <returns>RDFa de la propiedad</returns>
        public string GetRDFAProperty(SemanticPropertyModel pPropiedad)
        {
            if (pPropiedad != null)
            {
                return pPropiedad.GetRDFA();
            }

            return null;
        }

        /// <summary>
        /// Obtiene el RDFa de la entidad.
        /// </summary>
        /// <param name="pEntidad">Entidad</param>
        /// <returns>RDFa de la entidad. Ejemplo: about="http://a..." typeof="http://b...".</returns>
        public string GetRDFAEntity(SemanticEntityModel pEntidad)
        {
            if (pEntidad != null)
            {
                return pEntidad.GetRDFA();
            }

            return null;
        }

        /// <summary>
        /// Obtiene los namespaces del RDFa del recurso.
        /// </summary>
        /// <returns>Namespaces del RDFa del recurso. Ejemplo: xmlns:arecipe="http://gnoss.co... xmlns:gnoss="http://gnos....</returns>
        public string GetRDFANamespaces()
        {
            string xmlns = "xmlns:" + OntologyNamespace + "=\"" + OntologyUrl + "\"";

            foreach (string keyName in OntologyNamespaces.Keys)
            {
                if (OntologyNamespaces[keyName] != "rdf" && OntologyNamespaces[keyName] != "owl" && OntologyNamespaces[keyName] != "xsd" && OntologyNamespaces[keyName] != "rdfs")
                {
                    xmlns = string.Concat(xmlns, " xmlns:", OntologyNamespaces[keyName], "=\"", keyName, "\"");
                }
            }

            xmlns = string.Concat(xmlns, "xmlns:sioc=\"http://rdfs.org/sioc/ns#\" xmlns:gnoss=\"http://gnoss.com/gnoss.owl#\"");

            return xmlns;
        }

        /// <summary>
        /// Obtiene una propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <returns>Propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad</returns>
        public SemanticPropertyModel GetPropertyAtAnyLevel(string pName)
        {
            return GetPropertyAtAnyLevel(pName, null);
        }

        /// <summary>
        /// Obtiene una propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <param name="pEntityType">Tipo de la entidad que contiene la propiedad</param>
        /// <returns>Propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad</returns>
        public SemanticPropertyModel GetPropertyAtAnyLevel(string pName, string pEntityType)
        {
            foreach (SemanticEntityModel entModel in RootEntities)
            {
                SemanticPropertyModel propModel = GetPropertyAtAnyLevel(pName, null, entModel);

                if (propModel != null)
                {
                    return propModel;
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene una propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad.
        /// </summary>
        /// <param name="pName">Nombre de la propiedad</param>
        /// <param name="pEntityType">Tipo de la entidad que contiene la propiedad</param>
        /// <param name="pEntityModel">Entidad modelo sobre la que buscar</param>
        /// <returns>Propiedad que contienen alguna de las entidades del SEMCMS, en cualquier nivel de jerarquia de la propiedad</returns>
        public SemanticPropertyModel GetPropertyAtAnyLevel(string pName, string pEntityType, SemanticEntityModel pEntityModel)
        {
            if (pEntityModel != null && pEntityModel.Entity != null)
            {
                foreach (SemanticPropertyModel propiedad in pEntityModel.Properties)
                {
                    if (propiedad.OntologyPropInfo == null)
                    {
                        continue;
                    }

                    if ((propiedad.Element.Propiedad.Nombre == pName || propiedad.Element.Propiedad.NombreFormatoUri == pName) && EstiloPlantilla.EsPropiedadDeTipoEntidad(propiedad.Element.Propiedad, pEntityModel.Entity, pEntityType))
                    {
                        return propiedad;
                    }

                    if (propiedad.Element.Propiedad.Tipo == TipoPropiedad.ObjectProperty)
                    {
                        foreach (SemanticPropertyModel.PropertyValue propValue in propiedad.PropertyValues)
                        {
                            SemanticPropertyModel propAux = GetPropertyAtAnyLevel(pName, pEntityType, propValue.RelatedEntity);
                            if (propAux != null)
                            {
                                return propAux;
                            }
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }

}
