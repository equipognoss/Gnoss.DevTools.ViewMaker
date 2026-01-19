namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Actividad reciente
    /// </summary>
    [Serializable]
    public class CMSComponentRecentActivity : CMSComponent
    {
        /// <summary>
        /// Modelo de actividad reciente
        /// </summary>
        public RecentActivity RecentActivity { get; set; }
    }
}
