using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de la identidad actual
    /// </summary>
    public partial class UserIdentityModel
    {
        /// <summary>
        /// Identificador de la identidad
        /// </summary>
        public Guid KeyIdentity { get; set; }
        /// <summary>
        /// Identificador de su identidad en el metaproyecto
        /// </summary>
        public Guid KeyMetaProyectIdentity { get; set; }
        /// <summary>
        /// Identificador de la identidad de la organización, si no tiene organización el valor es Guid.Empty
        /// </summary>
        public Guid KeyIdentityOrg { get; set; }
        /// <summary>
        /// Identificador de su identidad de la organización en el metaproyecto, si no tiene organización el valor es Guid.Empty
        /// </summary>
        public Guid KeyMetaProyectIdentityOrg { get; set; }
        /// <summary>
        /// Identificador de su organizacion
        /// </summary>
        public Guid? KeyOrganization { get; set; }
        /// <summary>
        /// Identificador de su perfil
        /// </summary>
        public Guid KeyProfile { get; set; }
        /// <summary>
        /// Identificador de su persona
        /// </summary>
        public Guid KeyPerson { get; set; }
        /// <summary>
        /// Identificador de su usuario
        /// </summary>
        public Guid KeyUser { get; set; }
        /// <summary>
        /// Indica si la identidad es Invitada, no participa en la comunidad
        /// </summary>
        public bool IsGuestIdentity { get; set; }
        /// <summary>
        /// Indica si el usuario es invitado, no esta registrado
        /// </summary>
        public bool IsGuestUser { get; set; }
        /// <summary>
        /// Indica si la identidad actual es administrador de la organización.
        /// </summary>
        public bool IsOrgAdmin { get; set; }
        /// <summary>
        /// Indica si la identidad actual es supervisor de la organización.
        /// </summary>
        public bool IsOrgSupervisor { get; set; }
        /// <summary>
        /// Indica si la identidad actual es administrador del proyecto.
        /// </summary>
        public bool IsProyectAdmin { get; set; }
        /// <summary>
        /// Indica si la identidad actual es supervisor del proyecto.
        /// </summary>
        public bool IsProyectSupervisor { get; set; }
        /// <summary>
        /// Indica si la identidad actual es de tipo un profesor.
        /// </summary>
        public bool IsTeacher { get; set; }
        /// <summary>
        /// Email de la persona de la identidad.
        /// </summary>
        public string PersonEmail { get; set; }
        /// <summary>
        /// Nombre de la persona de la identidad.
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// Apellidos de la persona de la identidad.
        /// </summary>
        public string PersonFamilyName { get; set; }
        /// <summary>
        /// NIF de la persona
        /// </summary>
        public string PersonalID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PermitEditAllPeople { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PermitEditAllOrganizations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PermitEditAllCommunities { get; set; }
        /// <summary>
        /// Indica si la identidad ha sido expulsada
        /// </summary>
        public bool IsExpelled { get; set; }
        /// <summary>
        /// User IP
        /// </summary>
        public string PublicIP { get; set; }
        /// <summary>
        /// Number of login attemprs from the same IP
        /// </summary>
        public int NumberOfLoginAttemptsIP { get; set; }
        /// <summary>
        /// Indica si debe recibir la newsletter
        /// </summary>
        public bool ReceiveNewsletter { get; set; }
        /// <summary>
        /// Indica la Fecha de Nacimiento
        /// </summary>
        public DateTime BornDate { get; set; }

        public CommunityRequestStatusEnum CommunityRequestStatus { get; set; }

        /// <summary>
        /// Datos extra de la identidad
        /// </summary>
        public Dictionary<string, string> ExtraData { get; set; }

        /// <summary>
        /// Datos extra de la identidad por comunidad
        /// </summary>
        public Dictionary<Guid, Dictionary<string, string>> ExtraDataCommunities { get; set; }

        /// <summary>
        /// Enumeración del estado de la solicitud de una comunidad
        /// </summary>
        public enum CommunityRequestStatusEnum
        {
            /// <summary>
            /// Sin solicitud
            /// </summary>
            NoRequest,
            /// <summary>
            /// Solicitud pendiente de aprobar
            /// </summary>
            RequestPending,
            /// <summary>
            /// Solicitud realizada con otra identidad
            /// </summary>
            RequestedWithAnotherProfile

        }

        /// <summary>
        /// Lista de grupos de la identidad
        /// </summary>
        public List<GroupCardModel> IdentityGroups { get; set; }
    }
}
