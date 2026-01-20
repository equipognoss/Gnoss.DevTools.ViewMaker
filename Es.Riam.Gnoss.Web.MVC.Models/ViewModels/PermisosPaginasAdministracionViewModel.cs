namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    public class PermisosPaginasAdministracionViewModel
    {
        /// <summary>
        /// Indica si el CMS está activado
        /// </summary>
        public bool CMSActivado { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permita la administración de las páginas
        /// </summary>
        public bool AdministracionPaginasPermitido { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permita la administración de la semantica
        /// </summary>
        public bool AdministracionSemanticaPermitido { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permita la administración de las vistas
        /// </summary>
        public bool AdministracionVistasPermitido { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permita la administración de las páginas de desarrolladores
        /// </summary>
        public bool AdministracionDesarrolladoresPermitido { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permita la administración de eventos
        /// </summary>
        public bool AdministracionEventosDisponible { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta permitido administrar integración contínua
        /// </summary>
        public bool AdministracionIntegracionContinua { get; set; }
        /// <summary>
        /// Indica si en la comunidad esta iniciada la integracion continua.
        /// </summary>
        public bool AdministracionIntegracionContinuaIniciada { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool VistasActivadas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EsMetaAdministrador { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EsAdministradorProyecto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TipoPaginaAdministracion> PaginasPermisosUsuarios { get; set; }
    }
}
