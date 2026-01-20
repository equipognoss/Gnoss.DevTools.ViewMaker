namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de seguidores de Perfil
    /// </summary>
    public class ProfilePageFollowersViewModel
    {
        /// <summary>
        /// Enumeración con los tipos de paginas de perfil
        /// </summary>
        public enum ProfilePageType
        {
            /// <summary>
            /// Segidores
            /// </summary>
            Followers,
            /// <summary>
            /// Personas a las que sigo
            /// </summary>
            Followed
        }


        /// <summary>
        /// Tipo de página de perfil
        /// </summary>
        public ProfilePageType PageType { get; set; }

        /// <summary>
        /// Lista de seguidores del perfil
        /// </summary>
        public List<ProfileModel> ProfileFollowers { get; set; }
        /// <summary>
        /// Número de seguidores del perfil
        /// </summary>
        public int NumProfileFollowers { get; set; }
        /// <summary>
        /// Lista de perfiles seguidos por el perfil
        /// </summary>
        public List<ProfileModel> ProfileFollowed { get; set; }
        /// <summary>
        /// Número de perfiles seguidos por el perfil
        /// </summary>
        public int NumProfileFollowed { get; set; }
    }
}
