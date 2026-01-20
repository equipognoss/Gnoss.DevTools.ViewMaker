using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View Model de la pagina de mis comunidades
    /// </summary>
    [Serializable]
    public class MyCommunitiesViewModel
    {
        /// <summary>
        /// Lista de comunidades
        /// </summary>
        public List<MyCommunityModel> Communities { get; set; }

        /// <summary>
        /// Lista de filtros de orden
        /// </summary>
        public Dictionary<string, string> FilterOrderList { get; set; }

        /// <summary>
        /// Filtro de orden seleccionado
        /// </summary>
        public string FilterOrderSelected { get; set; }

        /// <summary>
        /// Lista de filtros que se le pasan a la página por la url
        /// </summary>
        public List<string> PageFiltersList { get; set; }

        /// <summary>
        /// Lista de vistas disponibles
        /// </summary>
        public List<ViewTypeModel> ViewList { get; set; }

        /// <summary>
        /// Modelo de comunidad
        /// </summary>
        [Serializable]
        public partial class MyCommunityModel
        {
            /// <summary>
            /// Identificador de la comunidad
            /// </summary>
            public Guid Key { get; set; }
            /// <summary>
            /// Identificador de la comunidad padre (Guid.Empty si no tiene padre)
            /// </summary>
            public Guid ParentKey { get; set; }
            /// <summary>
            /// Nombre de la comunidad
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Logo de la comunidad
            /// </summary>
            public string Logo { get; set; }
            /// <summary>
            /// Url de la comunidad
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// Tipo de acceso del proyecto: privado, publico....
            /// </summary>
            public CommunityModel.TypeAccessProject AccessType { get; set; }

            /// <summary>
            /// Tipo de proyecto: Comunidad, Metacomunidad, Educación expandida...
            /// </summary>
            public CommunityModel.TypeProyect ProyectType { get; set; }

            /// <summary>
            /// Fecha de creacion de la comunidad
            /// </summary>
            public DateTime CreationDate { get; set; }

            /// <summary>
            /// Descripcion de la comunidad
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Numero de personas de la comunidad
            /// </summary>
            public int Persons { get; set; }

            /// <summary>
            /// Numero de organizaciones que participan en la comunidad
            /// </summary>
            public int Organizations { get; set; }

            /// <summary>
            /// Numero de recursos de la comunidad
            /// </summary>
            public int Resources { get; set; }

            /// <summary>
            /// Etiquetas de la comunidad
            /// </summary>
            public List<string> Tags { get; set; }

            /// <summary>
            /// Categorias de la comunidad
            /// </summary>
            public List<CategoryModel> Categories { get; set; }
        }

        /// <summary>
        /// View model de los tipos de vistas
        /// </summary>
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
    }
}
