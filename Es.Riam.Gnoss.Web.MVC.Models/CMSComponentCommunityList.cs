namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Listado de comunidades
    /// </summary>
    [Serializable]
    public class CMSComponentCommunityList : CMSComponent
    {
        public List<CommunityModel> Communities { get; set; }
    }
}
