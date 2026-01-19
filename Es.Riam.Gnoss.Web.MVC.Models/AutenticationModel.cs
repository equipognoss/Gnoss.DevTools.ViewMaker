namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de autenticacion : registro, login
    /// </summary>

    public partial class AutenticationModel
    {
        /// <summary>
        /// Enumeración de tipos de pagina de Autenticacion
        /// </summary>
        public enum TypeAutenticationPage
        {
            /// <summary>
            /// Pagina de Login
            /// </summary>
            Login = 0,
            /// <summary>
            /// Pagina de Registro
            /// </summary>
            Registro = 1,
            /// <summary>
            /// Pagina de Registro
            /// </summary>
            RegistroConRedesSociales = 2,
            /// <summary>
            /// Pagina de Invitacion usada
            /// </summary>
            InvitacionUsada = 3,
            /// <summary>
            /// Pagina de información de que no tienes permiso para entrar en esta comunidad
            /// </summary>
            NoPermiso = 4
        }

        /// <summary>
        /// Tipo de pagina
        /// </summary>
        public TypeAutenticationPage TypePage { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Email del tutor
        /// </summary>
        public string EmailTutor { get; set; }
        /// <summary>
        /// Login del Usuario
        /// </summary>
        public string LoginUsuario { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Imagen del captcha para evitar registros de bot
        /// </summary>
        public Guid EventID { get; set; }
        /// <summary>
        /// Imagen del captcha para evitar registros de bot
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// Indica si hay que preguntar por la fecha de nacimiento del usuario o por el contrario, pintar el check de "Soy mayor de 18 años".
        /// </summary>
        public bool AskBornDate { get; set; }
        /// <summary>
        /// Fecha de nacimiento del usuario
        /// </summary>
        public string BornDate { get; set; }
        /// <summary>
        /// Grupos registro obligatorio proyecto
        /// </summary>
        public string NetGroups { get; set; }
        /// <summary>
        /// Grupos registro obligatorio proyecto
        /// </summary>
        public string NetToken { get; set; }
        /// <summary>
        /// Clave de seguridad para evitar registros de bot
        /// </summary>
        public Guid SecurityID { get; set; }
        /// <summary>
        /// Imagen del captcha para evitar registros de bot
        /// </summary>
        public string ImageCaptcha { get; set; }
        /// <summary>
        /// Errores en el registro
        /// </summary>
        public List<string> Errors { get; set; }
        /// <summary>
        /// Edad minima requerida para registrarse
        /// </summary>
        public int MinAgeRegistre { get; set; }
        /// <summary>
        /// Clausualas del registro
        /// </summary>
        public Dictionary<Guid, KeyValuePair<string, bool>> Clauses { get; set; }
        /// <summary>
        /// Condiciones de uso
        /// </summary>
        public Dictionary<string, KeyValuePair<string, string>> Terms { get; set; }
        /// <summary>
        /// Campos adicionales del registro
        /// </summary>
        public List<AdditionalFieldAutentication> AdditionalFields { get; set; }
        /// <summary>
        /// Indica si hay que mostrar el país del usuario
        /// </summary>
        public bool AskCountry { get; set; }
        /// <summary>
        /// Identificador del país del usuario
        /// </summary>
        public Guid CountryID { get; set; }
        /// <summary>
        /// Indica si hay que mostrar la provincia del usuario
        /// </summary>
        public bool AskRegion { get; set; }
        /// <summary>
        /// Identificador de la provincia del usuario
        /// </summary>
        public Guid RegionID { get; set; }
        /// <summary>
        /// Provincia del usuario
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Indica si hay que mostrar la localidad del usuario
        /// </summary>
        public bool AskLocation { get; set; }
        /// <summary>
        /// Localidad del usuario
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Indica si hay que mostrar el sexo del usuario
        /// </summary>
        public bool AskGender { get; set; }
        /// <summary>
        /// Sexo del usuario
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Lista de paises
        /// </summary>
        public Dictionary<Guid, string> CountryList { get; set; }
        /// <summary>
        /// Lista de provincias / regiones
        /// </summary>
        public Dictionary<Guid, string> RegionList { get; set; }

        /// <summary>
        /// Indica si es un registro mediante invitación
        /// </summary>
        public bool InvitationRegistre { get; set; }

        /// <summary>
        /// Indica si hay que pedirle el cargo al usuario (en una invitación de organización)
        /// </summary>
        public bool AskPosition { get; set; }

        //public bool MostrarSoloCondiciones { get; set; }

        public bool Reenviar { get; set; }

        /// <summary>
        /// URL para desconectar al usuario en otro navegador
        /// </summary>
        public string URLDesconexion { get; set; }
    }
}
