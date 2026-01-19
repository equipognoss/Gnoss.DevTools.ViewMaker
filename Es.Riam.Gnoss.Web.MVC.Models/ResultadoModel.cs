using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de resultados de una busqueda
    /// </summary>
    [Serializable]
    public partial class ResultadoModel
    {
        /// <summary>
        /// Tipos de búsqueda
        /// </summary>
        public enum TiposBusquedaMVC
        {
            /// <summary>
            /// Recursos
            /// </summary>
            Recursos = 0,
            /// <summary>
            /// Debates
            /// </summary>
            Debates,
            /// <summary>
            /// Preguntas
            /// </summary>
            Preguntas,
            /// <summary>
            /// Encuestas
            /// </summary>
            Encuestas,
            /// <summary>
            /// Dafos
            /// </summary>
            Dafos,
            /// <summary>
            /// Personas y organizaciones
            /// </summary>
            PersonasYOrganizaciones,
            /// <summary>
            /// Búsqueda avanzada
            /// </summary>
            BusquedaAvanzada,
            /// <summary>
            /// Comunidades
            /// </summary>
            Comunidades,
            /// <summary>
            /// Blogs
            /// </summary>
            Blogs,
            /// <summary>
            /// ArticuloBlogs
            /// </summary>
            ArticuloBlogs,
            /// <summary>
            /// EditarRecursosPerfil
            /// </summary>
            EditarRecursosPerfil,
            /// <summary>
            /// Contribuciones
            /// </summary>
            Contribuciones,
            /// <summary>
            /// Mensajes.
            /// </summary>
            Mensajes,
            /// <summary>
            /// Comentarios.
            /// </summary>
            Comentarios,
            /// <summary>
            /// Invitaciones.
            /// </summary>
            Invitaciones,
            /// <summary>
            /// Suscripciones.
            /// </summary>
            Suscripciones,
            /// <summary>
            /// Contactos
            /// </summary>
            Contactos,
            /// <summary>
            /// Recomendaciones.
            /// </summary>
            Recomendaciones,
            /// <summary>
            /// Recomendaciones de proyectos.
            /// </summary>
            RecomendacionesProys,
            /// <summary>
            /// VerRecursosPerfil
            /// </summary>
            VerRecursosPerfil,
            /// <summary>
            /// Notificaciones (comentarios e invitaciones juntas)
            /// </summary>
            Notificaciones

        }

        /// <summary>
        /// Lista de resultados de la busqueda
        /// </summary>
        public List<ObjetoBuscadorModel> ListaResultados { get; set; }

        /// <summary>
        /// Numero total de resultados de la busqueda. -1 si debe ocultarse el número.
        /// </summary>
        public int NumeroResultadosTotal { get; set; }
        /// <summary>
        /// Pagina actual de la busqueda
        /// </summary>
        public int NumeroPaginaActual { get; set; }
        /// <summary>
        /// Numero de resultados por pagina
        /// </summary>
        public int NumeroResultadosPagina { get; set; }
        /// <summary>
        /// Url de la busqueda
        /// </summary>
        public string UrlBusqueda { get; set; }
        /// <summary>
        /// TExto sin resultados
        /// </summary>
        public string TextoSinResultados { get; set; }
        /// <summary>
        /// Tipo de la busqueda
        /// </summary>
        public TiposBusquedaMVC TipoBusqueda { get; set; }

        /// <summary>
        /// Indica si la petición se ha realizado desde "backOffice / DevTools"
        /// </summary>
        public bool AdministradorVeTodasPersonas { get; set; }


        /// <summary>
        /// Indica que la búsqueda es de tipo mapa.
        /// </summary>
        public bool MapView { get; set; }
    }

}
