namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Menu
    /// </summary>
    public class CMSComponentMenu : CMSComponent
    {
        /// <summary>
        /// Representa un Item del componente menú
        /// </summary>
        public partial class CMSComponentMenuItem
        {
            /// <summary>
            /// Nombre del item del menu
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Enlace del item del menu
            /// </summary>
            public string Link { get; set; }
            /// <summary>
            /// Especifica si el item está activo
            /// </summary>
            public bool Active { get; set; }
            /// <summary>
            /// Lista de items
            /// </summary>
            public List<CMSComponentMenuItem> ItemList { get; set; }
        }
        /// <summary>
        /// Lista de items del componente
        /// </summary>
        public List<CMSComponentMenuItem> ItemList { get; set; }
    }
}
