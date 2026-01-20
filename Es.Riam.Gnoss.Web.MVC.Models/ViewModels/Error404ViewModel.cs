namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la página de error
    /// </summary>
    [Serializable]
    public class Error404ViewModel
    {
        /// <summary>
        /// Código de error
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Título de la página
        /// </summary>
        public string Tittle { get; set; }
        /// <summary>
        /// Error de la página
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Recursos relacionados
        /// </summary>
        public List<ResourceModel> ResourcesList { get; set; }

    }
}
