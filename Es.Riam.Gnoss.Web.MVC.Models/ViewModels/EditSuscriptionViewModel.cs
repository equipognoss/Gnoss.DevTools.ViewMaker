namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de "Editar suscripcion" 
    /// </summary>
    public class EditSuscriptionViewModel
    {
        /// <summary>
        /// Indica si estan activas las notificaciones de suscripciones en la comunidad
        /// </summary>
        public bool ActiveNotifications { get; set; }
        /// <summary>
        /// Identificadores con las categorias seleccionadas, separadas por comas
        /// </summary>
        public string SelectedCategories { get; set; }
        /// <summary>
        /// Indica si se quieren recibir suscripciones
        /// </summary>
        public bool ReceiveSubscription { get; set; }
        /// <summary>
        /// Indica si la periodicidad de las subscripciones es diaria
        /// </summary>
        public bool DailySubscription { get; set; }
        /// <summary>
        /// Indica si la periodicidad de las subscripciones es semanal
        /// </summary>
        public bool WeeklySubscription { get; set; }
        /// <summary>
        /// Lista con las categorias de la comunidad
        /// </summary>
        public List<CategoryModel> Categories { get; set; }
    }
}
