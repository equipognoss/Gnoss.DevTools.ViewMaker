namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View Model de la pagina de indice
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Lista de categorias
        /// </summary>
        public List<CategoryModel> Categories { get; set; }
        /// <summary>
        /// Url para construir los enlaces de las categorias
        /// </summary>
        public string UrlBaseCategories { get; set; }
    }
}
