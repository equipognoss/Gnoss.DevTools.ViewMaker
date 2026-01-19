namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Datos comunidadTesauro
    /// </summary>
    [Serializable]
    public class CMSComponentCommunityInfo : CMSComponent
    {
        public int ResourcesCount { get; set; }
        public int IdentitiesCount { get; set; }
        public string ResourcesUrl { get; set; }
        public string IdentitiesUrl { get; set; }
    }
}
