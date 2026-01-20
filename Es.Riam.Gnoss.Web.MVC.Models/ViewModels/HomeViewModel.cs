namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la home de la comunidad
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// Lista de los perfiles de los usuarios mas activos
        /// </summary>
        public List<ProfileModel> MostActiveUsers { get; set; }
        /// <summary>
        /// Lista de los ultimos usuarios registrados en la comunidad
        /// </summary>
        public List<ProfileModel> LastUsers { get; set; }
        /// <summary>
        /// Actividad reciente en la comunidad
        /// </summary>
        public RecentActivity RecentActivity { get; set; }
        /// <summary>
        /// Lista de gadgets configurados en la comunidad
        /// </summary>
        public List<GadgetModel> Gadgets { get; set; }
    }
}
