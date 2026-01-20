namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de las pagina de busqueda
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// Nombre de la pagina de busqueda
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// Título de la pagina de busqueda
        /// </summary>
        public string PageTittle { get; set; }
        /// <summary>
        /// Html de los resultados de la busqueda
        /// </summary>
        public string HTMLResourceList { get; set; }
        /// <summary>
        /// Html de los resultados de la busqueda
        /// </summary>
        public ResultadoModel JSONResourceList { get; set; }

        public FacetedModel JSONFaceted { get; set; }
        /// <summary>
        /// Html de las facetas de la busqueda
        /// </summary>
        public string HTMLFaceted { get; set; }
        /// <summary>
        /// Lista de filtros de orden
        /// </summary>
        public Dictionary<string, string> FilterOrderList { get; set; }
        /// <summary>
        /// Filtro de orden seleccionado
        /// </summary>
        public string FilterOrderSelected { get; set; }
        /// <summary>
        /// Lista de vistas disponibles
        /// </summary>
        public List<ViewTypeModel> ViewList { get; set; }
        /// <summary>
        /// Lista de tipos de vista graficos disponibles
        /// </summary>
        public List<ChartViewModel> ChartList { get; set; }
        /// <summary>
        /// Indica si la caja de búsqueda es visible
        /// </summary>
        public bool SearchBoxVisible { get; set; }
        /// <summary>
        /// Indica si las facetas están visibles
        /// </summary>
        public bool FacetedVisible { get; set; }
        /// <summary>
        /// Indica el texto por defecto que tiene que aparecer en el buscador
        /// </summary>
        public string TextSearchBox { get; set; }
        /// <summary>
        /// Url de la acción para exportar una búsqueda  a excel
        /// </summary>
        public string UrlActionExport { get; set; }
        /// <summary>
        /// Lista con las posibles exportaciones de una búsqueda a excel
        /// </summary>
        public List<ExportationModel> ListExportation { get; set; }
        /// <summary>
        /// Lista de filtros que se le pasan a la página por la url
        /// </summary>
        public List<string> PageFiltersList { get; set; }

        public string TipoPagina { get; set; }

        public string SearchPersonalizadoSelected { get; set; }


        /// <summary>
        /// Modelo de exportacion
        /// </summary>
        [Serializable]
        public partial class ExportationModel
        {
            /// <summary>
            /// Identificador de la exportacion
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// Nombre de la exportacion
            /// </summary>
            public string ExportationName { get; set; }
            /// <summary>
            /// Lista formatos de exportacion
            /// </sumary>
            public List<String> ExportationFormats { get; set; }
        }


        /// <summary>
        /// View model de las vistas de busqueda
        /// </summary>
        [Serializable]
        public class ViewTypeModel
        {
            /// <summary>
            /// Enumeración para los diferentes tipos de vistas
            /// </summary>
            public enum ViewTypeSearch
            {
                /// <summary>
                /// Vista tipo lista
                /// </summary>
                List = 0,
                /// <summary>
                /// Vusta tipo mosaico
                /// </summary>
                Grid = 1,
                /// <summary>
                /// Vista tipo Mapa
                /// </summary>
                Map = 2,
                /// <summary>
                /// Vista tipo gráfico
                /// </summary>
                Chart = 3
            }

            /// <summary>
            /// Tipo de vista
            /// </summary>
            public ViewTypeSearch ViewType { get; set; }

            /// <summary>
            /// Indica si está activo
            /// </summary>
            public bool Active { get; set; }
        }


        /// <summary>
        /// View model de las vistas de graficos
        /// </summary>
        [Serializable]
        public class ChartViewModel
        {
            /// <summary>
            /// Id de la vista de grafico
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// Nombre de la vista de grafico
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// JS de la vista de grafico
            /// </summary>
            public string JS { get; set; }
        }

        public DashboardViewModel Dashboard { get; set; }
    }
}
