namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Tesauro
    /// </summary>
    public class CMSComponentThesaurus : CMSComponent
    {
        /// <summary>
        /// Obtiene o establece si tiene imagen
        /// </summary>
        public bool Image { get; set; }

        /// <summary>
        /// Nombre de la categoría
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Lista de categorías a mostrar
        /// </summary>
        public List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// URL del índice
        /// </summary>
        public string UrlIndex { get; set; }

        /// <summary>
        /// URL base de las categorías
        /// </summary>
        public string UrlBaseCategories { get; set; }
    }
}
