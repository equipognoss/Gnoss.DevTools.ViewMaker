namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Usuarios Recomendados
    /// </summary>
    public class CMSComponentRecommendedUsers : CMSComponent
    {
        public List<ProfileModel> RecomendedUsers { get; set; }
    }
}
