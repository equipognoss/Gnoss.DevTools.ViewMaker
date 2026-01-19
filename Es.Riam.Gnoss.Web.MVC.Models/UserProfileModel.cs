using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Es.Riam.Gnoss.Web.MVC.Models.CommunityModel;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de perfil actual
    /// </summary>
    [Serializable]
    public partial class UserProfileModel
    {
        public const int LastCacheVersion = 2;

        /// <summary>
        /// Nombre del perfil actual
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Nombre de la organización del perfil actual
        /// </summary>
        public string NameOrg { get; set; }

        /// <summary>
        /// Nombre de la persona del perfil actual
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Nombre compuesto del perfil actual, con el nombre de la organización
        /// </summary>
        public string CompleteProfileName { get; set; }

        /// <summary>
        /// URL del perfil actual
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// URL del perfil actual
        /// </summary>
        public string UrlViewProfile { get; set; }

        /// <summary>
        /// Foto del perfil actual
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// DNI del perfil actual
        /// </summary>
        public string DNI { get; set; }

        /// <summary>
        /// Identificador del perfil actual
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Tipo de perfil actual
        /// </summary>
        public ProfileType TypeProfile { get; set; }

        /// <summary>
        /// Indica si el perfil es de clase
        /// </summary>
        public bool IsClassProfile { get; set; }

        /// <summary>
        /// Indica si el perfil es administrador de alguna clase
        /// </summary>
        public bool IsClassAdministrator { get; set; }

        /// <summary>
        /// Lista de comunidades a las que pertenece el perfil
        /// </summary>
        public List<ProfileCommunitiesModel> Communities { get; set; }

        /// <summary>
        /// Lista de perfiles del usuario
        /// </summary>
        public List<UserProfileModel> UserProfiles { get; set; }

        /// <summary>
        /// Indica si está disponible el menú de administración de la organización.
        /// </summary>
        public bool IsAdministrator { get; set; }

        /// <summary>
        /// Indica si está disponible el menú de administración de la organización.
        /// </summary>
        public bool OrganizationMenuAvailable { get; set; }

        /// <summary>
        /// Url del espacio personal de la organización.
        /// </summary>
        public string OrganizationPersonalSpaceUrl { get; set; }

        /// <summary>
        /// Url de administración de usuario de la organización.
        /// </summary>
        public string AdminOrganizationUsersUrl { get; set; }

        /// <summary>
        /// Datos extra del perfil
        /// </summary>
        public Dictionary<string, string> ExtraData { get; set; }

        /// <summary>
        /// Datos extra de las identidades del perfil
        /// </summary>
        public Dictionary<Guid, Dictionary<string, string>> ExtraDataIdentities { get; set; }

        public DateTime BornDate { get; set; }

        /// <summary>
        /// Modelo de comunidad
        /// </summary>
        [Serializable]
        public partial class ProfileCommunitiesModel
        {
            /// <summary>
            /// Identificador de la comunidad
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// Nombre de la comunidad
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Url de la comunidad
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// Tipo de la comunidad
            /// </summary>
            public short Type { get; set; }
            /// <summary>
            /// Numero de conexiones del perfil a esta comunidad
            /// </summary>
            public int NumberOfConnections { get; set; }
            /// <summary>
            /// Es comunidad de registro obligatorio
            /// </summary>
            public int EsRegistroObligatorio { get; set; }

            /// <summary>
            /// Tipo de proyecto
            /// </summary>
            public TypeProyect ProyectType { get; set; }
        }
        public int CacheVersion { get; set; }
        public Guid PaisID { get; set; }
    }
}
