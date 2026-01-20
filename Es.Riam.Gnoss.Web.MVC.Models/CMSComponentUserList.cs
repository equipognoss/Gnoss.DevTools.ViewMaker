namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Listado de Usuarios
    /// </summary>
    public class CMSComponentUserList : CMSComponent
    {
        public List<ProfileModel> Users { get; set; }
    }
}
