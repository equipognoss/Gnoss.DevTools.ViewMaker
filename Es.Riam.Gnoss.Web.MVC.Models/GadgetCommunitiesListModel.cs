namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de un gadget de tipo Lista de comunidades
    /// </summary>
    public partial class GadgetCommunitiesListModel : GadgetModel
    {
        /// <summary>
        /// Lista de comunidades
        /// </summary>
        public List<CommunityModel> Communities { get; set; }
    }
}
