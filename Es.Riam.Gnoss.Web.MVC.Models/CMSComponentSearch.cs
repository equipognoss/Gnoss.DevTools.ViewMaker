namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo buscador
    /// </summary>
    [Serializable]
    public class CMSComponentSearch : CMSComponent
    {
        /// <summary>
        /// Resultado de la busqueda del componente buscador
        /// </summary>
        public ResultadoModel Resultado { get; set; }

        /// <summary>
        /// Titulo del atributo de Búsqueda
        /// </summary>
        public string AttributeSearchTittle { get; set; }

        /// <summary>
        /// Filtro de la búsqueda
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// URL del buscador
        /// </summary>
        public string UrlSearcherCMS { get; set; }
    }
}
