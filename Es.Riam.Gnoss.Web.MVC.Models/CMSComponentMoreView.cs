namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo mas vistos
    /// </summary>
    [Serializable]
    public class CMSComponentMoreView : CMSComponent
    {
        /// <summary>
        /// Lista de recursos del componente
        /// </summary>
        public List<ResourceModel> MoreVisitedWeek { get; set; }
        /// <summary>
        /// Lista de recursos del componente
        /// </summary>
        public List<ResourceModel> MoreVisitedMonth { get; set; }
        /// <summary>
        /// Lista de recursos del componente
        /// </summary>
        public List<ResourceModel> MoreVisited { get; set; }

    }
}
