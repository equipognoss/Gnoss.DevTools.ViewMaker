using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de Perfil
    /// </summary>
    [Serializable]
    public class ProfilePageViewModel
    {
        public ProfilePageViewModel()
        {
            ProfileFollowers = new List<ProfileModel>();
            ProfileFollowed = new List<ProfileModel>();
        }

        /// <summary>
        /// Enumeración con los tipos de paginas de perfil
        /// </summary>
        public enum ProfilePageType
        {
            /// <summary>
            /// Actividad reciente
            /// </summary>
            RecentActivity,
            /// <summary>
            /// Biografia
            /// </summary>
            Biography,
            /// <summary>
            /// Recursos
            /// </summary>
            Resources,
            /// <summary>
            /// Contactos
            /// </summary>
            Contacts,
            /// <summary>
            /// Segidores
            /// </summary>
            Followers,
            /// <summary>
            /// Personas a las que sigo
            /// </summary>
            Followed,
            /// <summary>
            /// Grupos
            /// </summary>
            Grups,
            /// <summary>
            /// Personas que componen la organizacion
            /// </summary>
            People
        }

        public List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// Tipo de página de perfil
        /// </summary>
        public ProfilePageType PageType { get; set; }
        /// <summary>
        /// Indica si estas viendo la pagina de tu perfil desde (mi-perfil)
        /// </summary>
        public bool MyProfilePage { get; set; }
        /// <summary>
        /// Lista de gadgets del perfil
        /// </summary>
        public List<GadgetModel> Gadgets { get; set; }
        /// <summary>
        /// Actividad reciente
        /// </summary>
        public RecentActivity RecentActivity { get; set; }
        /// <summary>
        /// Html de la bio
        /// </summary>
        public string HtmlBio { get; set; }
        /// <summary>
        /// Html de la trayectoria
        /// </summary>
        public string HtmlTrayectoria { get; set; }
        /// <summary>
        /// Html de "Nos dedicamos" 
        /// </summary>
        public string HtmlNosDedicamos { get; set; }
        /// <summary>
        /// Indica si se pueden ver los recursos del perfil 
        /// </summary>
        public bool ShowResources { get; set; }
        /// <summary>
        /// Indica si el perfil tiene grupos
        /// </summary>
        public bool HasGrups { get; set; }
        /// <summary>
        /// Lista de grupos del perfil
        /// </summary>
        public List<GroupCardModel> ProfileGroups { get; set; }
        /// <summary>
        /// Lista de contactos del perfil
        /// </summary>
        public List<ProfileModel> ProfileContacts { get; set; }
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
        /// <summary>
        /// Personas que conponen la organización, si es un perfil de organización
        /// </summary>
        public List<ProfileModel> PeopleInOrganization { get; set; }
        /// <summary>
        /// Perifl
        /// </summary>
        public ProfileModel Profile { get; set; }
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public Guid UserKey { get; set; }
        /// <summary>
        /// Curriculum
        /// </summary>
        public CurriculumModel Curriculum { get; set; }
        /// <summary>
        /// Indica si debe mostrar datos demograficos del perfil
        /// </summary>
        public bool ShowDemographicsDataProfile { get; set; }

        public List<ProfileModel> PeopleOfInterest { get; set; }
    }
}
