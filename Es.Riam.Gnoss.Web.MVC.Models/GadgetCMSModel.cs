namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de un gadget de tipo CMS
    /// </summary>
    [Serializable]
    public partial class GadgetCMSModel : GadgetModel
    {
        /// <summary>
        /// Objeto CMS
        /// </summary>
        public CMSComponent CMSComponent { get; set; }
    }
}
