namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de editar un grupo
    /// </summary>
    public class GroupEditViewModel
    {
        /// <summary>
        /// Ficha del grupo
        /// </summary>
        public GroupCardModel Group { get; set; }

        public string UrlSaveGroup { get; set; }

        public Dictionary<Guid, string> Participants { get; set; }

        public bool EsGrupoDeOrganizacion { get; set; }

    }
}
