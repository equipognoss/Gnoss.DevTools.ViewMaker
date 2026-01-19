namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Resumen Perfil
    /// </summary>
    public class CMSComponentProfileSummary : CMSComponent
    {
        public string ProfileUrl { get; set; }
        public string ProfileName { get; set; }
        public string ProfileUrlImage { get; set; }
        public string ProfileFollowersUrl { get; set; }
        public int ProfileFollowersNumber { get; set; }
        public string ProfileFollowingUrl { get; set; }
        public int ProfileFollowingNumber { get; set; }
        public string ProfilePersonalResourcesUrl { get; set; }
        public int ProfilePersonalResourcesNumber { get; set; }
        public string ProfileCommunityResourcesUrl { get; set; }
        public int ProfileCommunityResourcesNumber { get; set; }

    }
}
