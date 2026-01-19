using Es.Riam.Semantica;
using Es.Riam.Semantica.OWL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Es.Riam.Semantica.OWL
{
    /// <summary>
    /// Clase que gestiona todo lo relacionado con la lectura y escritura de OWL.
    /// </summary>
    [Serializable]
    public class GestionOWL
    {
        #region Propiedades

        /// <summary>
        /// Devuelve o establece la Url de la ontología.
        /// </summary>
        public string UrlOntologia { get; set; }

        /// <summary>
        /// Devuelve o establece el namespace de la ontología.
        /// </summary>
        public string NamespaceOntologia { get; set; }

        /// <summary>
        /// Obtiene la URL de la intranet de GNOSS
        /// </summary>
        public static string URLIntragnoss { get; set; }

        /// <summary>
        /// Ontología que se está manejando.
        /// </summary>
        public Ontologia Ontologia { get; set; }

        /// <summary>
        /// Indica que no se permiten nuevos elementos que no estén en la ontología si es distinta de NULL. Contiene los errores en el RDF.
        /// </summary>
        private List<string> NoPermitirNuevosElementos { get; set; }

        /// <summary>
        /// Namespaces del RDF que se está leyendo.
        /// </summary>
        public Dictionary<string, string> NamespacesRDFLeyendo { get; set; }

        #endregion

        /// <summary>
        /// Construye una entidad a partir de otra.
        /// </summary>
        /// <param name="pEntidad">entidad a partir de la cual se creará la nueva entidad.</param>
        public virtual ElementoOntologia CrearElementoOntologia(ElementoOntologia pEntidad)
        {
            return new ElementoOntologia(pEntidad);
        }

        /// <summary>
        /// Crea una entidad a partir de un tipo de entidad.
        /// </summary>
        /// <param name="pTipoEntidad">tipo de entidad.</param>
        /// <param name="pNamespaceOntologia">Namespace de la ontología</param>
        /// <param name="pUrlOntologia">Url de la ontología</param>
        public virtual ElementoOntologia CrearElementoOntologia(string pTipoEntidad, string pUrlOntologia, string pNamespaceOntologia)
        {
            if (NoPermitirNuevosElementos != null && !Ontologia.TiposEntidades.Contains(pTipoEntidad))
            {
                NoPermitirNuevosElementos.Add("El tipo de entidad '" + pTipoEntidad + "' no pertenece a la ontología.");
            }

            return new ElementoOntologia(pTipoEntidad, pUrlOntologia, pNamespaceOntologia, Ontologia);
        }

        /// <summary>
        /// Obtiene la url base para un tipo de entidad
        /// </summary>
        /// <param name="pTipoEntidad">Tipo de entidad</param>
        /// <returns></returns>
        public static string ObtenerUrlEntidad(string pTipoEntidad)
        {
            string url = URLIntragnoss;
            return url + "items/";
        }
    }
}
