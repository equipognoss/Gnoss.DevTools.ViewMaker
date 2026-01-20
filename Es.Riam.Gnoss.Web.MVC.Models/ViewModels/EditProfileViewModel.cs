using Microsoft.AspNetCore.Http;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de "Editar perfil" 
    /// </summary>
    public class EditProfileViewModel
    {
        /// <summary>
        /// Lista de paises
        /// </summary>
        public Dictionary<Guid, string> CountryList { get; set; }

        public List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// Lista de provincias / regiones
        /// </summary>
        public Dictionary<Guid, string> RegionList { get; set; }
        /// <summary>
        /// Url de la foto del perfil
        /// </summary>
        public string UrlFoto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UsarFotoPersonal { get; set; }
        /// <summary>
        /// Perfil de la organización, solo tendra valor si estamos editando un perifl de una organización
        /// </summary>
        public ProfileOrganizationViewModel ProfileOrganization { get; set; }
        /// <summary>
        /// Perfil del usuario, solo tendra valor si estamos editando un perifl de un usuario
        /// </summary>
        public ProfilePersonalViewModel ProfilePersonal { get; set; }
        /// <summary>
        /// Perfil del usuario en la organización, solo tendra valor si estamos editando un perifl de un usuario en la organización
        /// </summary>
        public ProfileProfesionalViewModel ProfileProfesional { get; set; }
        /// <summary>
        /// Perfil del profesor, solo tendra valor si estamos editando un perifl de un profesor
        /// </summary>
        public ProfileTeacherViewModel ProfileTeacher { get; set; }
        /// <summary>
        /// Curriculum corto, una breve descripción del perfil
        /// </summary>
        public QuickCurriculum Curriculum { get; set; }
        /// <summary>
        /// Lista de redes sociales del perfil
        /// </summary>
        public List<SocialNetwork> SocialNetworks { get; set; }
        /// <summary>
        /// Errores en la edicion del perfil
        /// </summary>
        public Dictionary<string, string> Errors { get; set; }

        /// <summary>
        /// View Model del perfil de la organizacion
        /// </summary>
        [Serializable]
        public class ProfileOrganizationViewModel
        {
            /// <summary>
            /// Nombre de la organizacion
            /// </summary>
            public string NameOrganization { get; set; }
            /// <summary>
            /// Identificador del país
            /// </summary>
            public Guid Country { get; set; }
            /// <summary>
            /// Código postal
            /// </summary>
            public string PostalCode { get; set; }
            /// <summary>
            /// Ciudad o población
            /// </summary>
            public string Location { get; set; }

            /// <summary>
            /// Lista con los tipos de organización
            /// </summary>
            public Dictionary<short, string> ListTypesOrganization { get; set; }
            /// <summary>

            /// <summary>
            /// Lista con los tipos de sectores de la organización
            /// </summary>
            public Dictionary<short, string> ListTypesSectors { get; set; }

            /// <summary>
            /// Alias de la organización, nombre por el que se le conoce
            /// </summary>
            public string Alias { get; set; }
            /// <summary>
            /// Pagina web de la organización
            /// </summary>
            public string WebSite { get; set; }
            /// <summary>
            /// Provincia o región de la organización
            /// </summary>
            public string Region { get; set; }
            /// <summary>
            /// Dirección fisica de la empresa
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// Indica se la organización es una clase
            /// </summary>
            public bool IsClass { get; set; }
            /// <summary>
            /// Centro de estudios, si es una clase
            /// </summary>
            public string Centre { get; set; }
            /// <summary>
            /// Asignatura, si es una clase
            /// </summary>
            public string Subject { get; set; }
            /// <summary>
            /// Curso, si es una clase
            /// </summary>
            public string Course { get; set; }
            /// <summary>
            /// Grupo, si es una clase
            /// </summary>
            public string Group { get; set; }
        }

        /// <summary>
        /// View Model del perfil de personal
        /// </summary>
        [Serializable]
        public class ProfilePersonalViewModel
        {
            /// <summary>
            /// Nombre
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Apellidos
            /// </summary>
            public string LastName { get; set; }
            /// <summary>
            /// Pais
            /// </summary>
            public Guid Country { get; set; }
            /// <summary>
            /// Idioma
            /// </summary>
            public string Lang { get; set; }
            /// <summary>
            /// Provincia o región
            /// </summary>
            public string Region { get; set; }
            /// <summary>
            /// Sexo
            /// </summary>
            public string Sex { get; set; }
            /// <summary>
            /// Codigo postal
            /// </summary>
            public string PostalCode { get; set; }
            /// <summary>
            /// Ciudad o población
            /// </summary>
            public string Location { get; set; }
            /// <summary>
            /// Fecha de nacimiento (dd/MM/yyyy)
            /// </summary>
            public string BornDate { get; set; }
            /// <summary>
            /// Autenticacion
            /// </summary>
            public bool TwoFactorAuthentication { get; set; }
            /// <summary>
            /// Email
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Email del tutor
            /// </summary>
            public string EmailTutor { get; set; }
            /// <summary>
            /// Lista de campos extra
            /// </summary>
            public List<AdditionalFieldAutentication> AdditionalFields { get; set; }
            /// <summary>
            /// Idica si es buscable
            /// </summary>
            public bool? IsSearched { get; set; }
            /// <summary>
            /// Indica si es buscable por bots y usuarios no registrados
            /// </summary>
            public bool? IsExternalSearched { get; set; }
            /// <summary>
            /// Lista de cláusulas adicionales
            /// </summary>
            public List<AdditionalClause> AdditionalClauses { get; set; }
            /// <summary>
            /// Lista con las categorias de la comunidad
            /// </summary>
        }
        [Serializable]
        public class DataEditProfile
        {
            public ProfilePersonalViewModel ProfilePersonal { get; set; }
            public IFormFile FicheroImagen { get; set; }
            public string Description { get; set; }
            public string RedesSociales { get; set; }
            public string Tags { get; set; }
        }
        /// <summary>
        /// View model de un perfil profesional
        /// </summary>
        [Serializable]
        public class ProfileProfesionalViewModel
        {
            /// <summary>
            /// email
            /// </summary>
            public string Email { get; set; }
        }

        /// <summary>
        /// View model de un perfil de profesor
        /// </summary>
        [Serializable]
        public class ProfileTeacherViewModel
        {
            /// <summary>
            /// Email
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Departamento
            /// </summary>
            public string Departament { get; set; }
            /// <summary>
            /// Centro de estudios
            /// </summary>
            public string StudiesCentre { get; set; }
        }

        /// <summary>
        /// View model de un curriculum
        /// </summary>
        [Serializable]
        public class QuickCurriculum
        {
            /// <summary>
            /// Descripción
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Etiquetas
            /// </summary>
            public string Tags { get; set; }
        }

        /// <summary>
        /// View model de una red social
        /// </summary>
        [Serializable]
        public class SocialNetwork
        {
            /// <summary>
            /// Dominio de la red social1
            /// </summary>
            public string Domain { get; set; }
            /// <summary>
            /// Nombre de la red social
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Url de tu perfil en la red social
            /// </summary>
            public string Url { get; set; }
        }

        /// <summary>
        /// Cláusula adicional
        /// </summary>
        [Serializable]
        public class AdditionalClause
        {
            public Guid Id { get; set; }
            public string Text { get; set; }
            public int Order { get; set; }
            public bool Checked { get; set; }
        }

        /// <summary>
        /// Url de la accion de guardar imagen
        /// </summary>
        public string UrlActionSaveImage { get; set; }

        /// <summary>
        /// Url de la accion de guardar perfil
        /// </summary>
        public string UrlActionSaveProfile { get; set; }

        /// <summary>
        /// Url de la accion de guardar perfil
        /// </summary>
        public string UrlActionSaveEmail { get; set; }

        /// <summary>
        /// Url de la accion de guardar el DNI / NIF
        /// </summary>
        public string UrlActionSaveNIF { get; set; }

        /// <summary>
        /// Url de la accion de guardar bio
        /// </summary>
        public string UrlActionSaveBio { get; set; }

        /// <summary>
        /// Url de la accion de eliminar bio
        /// </summary>
        public string UrlActionDeleteBio { get; set; }

        /// <summary>
        /// Url de la accion de guardar los datos del usuario
        /// </summary>
        public string UrlSaveUserDataForm { get; set; }

    }
}
