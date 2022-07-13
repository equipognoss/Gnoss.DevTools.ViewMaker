using Es.Riam.Gnoss.Web.MVC.Models;
using Es.Riam.Gnoss.Web.MVC.Models.Administracion;
using System;
using System.Collections.Generic;

namespace Gnoss.DevTools.ViewMaker.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AdministrarUsuariosOrganizacionViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public enum TipoPagina
        {
            /// <summary>
            /// 
            /// </summary>
            Usuarios = 0,
            /// <summary>
            /// 
            /// </summary>
            Comunidades = 1,
            /// <summary>
            /// 
            /// </summary>
            Grupos = 2
        }
        /// <summary>
        /// 
        /// </summary>
        public TipoPagina PageType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SearchFilter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public short TypeFilter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool OrderAsc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumElementosFiltradosPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrlFilter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OrganizationModel Organization { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<UserOrganizationModel> Usuarios { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CommunityModel> Proyectos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<GroupCardModel> Grupos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class OrganizationModel
        {
            public Guid Key { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
            public string Foto { get; set; }
            public int NumUsersOrg { get; set; }
            public int NumUsersOrgTypeAdmin { get; set; }
            public int NumUsersOrgTypeSuper { get; set; }
            public int NumUsersOrgTypeUser { get; set; }
            public int NumCommunitiesOrg { get; set; }
            public int NumCommunitiesAdminOrg { get; set; }
            public int NumGroupsOrg { get; set; }
        }

        public class UserOrganizationModel
        {
            public Guid User_Key { get; set; }
            public Guid Person_Key { get; set; }
            public string Name { get; set; }
            public TipoAdministradoresOrganizacion Type { get; set; }
            public string Foto { get; set; }
            public string Url { get; set; }
        }
    }

    public class ProyectosUsuViewModel
    {
        public Guid Key { get; set; }
        public string Nombre { get; set; }
        public bool Participa { get; set; }
        public short TipoParticipacion { get; set; }
        public bool Administra { get; set; }
    }

    /// <summary>
    /// View model de la pagina de "Enviar invitación a la comunidad" 
    /// </summary>
    [Serializable]
    public class SendInvitationOrgViewModel
    {
        /// <summary>
        /// Indica si permite enviar invitaciones a tus contactos
        /// </summary>
        public bool AllowInviteContacts { get; set; }
        /// <summary>
        /// Indica si permite enviar invitaciones por email
        /// </summary>
        public bool AllowInviteEmail { get; set; }
        /// <summary>
        /// Indica si se puede personalizar el mensaje de invitación a la comunidad
        /// </summary>
        public bool AllowPersonlizeMessage { get; set; }
        /// <summary>
        /// Mensaje de invitación a la comunidad
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Identificadores y emails de los invitados, separados por comas
        /// </summary>
        public string Guests { get; set; }
    }

    /// <summary>
    /// ViewModel de la página de administrar un componente del CMS
    /// </summary>
    [Serializable]
    public class CMSAdminComponenteEditarViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public bool AccesoPublicoComponente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ContenidoMultiIdioma { get; set; }
        /// <summary>
        /// Lista de idiomas de la plataforma
        /// </summary>
        public List<string> ListaIdiomasDisponibles { get; set; }
        /// <summary>
        /// Lista de idiomas de la plataforma
        /// </summary>
        public Dictionary<string, string> ListaIdiomas { get; set; }
        /// <summary>
        /// Idioma por defecto de la comunidad
        /// </summary>
        public string IdiomaPorDefecto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UrlVuelta { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EsEdicion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Private { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, string> GruposPrivacidad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, string> PerfilesPrivacidad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TipoComponenteCMS Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<TipoCaducidadComponenteCMS, bool> Caducidades { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TipoCaducidadComponenteCMS CaducidadSeleccionada { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Styles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, string> Personalizaciones { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid PersonalizacionSeleccionada { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PropiedadComponente> Properties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class PropiedadComponente
        {
            /// <summary>
            /// 
            /// </summary>
            public TipoPropiedadCMS TipoPropiedadCMS { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool Required { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Dictionary<string, string> Options { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool MultiLang { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public TipoComponenteCMS TypeComponent { get; set; }

        }
    }
    /// <summary>
    /// Modelo de la pagina de logout
    /// </summary>
    public partial class LogoutModel
        {
            public string UrlLogo { get; set; }
            public string NombreComunidad { get; set; }
            public bool ShowPowered { get; set; }

            public string UrlIframe { get; set; }
            public string UrlRedirect { get; set; }
       
    }

    public partial class LoadingModel
    {
        public string UrlLogo { get; set; }
        public string NombreComunidad { get; set; }
        public bool ShowPowered { get; set; }

        public string UrlRedireccion { get; set; }
    }

    /// <summary>
    /// Modelo de la vista de edición de administrar cookies
    /// </summary>
    [Serializable]
    public class CookieEditModel
    {
        /// <summary>
        /// Id de la cookie
        /// </summary>
        public string CookieID { get; set; }

        /// <summary>
        /// Nombre de la cookie
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Categoría de la cookie
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Descripción de la cookie
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Tipo de la cookie 0 -> Persistent, 1 -> Session, 2 -> Third party
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Si se ha eliminado la cookie
        /// </summary>
        public string Deleted { get; set; }

        /// <summary>
        /// Si se ha modificado la cookie
        /// </summary>
        public string EsModificada { get; set; }
    }

    /// <summary>
    /// Modelo de las categorías para la página de edición
    /// </summary>
    [Serializable]
    public class CategoryEditModel
    {
        /// <summary>
        /// Id de la categoría
        /// </summary>
        public string CategoriaID { get; set; }

        /// <summary>
        /// Nombre de la categoría
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre corto de la categoría (se utiliza para mostrar y crear las cookies a mostrar en la página de manage-cookies)
        /// </summary>
        public string NombreCorto { get; set; }

        /// <summary>
        /// Descripción de la categoría
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Si se ha eliminado o no la categoría
        /// </summary>
        public string Deleted { get; set; }

        /// <summary>
        /// Si se ha modificado la categoría
        /// </summary>
        public string EsModificada { get; set; }
    }


      /// <summary>
    /// Modelo de la página de administrar categorías
    /// </summary>
    [Serializable]
    public class AdministrarCategoriasViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ThesaurusEditorModel Thesaurus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool MultiLanguaje { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdiomaDefecto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdiomaTesauro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PasosRealizados { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<Guid, Dictionary<string, string>> Categoria { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ExistenRecursosNoHuerfanos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<Guid, string> ComunidadCompartir { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CategoryModel> CategoriasCompartir { get; set; }
    }


    public class RSSListadoRecursosViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, string> ListaFuentesRSS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumResultados { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FichaRecursoRSS> ListaRecursos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public class FichaRecursoRSS
        {
            public Guid Key { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string EnlaceEditar { get; set; }
            public Dictionary<Guid, string> Categorias { get; set; }
            public List<string> Tags { get; set; }
            public bool EstaCompleto { get; set; }
        }
    }

    public class CambiarPasswordPeticionViewModel
    {
        /// <summary>
        /// Nombre de la pagina de busqueda
        /// </summary>
        public string UrlAceptar { get; set; }
        /// <summary>
        /// Html de los resultados de la busqueda
        /// </summary>
        public string UrlRechazar { get; set; }

    }
    public class RSSEditarRecursoViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Enlace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ThesaurusEditorModel Tesauro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Guid> CategoriasSeleccionadas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> TagsTitulo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Compartir { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Autores { get; set; }
    }
}