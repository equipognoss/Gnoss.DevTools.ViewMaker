using Es.Riam.Gnoss.Web.MVC.Models.ViewModels;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para el espacio personal de GNOSS.
    /// </summary>
    public class PersonalSpaceModel
    {
        /// <summary>
        /// Número de resultados total en el espaciopersonal.
        /// </summary>
        public int TotalNumberResults { get; set; }

        /// <summary>
        /// MegaBytes utilizados en el espacio personal.
        /// </summary>
        public decimal UsedMegaBytes { get; set; }

        /// <summary>
        /// MegaBytes libres en el espacio personal.
        /// </summary>
        public decimal FreeMegaBytes { get; set; }

        /// <summary>
        /// Url para administrar las categorías del espacio personal.
        /// </summary>
        public string AdminCategoriesUrl { get; set; }

        /// <summary>
        /// Url para añadir nuevo recurso.
        /// </summary>
        public string AddNewResourceUrl { get; set; }

        /// <summary>
        /// Modelo para la búsqueda.
        /// </summary>
        public SearchViewModel SearchViewModel { get; set; }

        /// <summary>
        /// Título para la página.
        /// </summary>
        public string PageTitle { get; set; }
    }
}
