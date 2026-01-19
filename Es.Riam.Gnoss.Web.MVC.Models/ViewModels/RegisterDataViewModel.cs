namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View Model de las paginas de los pasos de registro
    /// </summary>
    public class RegisterDataViewModel
    {
        public RegisterDataViewModel()
        {

            ListProfiles = new List<ProfileModel>();
        }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string ReferrerPage { get; set; }
        /// <summary>
        /// Indica si la pestaña preferecicias esta disponible
        /// </summary>
        public bool TabPreferences { get; set; }
        /// <summary>
        /// Indica si la pestaña datos esta disponible
        /// </summary>
        public bool TabData { get; set; }
        /// <summary>
        /// Indica si la pestaña conecta esta disponible
        /// </summary>
        public bool TabConect { get; set; }
        /// <summary>
        /// Indica el numero de pestaña que esta activa
        /// </summary>
        public int TabActive { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Url de la foto del usuario
        /// </summary>
        public string Foto { get; set; }
        /// <summary>
        /// Ciudad / Población del usuario
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Provincia
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Provincia
        /// </summary>
        public Guid RegionID { get; set; }
        /// <summary>
        /// País del usuario
        /// </summary>
        public Guid CountryID { get; set; }
        /// <summary>
        /// País por defecto del usuario
        /// </summary>
        public Guid CountryDefaultID { get; set; }
        /// <summary>
        /// Lista de paises
        /// </summary>
        public Dictionary<Guid, string> CountryList { get; set; }
        /// <summary>
        /// Lista de provincias / regiones
        /// </summary>
        public Dictionary<Guid, string> RegionList { get; set; }
        /// <summary>
        /// Indica si se va a mostrar el país
        /// </summary>
        public bool AskCountry { get; set; }
        /// <summary>
        /// Indica si se va a mostrar la provincia/región
        /// </summary>
        public bool AskRegion { get; set; }
        /// <summary>
        /// Indica si se va a mostrar la localidad
        /// </summary>
        public bool AskLocation { get; set; }
        /// <summary>
        /// Indica si se va a mostrar el sexo del usuario
        /// </summary>
        public bool AskGender { get; set; }
        /// <summary>
        /// Sexo del usuario
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Idica si es buscable
        /// </summary>
        public bool? IsSearched { get; set; }
        /// <summary>
        /// Indica si es buscable por bots y usuarios no registrados
        /// </summary>
        public bool? IsExternalSearched { get; set; }
        /// <summary>
        /// Campos adicionales del registro
        /// </summary>
        public List<AdditionalFieldAutentication> AdditionalFields { get; set; }
        /// <summary>
        /// Errores en el registro
        /// </summary>
        public List<string> Errors { get; set; }
        /// <summary>
        /// Lista de preferencias
        /// </summary>
        public Dictionary<Guid, KeyValuePair<string, Dictionary<Guid, string>>> ListPreferences { get; set; }
        /// <summary>
        /// Lista de perfiles con intereses comunes
        /// </summary>
        public List<ProfileModel> ListProfiles { get; set; }
    }
}
