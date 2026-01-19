namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de la cabecera
    /// </summary>
    public partial class HeaderModel
    {
        /// <summary>
        /// Url de la busqueda avanzada
        /// </summary>
        public string UrlAdvancedSearch { get; set; }

        /// <summary>
        /// Idiomas configurados
        /// </summary>
        public Dictionary<string, string> Languajes { get; set; }

        /// <summary>
        /// Enlace de la pagina actual en todos los idiomas configurados
        /// </summary>
        public Dictionary<string, KeyValuePair<bool, string>> MultiLingualLinks { get; set; }

        /// <summary>
        /// Redes sociales configuradas para el registro/login
        /// </summary>
        public Dictionary<string, string> SocialNetworkRegister { get; set; }

        /// <summary>
        /// Buscador
        /// </summary>
        public SearchHeaderModel Searcher { get; set; }

        /// <summary>
        /// Indica si la home del usuario conectado del metaproyecto esta disponible
        /// </summary>
        public bool HomeUserAvailable { get; set; }

        /// <summary>
        /// Indica si las suscripciones estan disponibles
        /// </summary>
        public bool SubscriptionsAvailable { get; set; }

        /// <summary>
        /// Indica si los contactos estan disponibles
        /// </summary>
        public bool ContactsAvailable { get; set; }

        /// <summary>
        /// Indica si el enlace de cambiar contraseña está disponible
        /// </summary>
        public bool ChangePasswordVisible { get; set; }

        /// <summary>
        /// Modelo de buscador de la cabecera
        /// </summary>
        public partial class SearchHeaderModel
        {
            /// <summary>
            /// Lista de paginas de busqueda que deben salir en el combo
            /// </summary>
            public List<SearchSelectComboModel> ListSelectCombo { get; set; }
            /// <summary>
            /// Javascript Extra necesario para las busquedas
            /// </summary>
            public string JSExtra { get; set; }
           
            public partial class SearchSelectComboModel
            {
                /// <summary>
                /// Identificador de la pestanya
                /// </summary>
                public string ID { get; set; }

                /// <summary>
                /// Nombre de la opción
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// Autocompletar
                /// </summary>
                public string Autocomplete { get; set; }

                /// <summary>
                /// Autocompletar
                /// </summary>
                public string FacetAutocomplete { get; set; }

                /// <summary>
                /// Url de la opción
                /// </summary>
                public string Url { get; set; }

                /// <summary>
                /// Indica si está seleccionado
                /// </summary>
                public bool Selected { get; set; }
                /// <summary>
                /// Indica el tipo de autocompletar que se va a usar en la pestaña
                /// </summary>
                public short TipoAutocompletar { get; set; }
                /// <summary>
                /// Indica el search personalizado que usa la pestaña
                /// </summary>
                public string SearchPersonalizado { get; set; }

            }
        }
    }
}
