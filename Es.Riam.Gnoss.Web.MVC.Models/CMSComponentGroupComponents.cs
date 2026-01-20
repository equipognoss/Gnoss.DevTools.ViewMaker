namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS que es un Grupo de componentes
    /// </summary>
    public class CMSComponentGroupComponents : CMSComponent
    {
        /// <summary>
        /// Lista de componentes que pertenecen al grupo
        /// </summary>
        public List<CMSComponent> ComponentList { get; set; }
    }
}
