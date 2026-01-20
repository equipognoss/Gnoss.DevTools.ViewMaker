namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS que es un listado de recursos
    /// </summary>
    public class CMSComponentResourceList : CMSComponent
    {
        /// <summary>
        /// Lista de recursos del componente
        /// </summary>
        public List<ResourceModel> ResourceList { get; set; }
        /// <summary>
        /// URL ver más
        /// </summary>
        public string URLSeeMore { get; set; }

    }
}
