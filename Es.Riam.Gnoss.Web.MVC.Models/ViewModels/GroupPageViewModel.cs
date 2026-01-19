namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de Perfil
    /// </summary>
    public class GroupPageViewModel
    {
        /// <summary>
        /// Ficha del grupo
        /// </summary>
        public GroupCardModel Group { get; set; }
        /// <summary>
        /// Lista de participantes del grupo
        /// </summary>
        public List<ProfileModel> ListMembers { get; set; }
        /// <summary>
        /// Número de participantes del grupo
        /// </summary>
        public int NumMembers { get; set; }
        /// <summary>
        /// Número de página de miembros del grupo
        /// </summary>
        public int NumPage { get; set; }

        /// <summary>
        /// Acciones que se pueden realizar sobre este grupo
        /// </summary>
        public ActionsModel Actions { get; set; }

        /// <summary>
        /// Modelo de acciones que se pueden realizar sobre este grupo
        /// </summary>
        [Serializable]
        public partial class ActionsModel
        {
            public bool Edit { get; set; }
            public bool Delete { get; set; }
            public bool RemoveMember { get; set; }
            public bool LeaveGroup { get; set; }
            public bool RequestAccess { get; set; }
            public bool AsignarAGrupo { get; set; }
            public bool AddMember { get; set; }
        }

        public string UrlLeaveGroup { get; set; }
        public string UrlRequestAccess { get; set; }
        public string UrlLoadMore { get; set; }
        public string UrlEditGroup { get; set; }
        public string UrlDeleteGroup { get; set; }
        public string UrlAddMember { get; set; }
        public string UrlRemoveMember { get; set; }

    }
}
