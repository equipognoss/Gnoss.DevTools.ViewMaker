namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// Registry Clauses Administration View Model
    /// </summary>
    public class ManageRegisterClausesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public static string MascaraCondicionesUso = "##CONDICIONES_USO_COM##";

        /// <summary>
        /// 
        /// </summary>
        public static string MascaraPoliticaPrivacidad = "##POLITICA_PRIVACIDAD_COM##";

        /// <summary>
        /// Types of Register Clauses
        /// </summary>
        public enum ClauseType
        {
            //Coinciden con TipoClausulaAdicional de UsuarioAD

            /// <summary>
            /// Obligatoria.
            /// </summary>
            Obligatoria = 0,
            /// <summary>
            /// Opcional.
            /// </summary>
            Opcional = 1,
            /// <summary>
            /// Clausulas texto para el registro.
            /// </summary>
            ClausulasTexo = 3,
            /// <summary>
            /// Condiciones de uso.
            /// </summary>
            CondicionesUso = 4,
            /// <summary>
            /// Título de las clausulas texto para el registro.
            /// </summary>
            TituloClausulasTexo = 5,
            /// <summary>
            /// Título de las condiciones de uso.
            /// </summary>
            TituloCondicionesUso = 6,
            /// <summary>
            /// Texto para la personalización del mensaje de aviso de la política de cookies
            /// </summary>
            PoliticaCookiesCabecera = 8,
            /// <summary>
            /// Texto o URL para la personalización del mensaje de la página de la política de cookies
            /// </summary>
            PoliticaCookiesUrlPagina = 9
        }

        /// <summary>
        /// List of languages
        /// </summary>
        public Dictionary<string, string> LanguagesList { get; set; }

        /// <summary>
        /// Default language
        /// </summary>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// List of Register Clause Model
        /// </summary>
        public List<RegisterClauseModel> ClausesList { get; set; }

        /// <summary>
        /// Register Clause Model
        /// </summary>
        [Serializable]
        public partial class RegisterClauseModel
        {
            /// <summary>
            /// 
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Text1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Text2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ClauseType Type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int Order { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool Deleted { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string CookieName { get; set; }

            public DateTime DateCreation { get; set; }

            public DateTime DateModification { get; set; }
        }
    }
}
