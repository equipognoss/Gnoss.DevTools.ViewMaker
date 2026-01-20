namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// View model de la pagina de editar un grupo
    /// </summary>
    [Serializable]
    public class SolicitudesGrupoViewModel
    {
        public List<SolicitudModel> ListaSolicitudes { get; set; }

        public string UrlPagina { get; set; }

        public string UrlAccept { get; set; }

        public string UrlReject { get; set; }

        public int NumPaginas { get; set; }

        public int PaginaActual { get; set; }

        public Guid GrupoFiltroID { get; set; }

        public Dictionary<Guid, string> Grupos { get; set; }

        /// <summary>
        /// Modelo de solicitud
        /// </summary>
        [Serializable]
        public partial class SolicitudModel
        {
            /// <summary>
            /// Clave del grupo
            /// </summary>
            public Guid KeyGroup { get; set; }

            public Guid KeyIdentity { get; set; }

            public string UrlFoto { get; set; }

            public string NameGroup { get; set; }

            public string NameIdentity { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
