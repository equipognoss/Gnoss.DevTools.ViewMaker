namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de "Acerca de..."
    /// </summary>
    public class AboutTheCommunityViewModel
    {
        /// <summary>
        /// Número de recursos publicos de la comunidad
        /// </summary>
        public int NumberOfResources { get; set; }
        /// <summary>
        /// Número de personas y de organizaciones de la comunidad
        /// </summary>
        public int NumberOfPersonOrganizations { get; set; }
        /// <summary>
        /// Descripción de la comunidad
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Fecha de fundación de la comunidad
        /// </summary>
        public DateTime FoundationDate { get; set; }
        /// <summary>
        /// Lista de certificaciones configuradas en la comunidad
        /// </summary>
        public List<string> CertificationLevels { get; set; }
        /// <summary>
        /// Lista de categorias en las que esta categorizada la comunidad
        /// </summary>
        public List<CategoryModel> Categories { get; set; }
        /// <summary>
        /// Lista de tags en los que esta etiquetada la comunidad
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Lista de administradores de la comunidad
        /// </summary>
        public List<ProfileModel> Administrators { get; set; }
        /// <summary>
        /// Politica de certificación de la comunidad
        /// </summary>
        public string CertificationPolicy { get; set; }
        /// <summary>
        /// Indica si las invitaciones estan disponibles en la comunidad
        /// </summary>
        public bool InvitationsAvailable { get; set; }
        /// <summary>
        /// Indica si las votaciones estan disponibles en la comunidad
        /// </summary>
        public bool RatingsAvailable { get; set; }
        /// <summary>
        /// Indica si los comentarios estan disponibles en la comunidad
        /// </summary>
        public bool CommentsAvailable { get; set; }
    }
}
