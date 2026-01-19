using Es.Riam.Semantica.OWL;

namespace Es.Riam.Semantica.Plantillas
{
    public class EstiloPlantilla
    {
        #region Miembros

        #region Estáticos

        /// <summary>
        /// Ontologías ya cargadas.
        /// </summary>
        public volatile static Dictionary<Guid, KeyValuePair<Guid, Ontologia>> OntologiasCargadas = new Dictionary<Guid, KeyValuePair<Guid, Ontologia>>();

        /// <summary>
        /// Ontologías ya cargadas.
        /// </summary>
        public volatile static Dictionary<string, KeyValuePair<Guid, Ontologia>> OntologiasTrozosCargadas = new Dictionary<string, KeyValuePair<Guid, Ontologia>>();

        #endregion

        #region Constantes

        /// <summary>
        /// Propiedad Collection para tesauro semántico.
        /// </summary>
        public const string Collection_TesSem = "http://www.w3.org/2008/05/skos#Collection";

        /// <summary>
        /// Propiedad Source para tesauro semántico.
        /// </summary>
        public const string Source_TesSem = "http://purl.org/dc/elements/1.1/source";

        /// <summary>
        /// Propiedad Member para tesauro semántico.
        /// </summary>
        public const string Member_TesSem = "http://www.w3.org/2008/05/skos#member";

        /// <summary>
        /// Propiedad Identifier para tesauro semántico.
        /// </summary>
        public const string Identifier_TesSem = "http://purl.org/dc/elements/1.1/identifier";

        /// <summary>
        /// Propiedad PrefLabel para tesauro semántico.
        /// </summary>
        public const string PrefLabel_TesSem = "http://www.w3.org/2008/05/skos#prefLabel";

        /// <summary>
        /// Propiedad Broader para tesauro semántico.
        /// </summary>
        public const string Broader_TesSem = "http://www.w3.org/2008/05/skos#broader";

        /// <summary>
        /// Propiedad Narrower para tesauro semántico.
        /// </summary>
        public const string Narrower_TesSem = "http://www.w3.org/2008/05/skos#narrower";

        /// <summary>
        /// Propiedad Symbol para tesauro semántico.
        /// </summary>
        public const string Symbol_TesSem = "http://www.w3.org/2008/05/skos#symbol";

        /// <summary>
        /// Propiedad Concept para tesauro semántico.
        /// </summary>
        public const string Concept_TesSem = "http://www.w3.org/2008/05/skos#Concept";

        #endregion
        #endregion

        /// <summary>
        /// Comprueba si una propiedad es de una entidad de determinado tipo.
        /// </summary>
        /// <param name="pPropiedad">Propiedad</param>
        /// <param name="pEntidad">Entidad a la que pertenece la propiedad o NULL si se desea revisar el 'ElementoOntologia' de la propiedad</param>
        /// <param name="pTipoEntidad">Tipo de entidad o NULL (devolverá TRUE)</param>
        /// <returns>TRUE si una propiedad es de una entidad de determinado tipo, FALSE en caso contrario</returns>
        public static bool EsPropiedadDeTipoEntidad(Propiedad pPropiedad, ElementoOntologia pEntidad, string pTipoEntidad)
        {
            if (pTipoEntidad == null)
            {
                return true;
            }
            else if (pEntidad != null)
            {
                return (pEntidad.TipoEntidad == pTipoEntidad || pEntidad.TipoEntidad.Contains($"{pTipoEntidad}_bis") || pEntidad.SuperclasesUtiles.Contains(pTipoEntidad));
            }
            else if (pPropiedad.ElementoOntologia != null)
            {
                return (pPropiedad.ElementoOntologia.TipoEntidad == pTipoEntidad || pPropiedad.ElementoOntologia.TipoEntidad.Contains($"{pTipoEntidad}_bis") || pPropiedad.ElementoOntologia.SuperclasesUtiles.Contains(pTipoEntidad));
            }
            else
            {
                foreach (string dominio in pPropiedad.Dominio)
                {
                    if (dominio == pTipoEntidad || dominio.Contains($"{pTipoEntidad}_bis"))
                    {
                        return true;
                    }
                    else
                    {
                        ElementoOntologia entAux = pPropiedad.Ontologia.GetEntidadTipo(dominio, false);

                        if (entAux != null && entAux.SuperclasesUtiles.Contains(pTipoEntidad))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
