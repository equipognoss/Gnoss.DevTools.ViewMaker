namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    // <summary>
    /// View Model de la pagina de editar bio
    /// </summary>
    public class EditCvCommunityModel
    {
        /// <summary>
        /// Lista de curriculums disponibles
        /// </summary>
        public Dictionary<Guid, string> CvList { get; set; }
        /// <summary>
        /// Curriculum seleccionado en la comunidad
        /// </summary>
        public Guid CvSelected { get; set; }
    }
}
