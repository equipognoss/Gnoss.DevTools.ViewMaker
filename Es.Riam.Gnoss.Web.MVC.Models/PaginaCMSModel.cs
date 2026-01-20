namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de una página del CMS
    /// </summary>
    public partial class PaginaCMSModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Identificador de la pestanya del CMS
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Título del contacto
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Lista de idiomas en los que está disponible la página
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// Url de la pestanya del CMS
        /// </summary>
        public string Url { get; set; }
    }
}
