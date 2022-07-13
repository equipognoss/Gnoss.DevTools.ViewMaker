using Es.Riam.Gnoss.AD.CMS;
using Es.Riam.Gnoss.AD.EncapsuladoDatos;
using Es.Riam.Gnoss.AD.EntityModel;
using Es.Riam.Gnoss.AD.EntityModel.Models.ProyectoDS;
using Es.Riam.Gnoss.AD.EntityModel.Models.VistaVirtualDS;
using Es.Riam.Gnoss.AD.EntityModelBASE;
using Es.Riam.Gnoss.AD.Facetado;
using Es.Riam.Gnoss.AD.Facetado.Model;
using Es.Riam.Gnoss.AD.Identidad;
using Es.Riam.Gnoss.AD.Parametro;
using Es.Riam.Gnoss.AD.ParametroAplicacion;
using Es.Riam.Gnoss.AD.ParametrosProyecto;
using Es.Riam.Gnoss.AD.ServiciosGenerales;
using Es.Riam.Gnoss.AD.Usuarios;
using Es.Riam.Gnoss.AD.Virtuoso;
using Es.Riam.Gnoss.CL;
using Es.Riam.Gnoss.CL.CMS;
using Es.Riam.Gnoss.CL.Facetado;
using Es.Riam.Gnoss.CL.ParametrosProyecto;
using Es.Riam.Gnoss.CL.ServiciosGenerales;
using Es.Riam.Gnoss.CL.Tesauro;
using Es.Riam.Gnoss.Elementos;
using Es.Riam.Gnoss.Elementos.CMS;
using Es.Riam.Gnoss.Elementos.Documentacion;
using Es.Riam.Gnoss.Elementos.Identidad;
using Es.Riam.Gnoss.Elementos.ServiciosGenerales;
using Es.Riam.Gnoss.Elementos.Tesauro;
using Es.Riam.Gnoss.Logica.BASE_BD;
using Es.Riam.Gnoss.Logica.CMS;
using Es.Riam.Gnoss.Logica.Documentacion;
using Es.Riam.Gnoss.Logica.Facetado;
using Es.Riam.Gnoss.Logica.Identidad;
using Es.Riam.Gnoss.Logica.ServiciosGenerales;
using Es.Riam.Gnoss.Recursos;
using Es.Riam.Gnoss.Servicios.ControladoresServiciosWeb;
using Es.Riam.Gnoss.Util.Configuracion;
using Es.Riam.Gnoss.Util.General;
using Es.Riam.Gnoss.Util.Seguridad;
//using Es.Riam.Gnoss.Web.Controles;
using Es.Riam.Gnoss.Web.MVC.Controles;
//using Es.Riam.Gnoss.Web.Controles.Proyectos;
using Es.Riam.Gnoss.Web.MVC.Models;
using Es.Riam.Gnoss.Web.MVC.Models.Administracion;
using Es.Riam.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Proyecto = Es.Riam.Gnoss.Elementos.ServiciosGenerales.Proyecto;
using ProyectoPestanyaMenu = Es.Riam.Gnoss.Elementos.ServiciosGenerales.ProyectoPestanyaMenu;

namespace Es.Riam.Gnoss.Web.MVC.Controles.Controladores
{
    public class ControladorCMS : Web.Controles.ControladorBase
    {

        #region Miembros

        private bool mVistaPrevia = false;

        private DataWrapperVistaVirtual mVistaVirtualDW = null;

        private ControllerBaseGnoss mControlador;

        private Guid? mComponenteID;

        private short? mTipoUbicacionCMSPaginaActual;

        private static List<string> mListaIdiomas = null;

        /// <summary>
        /// Lista de componentes cacheados
        /// </summary>
        public Dictionary<Guid, CMSComponent> mListaComponentesCache = null;

        /// <summary>
        /// Gestor de CMS de la página actual
        /// </summary>
        private GestionCMS mGestorCMSActual = null;

        /// <summary>
        /// Indica si está cargado en JS de gráfias de google
        /// </summary>
        private bool mJSGraficasGoogleCargado = false;

        private bool mRefrescar = false;

        private CommunityModel mComunidad;

        private List<Guid> mListaGruposIdentidadActual;
        private Guid? mIdentidadID;
        private Guid? mPerfilID;
        private Guid? mUsuarioID;
        private Identidad mIdentidadActual;

        private IHttpContextAccessor mHttpContextAccessor;
        private EntityContext mEntityContext;
        private LoggingService mLoggingService;
        private VirtuosoAD mVirtuosoAD;
        private ConfigService mConfigService;
        private RedisCacheWrapper mRedisCacheWrapper;
        private GnossCache mGnossCache;
        private EntityContextBASE mEntityContextBASE;
        private ICompositeViewEngine mViewEngine;

        #endregion

        #region Constructores

        public ControladorCMS(ControllerBaseGnoss pControlador, Guid? pComponenteID, short? pTipoUbicacionCMSPaginaActual, CommunityModel pModeloComunidad, IHttpContextAccessor httpContextAccessor, LoggingService loggingService, EntityContext entityContext, ConfigService configService, RedisCacheWrapper redisCacheWrapper, GnossCache gnossCache, EntityContextBASE entityContextBASE, VirtuosoAD virtuosoAD, ICompositeViewEngine viewEngine)
           : base(loggingService, configService, entityContext, redisCacheWrapper, gnossCache, virtuosoAD, httpContextAccessor)
        {
            mControlador = pControlador;
            mComponenteID = pComponenteID;
            mTipoUbicacionCMSPaginaActual = pTipoUbicacionCMSPaginaActual;
            mComunidad = pModeloComunidad;
            mHttpContextAccessor = httpContextAccessor;
            mEntityContext = entityContext;
            mLoggingService = loggingService;
            mConfigService = configService;
            mRedisCacheWrapper = redisCacheWrapper;
            mEntityContextBASE = entityContextBASE;
            mGnossCache = gnossCache;
            mVirtuosoAD = virtuosoAD;
            mViewEngine = viewEngine;
        }

        #endregion

        #region Métodos

        public bool TieneUsuarioAccesoAComponente(bool pEsIdentidadInvitada)
        {
            bool tieneacceso = ProyectoSeleccionado.TipoAcceso.Equals(TipoAcceso.Publico) || ProyectoSeleccionado.TipoAcceso.Equals(TipoAcceso.Restringido) || !pEsIdentidadInvitada;

            if (!tieneacceso && (ProyectoSeleccionado.TipoAcceso.Equals(TipoAcceso.Privado) || ProyectoSeleccionado.TipoAcceso.Equals(TipoAcceso.Reservado)))
            {
                if (GestorCMSActual.ListaComponentes.ContainsKey(mComponenteID.Value))
                {
                    CMSComponente fichaComponente = GestorCMSActual.ListaComponentes[mComponenteID.Value];
                    tieneacceso = fichaComponente.AccesoPublico;
                }
            }

            if (!tieneacceso)
            {
                bool rangoAdmitido = false;
                string IPRecargarComponentes = "";
                string ipPeticion = mHttpContextAccessor.HttpContext.Request.Host.ToString();
                if (mHttpContextAccessor.HttpContext.Request.Headers != null && mHttpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    ipPeticion = mHttpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                }//"Parametro = '" + TiposParametrosAplicacion.IPRecargarComponentes.ToString() + "'"
                if (ListaParametrosAplicacion.Count(item => item.Parametro.Equals(TiposParametrosAplicacion.IPRecargarComponentes)) > 0)
                {
                    IPRecargarComponentes = ListaParametrosAplicacion.First(item => item.Parametro.Equals(TiposParametrosAplicacion.IPRecargarComponentes)).Valor;
                }
                rangoAdmitido = ipPeticion == "127.0.0.1" || (!string.IsNullOrEmpty(IPRecargarComponentes) && ipPeticion.StartsWith(IPRecargarComponentes));

                if (!rangoAdmitido)
                {
                    return false;
                }
            }

            return true;
        }

        public CMSComponent CargarComponente()
        {
            /*Parámetros:
                     * componenteID(obligatorio): ID del componente
                     * idioma: idioma en el que se pide (si no se pide se hace en todos los idiomas del ecosistema)
                     * pintar: indica si se pinta o no (si no se especifica, false y refrescar=true. Si no hay idioma pintar=false)
                     * refrescar: indica si se refresca (si no se especifica, false, pero si no se especifica pintar refrescar=true)                 * 
                     */
            //Single viene ComponentName se pinta tal cual en el idioma de la petición

            string idiomaPedido = RequestParams("idioma");
            //Hay que pintar el HTML (bool pintar y string idioma)
            bool pintar = false;
            bool.TryParse(RequestParams("pintar"), out pintar);
            PintarComponente = pintar;

            List<string> listaIdiomas = mConfigService.ObtenerListaIdiomas();
            if (string.IsNullOrEmpty(idiomaPedido) || !listaIdiomas.Contains(idiomaPedido))
            {
                //Si no se especifica idioma no se pinta
                PintarComponente = false;
            }

            //Hay que generar el HTML (bool refrescar)
            bool.TryParse(RequestParams("refrescar"), out mRefrescar);
            if (!PintarComponente)
            {
                mRefrescar = true;
            }

            string componentName = RequestParams("ComponentName");
            if (!string.IsNullOrEmpty(componentName))
            {
                idiomaPedido = UtilIdiomas.LanguageCode;
                PintarComponente = true;
                mRefrescar = false;
            }

            return CargarComponente(PintarComponente, mRefrescar, idiomaPedido);
        }

        public CMSComponent CargarComponente(bool pPintar, bool pRefrescar, string pIdioma)
        {
            CMSComponent fichaComponente = null;
            CMSComponente componenteCMS = null;
            mRefrescar = pRefrescar;

            if (GestorCMSActual.ListaComponentes.ContainsKey(mComponenteID.Value))
            {
                componenteCMS = GestorCMSActual.ListaComponentes[mComponenteID.Value];
            }

            if (componenteCMS != null)
            {

                if (pPintar && !pRefrescar)
                {
                    //Buscarlo en cache (nulo si no esta en cache)
                    CMSCL cmsCL = new CMSCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
                    fichaComponente = cmsCL.ObtenerComponentePorIDEnProyecto(ProyectoSeleccionado.Clave, mComponenteID.Value, pIdioma);
                    cmsCL.Dispose();

                    if (fichaComponente == null)
                    {
                        pRefrescar = true;
                    }
                    else
                    {
                        ObtenerNombresVistas(componenteCMS, ref fichaComponente);
                    }
                }

                if (pRefrescar && ListaIdiomas.Contains(pIdioma))
                {
                    //Generamos la ficha y la guardamos en caché
                    fichaComponente = ObtenerFichaDeComponente(null, componenteCMS, pIdioma);
                }
            }
            return fichaComponente;
        }

        public List<CMSBlock> CargarBloquesPaginaCMS()
        {
            if (mControlador.ParametrosGeneralesRow.CMSDisponible)
            {
                bool activo = false;
                if (GestorCMSActual.ListaPaginasProyectos.ContainsKey(mControlador.ProyectoSeleccionado.Clave) && GestorCMSActual.ListaPaginasProyectos[mControlador.ProyectoSeleccionado.Clave].ContainsKey(mTipoUbicacionCMSPaginaActual.Value))
                {
                    activo = GestorCMSActual.ListaPaginasProyectos[mControlador.ProyectoSeleccionado.Clave][mTipoUbicacionCMSPaginaActual.Value].Activa;
                }

                if (activo)
                {
                    //Obtenemos el model de la página del CMS
                    List<CMSBlock> listaBloques = new List<CMSBlock>();
                    foreach (CMSBloque bloque in GestorCMSActual.ListaBloques.Values.Where(block => block.BloquePadreID == null).OrderBy(block => block.Orden))
                    {
                        if ((VistaPrevia || !bloque.Borrador))
                        {
                            CMSBlock modeloBloque = obtenerBloque(bloque);
                            if (modeloBloque != null)
                            {
                                listaBloques.Add(modeloBloque);
                            }
                        }
                    }

                    CommunityModel.TabModel pestanyaActiva = null;
                    if (mTipoUbicacionCMSPaginaActual <= (short)(TipoUbicacionCMS.HomeProyecto))
                    {
                        pestanyaActiva = mComunidad.Tabs.Find(pestanya => pestanya.Url != null && pestanya.Url.ToLower().EndsWith((mControlador.UtilIdiomas.GetText("URLSEM", "COMUNIDAD") + "/" + mControlador.ProyectoSeleccionado.NombreCorto).ToLower()));
                    }
                    else
                    {
                        foreach (AD.EntityModel.Models.ProyectoDS.ProyectoPestanyaCMS filaPestanya in mControlador.ProyectoSeleccionado.GestorProyectos.DataWrapperProyectos.ListaProyectoPestanyaCMS)
                        {
                            if (filaPestanya.Ubicacion == mTipoUbicacionCMSPaginaActual)
                            {
                                pestanyaActiva = ObtenerPestanyaActiva(mComunidad.Tabs, filaPestanya.PestanyaID);
                                break;
                            }
                        }
                    }

                    if (pestanyaActiva != null)
                    {
                        pestanyaActiva.Active = true;
                    }

                    mControlador.ViewBag.TipoUbicacionCMSPaginaActual = mTipoUbicacionCMSPaginaActual;

                    return listaBloques;
                }
            }

            return null;
        }

        private CommunityModel.TabModel ObtenerPestanyaActiva(List<CommunityModel.TabModel> pListaPestanyas, Guid pPestanyaID)
        {
            CommunityModel.TabModel pestanyaActiva = null;
            pestanyaActiva = pListaPestanyas.Find(pestanya => (pestanya.Key == pPestanyaID));
            if (pestanyaActiva == null)
            {
                foreach (CommunityModel.TabModel pestanya in pListaPestanyas)
                {
                    if (pestanya.SubTab != null)
                    {
                        pestanyaActiva = ObtenerPestanyaActiva(pestanya.SubTab, pPestanyaID);
                        if (pestanyaActiva != null)
                        {
                            break;
                        }
                    }
                }
            }
            return pestanyaActiva;
        }

        /// <summary>
        /// Obtiene la ficha de un componente
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponent ObtenerFichaDeComponente(CMSBloque pCMSBloque, CMSComponente pComponente, string pIdioma)
        {
            CMSComponent fichaComponente = null;

            //Comprobamos su cumple el idioma
            bool cumpleIdioma = !mControlador.ParametroProyecto.ContainsKey(ParametroAD.PropiedadContenidoMultiIdioma) && (!mControlador.ParametroProyecto.ContainsKey(ParametroAD.PropiedadCMSMultiIdioma) || mControlador.ParametroProyecto[ParametroAD.PropiedadCMSMultiIdioma] == "0") || pComponente.ListaIdiomasDisponibles(mConfigService.ObtenerListaIdiomas()).Contains(IdiomaUsuario);

            //Comprobamos si cumple la privacidad
            bool cumplePrivacidad = true;

            if (pComponente.Privado)
            {
                cumplePrivacidad = false;
                if (!EsIdentidadInvitada && !PerfilID.Equals(UsuarioAD.Invitado))
                {
                    foreach (Guid perfilID in pComponente.ListaRolIdentidad.Keys)
                    {
                        if (PerfilID == perfilID)
                        {
                            cumplePrivacidad = true;
                            break;
                        }
                    }

                    if (!cumplePrivacidad)
                    {
                        foreach (Guid grupoID in pComponente.ListaRolGrupoIdentidades.Keys)
                        {
                            if (ListaGruposIdentidadActual.Contains(grupoID))
                            {
                                cumplePrivacidad = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (cumpleIdioma && cumplePrivacidad)
            {
                try
                {

                    if (pComponente.TipoComponenteCMS == TipoComponenteCMS.Faceta && ((CMSComponenteFaceta)pComponente).TipoPresentacionFaceta != TipoPresentacionFacetas.Normal)
                    {
                        CargarJSGraficasGoogle();
                    }

                    if (ListaComponentesCache.ContainsKey(pComponente.Clave) && ListaComponentesCache[pComponente.Clave] != null)
                    {
                        fichaComponente = ListaComponentesCache[pComponente.Clave];

                        if (fichaComponente != null)
                        {
                            if (pComponente is CMSComponenteTesauro)
                            {
                                ((CMSComponentThesaurus)fichaComponente).UrlIndex = UrlsSemanticas.ObtenerURLComunidad(mControlador.UtilIdiomas, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + mControlador.UtilIdiomas.GetText("URLSEM", "INDICE");
                                ((CMSComponentThesaurus)fichaComponente).UrlBaseCategories = UrlsSemanticas.ObtenerURLComunidad(mControlador.UtilIdiomas, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + mControlador.UtilIdiomas.GetText("URLSEM", "CATEGORIA");
                            }
                        }
                    }
                    if (fichaComponente == null)
                    {
                        if (pComponente is CMSComponenteHTML)
                        {
                            fichaComponente = ObtenerFichaHtmlLibre((CMSComponenteHTML)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteDestacado)
                        {
                            fichaComponente = ObtenerFichaComponenteDestacado((CMSComponenteDestacado)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteListadoPorParametros)
                        {
                            fichaComponente = ObtenerFichaListadoPorParametros((CMSComponenteListadoPorParametros)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteListadoEstatico)
                        {
                            fichaComponente = ObtenerFichaListadoEstatico((CMSComponenteListadoEstatico)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteGrupoComponentes)
                        {
                            fichaComponente = ObtenerFichaGrupoComponentes(pCMSBloque, (CMSComponenteGrupoComponentes)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteEnvioCorreo)
                        {
                            fichaComponente = ObtenerFichaEnvioCorreo((CMSComponenteEnvioCorreo)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteMenu)
                        {
                            fichaComponente = ObtenerFichaMenu(pCMSBloque, (CMSComponenteMenu)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteBuscador)
                        {
                            fichaComponente = ObtenerFichaBuscador((CMSComponenteBuscador)pComponente, "", 1, pIdioma);
                        }
                        else if (pComponente is CMSComponenteListadoDinamico)
                        {
                            fichaComponente = ObtenerFichaListadoDinamico((CMSComponenteListadoDinamico)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteActividadReciente)
                        {
                            fichaComponente = ObtenerFichaActividadReciente((CMSComponenteActividadReciente)pComponente, pIdioma, 1);
                        }
                        else if (pComponente is CMSComponenteFaceta)
                        {
                            fichaComponente = ObtenerFichaFaceta((CMSComponenteFaceta)pComponente, "", pIdioma);
                        }
                        else if (pComponente is CMSComponenteTesauro)
                        {
                            fichaComponente = ObtenerFichaTesauro((CMSComponenteTesauro)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteDatosComunidad)
                        {
                            fichaComponente = ObtenerFichaDatosComunidad((CMSComponenteDatosComunidad)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteUsuariosRecomendados)
                        {
                            fichaComponente = ObtenerFichaUsuariosRecomendados((CMSComponenteUsuariosRecomendados)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteCajaBuscador)
                        {
                            fichaComponente = ObtenerFichaCajaBuscador((CMSComponenteCajaBuscador)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteBuscadorSPARQL)
                        {
                            fichaComponente = ObtenerFichaBuscadorSPARQL((CMSComponenteBuscadorSPARQL)pComponente, pIdioma, 1, "");
                        }
                        else if (pComponente is CMSComponenteUltimosRecursosVisitados)
                        {
                            fichaComponente = ObtenerFichaUltimosRecursosVisitados((CMSComponenteUltimosRecursosVisitados)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteFichaDescripcionDocumento)
                        {
                            fichaComponente = ObtenerFichaFichaDescripcionDocumento((CMSComponenteFichaDescripcionDocumento)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteResumenPerfil)
                        {
                            fichaComponente = ObtenerFichaResumenPerfil((CMSComponenteResumenPerfil)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteConsultaSPARQL)
                        {
                            fichaComponente = ObtenerFichaConsultaSPARQL((CMSComponenteConsultaSPARQL)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteConsultaSQLSERVER)
                        {
                            fichaComponente = ObtenerFichaConsultaSQLSERVER((CMSComponenteConsultaSQLSERVER)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteMasVistos)
                        {
                            fichaComponente = ObtenerFichaMasVistos((CMSComponenteMasVistos)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteMasVistosEnXDias)
                        {
                            fichaComponente = ObtenerFichaMasVistosEnXDias((CMSComponenteMasVistosEnXDias)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteListadoUsuarios)
                        {
                            fichaComponente = ObtenerFichaListadoUsuarios((CMSComponenteListadoUsuarios)pComponente, pIdioma);
                        }
                        else if (pComponente is CMSComponenteListadoProyectos)
                        {
                            fichaComponente = ObtenerFichaListadoProyectos((CMSComponenteListadoProyectos)pComponente, pIdioma);
                        }
                        else
                        {
                            fichaComponente = null;
                        }

                        if (pComponente.TipoCaducidadComponenteCMS != TipoCaducidadComponenteCMS.NoCache)
                        {
                            if (fichaComponente != null)
                            {
                                CMSCL cmsCL = new CMSCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
                                cmsCL.RefrescarComponentePorIDEnProyecto(ProyectoSeleccionado.Clave, pComponente.Clave, pIdioma, fichaComponente);
                                cmsCL.Dispose();
                            }
                        }
                    }
                    if (fichaComponente != null)
                    {
                        ObtenerNombresVistas(pComponente, ref fichaComponente);
                    }
                }
                catch (Exception ex)
                {
                    mLoggingService.GuardarLogError(ex, "Error producido en el componente con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + ProyectoSeleccionado.Nombre + " \n ");
                }
            }
            return fichaComponente;
        }

        private void CargarJSGraficasGoogle()
        {
            if (!mJSGraficasGoogleCargado)
            {
                mControlador.ViewBag.ListaJS.Add($"//www.google.com/jsapi?key={mConfigService.ObtenerClaveApiGoogle()}");
                mJSGraficasGoogleCargado = true;
            }
        }

        #endregion

        #region Obtener Fichas

        /// <summary>
        /// Obtiene una ficha de un bloque
        /// </summary>
        /// <param name="pCMSBloque"></param>
        /// <returns></returns>
        public CMSBlock obtenerBloque(CMSBloque pCMSBloque)
        {
            CMSBlock fichaBloque = new CMSBlock();
            fichaBloque.Key = pCMSBloque.Clave;
            fichaBloque.Attributes = pCMSBloque.Atributos;
            if (pCMSBloque.BloquePadreID.HasValue)
            {
                fichaBloque.ParentKey = pCMSBloque.BloquePadreID;
            }

            List<CMSBlock> listaBloquesHijos = new List<CMSBlock>();
            foreach (CMSBloque bloque in pCMSBloque.Hijos)
            {
                if (VistaPrevia || !bloque.Borrador)
                {
                    CMSBlock modeloBloque = obtenerBloque(bloque);
                    if (modeloBloque != null)
                    {
                        listaBloquesHijos.Add(modeloBloque);
                    }
                }
            }
            fichaBloque.BlockList = listaBloquesHijos;

            List<CMSComponent> listaComponentes = new List<CMSComponent>();
            //No aparecen los componentes que no estan activos
            foreach (CMSComponente componente in pCMSBloque.Componentes.Values)
            {
                CMSComponent ficha = ObtenerFichaDeComponente(pCMSBloque, componente, IdiomaUsuario);
                if (ficha != null)
                {
                    listaComponentes.Add(ficha);
                }
            }
            fichaBloque.ComponentList = listaComponentes;
            if (fichaBloque.BlockList.Count == 0 && fichaBloque.ComponentList.Count == 0)
            {
                fichaBloque = null;
            }
            return fichaBloque;
        }

        #region Fichas de componentes

        private string ObtenerComponenteVistaPersonalizada(CMSComponente pComponente, string pNombreVista)
        {
            string nombreVista = pNombreVista;

            List<string> listaPersonalizaciones = Comunidad.ListaPersonalizaciones;
            List<string> listaPersonalizacionesEcosistema = Comunidad.ListaPersonalizacionesEcosistema;

            if ((listaPersonalizaciones != null && listaPersonalizaciones.Count > 0) || (listaPersonalizacionesEcosistema != null && listaPersonalizacionesEcosistema.Count > 0))
            {
                List<VistaVirtualCMS> filas = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVista)).ToList();

                if (filas.Count > 0)
                {
                    //Devolvemos la primera vista personalizada
                    string nombreVistaDefecto = filas.First().PersonalizacionComponenteID.ToString();
                    if (ComprobarExisteVista(nombreVistaDefecto))
                    {
                        nombreVista = nombreVistaDefecto;
                    }
                }

                if (pComponente.Personalizacion.HasValue)
                {
                    VistaVirtualCMS filaVistaVirtualCMS = filas.FirstOrDefault(f => f.PersonalizacionComponenteID == pComponente.Personalizacion);

                    if (filaVistaVirtualCMS != null)
                    {
                        string nombreVistaAux = filaVistaVirtualCMS.PersonalizacionComponenteID.ToString();
                        if (ComprobarExisteVista(nombreVistaAux))
                        {
                            nombreVista = nombreVistaAux;
                        }
                    }

                }
            }
            return nombreVista.Replace("/Views/CMSPagina/", "").Replace(".cshtml", "");
        }

        private bool ComprobarExisteVista(string pNombreVista)
        {
            if (Comunidad.ListaPersonalizaciones.Contains("/Views/CMSPagina/" + pNombreVista + ".cshtml"))
            {
                return true;
            }
            else if (Comunidad.ListaPersonalizacionesEcosistema.Contains("/Views/CMSPagina/" + pNombreVista + ".cshtml"))
            {
                return true;
            }
            return false;
        }

        public void ObtenerNombresVistas(CMSComponente pComponente, ref CMSComponent pFichaComponente)
        {
            #region Componentes

            //Pueden estar sobreescritas n veces
            string nombreVista = "/Views/CMSPagina/";

            if (pComponente is CMSComponenteGrupoComponentes)
            {
                nombreVista += "GrupoComponentes";
            }
            else if (pComponente is CMSComponenteListadoDinamico || pComponente is CMSComponenteListadoEstatico)
            {
                nombreVista += "ListadoRecursos";
            }
            else
            {
                nombreVista += pComponente.TipoComponenteCMS.ToString() + "/_" + pComponente.TipoComponenteCMS.ToString();
            }

            nombreVista += ".cshtml";

            nombreVista = ObtenerComponenteVistaPersonalizada(pComponente, nombreVista);

            pFichaComponente.ViewName = nombreVista;

            #endregion

            #region Recursos

            //Pueden estar sobreescritas 1 vez y además se pueden crear más
            if (pComponente.PropiedadesComponente.ContainsKey(TipoPropiedadCMS.TipoPresentacionRecurso))
            {
                string tipoPresentacion = pComponente.PropiedadesComponente[TipoPropiedadCMS.TipoPresentacionRecurso];

                short presentacionShort = 0;
                Guid presentacionGuid = Guid.Empty;

                if (Guid.TryParse(tipoPresentacion, out presentacionGuid))
                {
                    string nombreVistaAux = presentacionGuid.ToString();
                    if (ComprobarExisteVista(nombreVistaAux))
                    {
                        pFichaComponente.ViewNameResources = nombreVistaAux;
                    }
                    else
                    {
                        presentacionGuid = Guid.Empty;
                    }
                }

                if (presentacionGuid == Guid.Empty)
                {
                    short.TryParse(tipoPresentacion, out presentacionShort);
                    string nombreVistaRecursos = "/Views/CMSPagina/ListadoRecursos/Vistas/_" + ((TipoPresentacionRecursoCMS)(presentacionShort)).ToString() + ".cshtml";

                    List<VistaVirtualCMS> filas2 = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVistaRecursos)).ToList();
                    if (filas2.Count > 0)
                    {
                        string nombreVistaAux = filas2.First().PersonalizacionComponenteID.ToString();
                        if (ComprobarExisteVista(nombreVistaAux))
                        {
                            nombreVistaRecursos = nombreVistaAux;
                        }
                    }
                    pFichaComponente.ViewNameResources = nombreVistaRecursos.Replace("/Views/CMSPagina/", "").Replace(".cshtml", "");
                }
            }
            #endregion

            #region GruposComponentes
            //Pueden estar sobreescritas 1 vez y además se pueden crear más
            if (pComponente is CMSComponenteGrupoComponentes)
            {
                string tipoPresentacion = pComponente.PropiedadesComponente[TipoPropiedadCMS.TipoPresentacionGrupoComponentes];
                short presentacionShort = 0;
                Guid presentacionGuid = Guid.Empty;
                if (Guid.TryParse(tipoPresentacion, out presentacionGuid))
                {
                    string nombreVistaAux = presentacionGuid.ToString();
                    if (ComprobarExisteVista(nombreVistaAux))
                    {
                        pFichaComponente.ViewName = nombreVistaAux;
                    }
                    else
                    {
                        presentacionGuid = Guid.Empty;
                    }
                }

                if (presentacionGuid == Guid.Empty)
                {
                    short.TryParse(tipoPresentacion, out presentacionShort);
                    string nombreVistaGruposComponentes = "/Views/CMSPagina/GrupoComponentes/_" + ((TipoPresentacionGrupoComponentesCMS)(presentacionShort)).ToString() + ".cshtml";
                    List<VistaVirtualCMS> filas2 = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVistaGruposComponentes)).ToList();
                    if (filas2.Count > 0)
                    {
                        string nombreVistaAux = filas2.First().PersonalizacionComponenteID.ToString();
                        if (ComprobarExisteVista(nombreVistaAux))
                        {
                            nombreVistaGruposComponentes = nombreVistaAux;
                        }
                    }
                    pFichaComponente.ViewName = nombreVistaGruposComponentes.Replace("/Views/CMSPagina/", "").Replace(".cshtml", "");
                }
            }
            #endregion

            if (pComponente is CMSComponenteListadoUsuarios)
            {
                pFichaComponente.ViewNameResources = ((CMSComponenteListadoUsuarios)pComponente).TipoPresentacionListadoUsuarios.ToString();
            }

            #region Listado recursos

            //Pueden estar sobreescritas 1 vez y además se pueden crear más
            if (pComponente.PropiedadesComponente.ContainsKey(TipoPropiedadCMS.TipoPresentacionListadoRecursos))
            {
                string tipoPresentacion = pComponente.PropiedadesComponente[TipoPropiedadCMS.TipoPresentacionListadoRecursos];
                short presentacionShort = 0;
                Guid presentacionGuid = Guid.Empty;
                if (Guid.TryParse(tipoPresentacion, out presentacionGuid))
                {
                    string nombreVistaAux = presentacionGuid.ToString();
                    if (ComprobarExisteVista(nombreVistaAux))
                    {
                        pFichaComponente.ViewName = nombreVistaAux;
                    }
                    else
                    {
                        presentacionGuid = Guid.Empty;
                    }
                }

                if (presentacionGuid == Guid.Empty)
                {
                    short.TryParse(tipoPresentacion, out presentacionShort);
                    string nombreVistaListadoRecursos = "/Views/CMSPagina/ListadoRecursos/_" + ((TipoPresentacionListadoRecursosCMS)(presentacionShort)).ToString() + ".cshtml";
                    List<VistaVirtualCMS> filas2 = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVistaListadoRecursos)).ToList();
                    if (filas2.Count > 0)
                    {
                        string nombreVistaAux = filas2.First().PersonalizacionComponenteID.ToString();
                        if (ComprobarExisteVista(nombreVistaAux))
                        {
                            nombreVistaListadoRecursos = nombreVistaAux;
                        }
                    }
                    pFichaComponente.ViewName = nombreVistaListadoRecursos.Replace("/Views/CMSPagina/", "").Replace(".cshtml", "");
                }
            }
            else if (UtilComponentes.PropiedadesDisponiblesPorTipoComponente[pComponente.TipoComponenteCMS].ContainsKey(TipoPropiedadCMS.TipoPresentacionListadoRecursos) && UtilComponentes.PropiedadesDisponiblesPorTipoComponente[pComponente.TipoComponenteCMS][TipoPropiedadCMS.TipoPresentacionListadoRecursos])
            {
                //Si el tipo de componente contiene la propiedad TipoPresentacionListadoRecursos y es obligatoria le asignamos destacados
                string nombreVistaListadoRecursos = "/Views/CMSPagina/ListadoRecursos/_" + (TipoPresentacionListadoRecursosCMS.ListadoDestacados).ToString() + ".cshtml";
                List<VistaVirtualCMS> filas2 = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVistaListadoRecursos)).ToList();
                if (filas2.Count > 0)
                {
                    string nombreVistaAux = filas2.First().PersonalizacionComponenteID.ToString();
                    if (ComprobarExisteVista(nombreVistaAux))
                    {
                        nombreVistaListadoRecursos = nombreVistaAux;
                    }
                }

                pFichaComponente.ViewName = nombreVistaListadoRecursos.Replace("/Views/CMSPagina/", "").Replace(".cshtml", "");
            }
            #endregion

            if (mTipoUbicacionCMSPaginaActual.HasValue)
            {
                pFichaComponente.AJAX = true;
            }
            else
            {
                pFichaComponente.AJAX = false;
            }

        }

        public void ObtenerDatoExtraRecursosComponente(CMSComponente pComponente, ref bool pDatosExtraRecursos, ref bool pIdentidades, ref bool pDatosExtraIdentidades)
        {
            pDatosExtraRecursos = true;
            pIdentidades = true;
            pDatosExtraIdentidades = false;

            #region Recursos
            string nombreVistaRecursos = "/Views/CMSPagina/ListadoRecursos/Vistas/";
            if (pComponente.PropiedadesComponente.ContainsKey(TipoPropiedadCMS.TipoPresentacionRecurso))
            {
                string tipoPresentacion = pComponente.PropiedadesComponente[TipoPropiedadCMS.TipoPresentacionRecurso];
                short presentacionShort = 0;
                Guid presentacionGuid = Guid.Empty;
                Guid.TryParse(tipoPresentacion, out presentacionGuid);
                short.TryParse(tipoPresentacion, out presentacionShort);
                List<VistaVirtualCMS> listaVistaVirtualCMS = null;
                if (!presentacionGuid.Equals(Guid.Empty))
                {
                    listaVistaVirtualCMS = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.PersonalizacionComponenteID.Equals(presentacionGuid)).ToList();
                }
                else
                {
                    nombreVistaRecursos += "_" + ((TipoPresentacionRecursoCMS)(presentacionShort)).ToString() + ".cshtml";
                    listaVistaVirtualCMS = VistaVirtualDW.ListaVistaVirtualCMS.Where(item => item.TipoComponente.Equals(nombreVistaRecursos)).ToList();
                }
                if (listaVistaVirtualCMS != null && listaVistaVirtualCMS.Count == 1)
                {
                    if (listaVistaVirtualCMS[0].DatosExtra != null && !string.IsNullOrEmpty(listaVistaVirtualCMS[0].DatosExtra))
                    {
                        string[] datosExtraArray = listaVistaVirtualCMS[0].DatosExtra.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> datosExtraList = datosExtraArray.OfType<string>().ToList();
                        pDatosExtraRecursos = (string.IsNullOrEmpty(listaVistaVirtualCMS[0].DatosExtra) || datosExtraList.Contains(DatosExtraVistas.DatosExtraRecursos.ToString()));
                        pIdentidades = (string.IsNullOrEmpty(listaVistaVirtualCMS[0].DatosExtra) || datosExtraList.Contains(DatosExtraVistas.Identidades.ToString()));
                        pDatosExtraIdentidades = (!string.IsNullOrEmpty(listaVistaVirtualCMS[0].DatosExtra) && datosExtraList.Contains(DatosExtraVistas.DatosExtraIdentidades.ToString()));
                    }
                }
            }
            #endregion

        }

        /// <summary>
        /// Obtiene la ficha de un componente HTML libre
        /// </summary>
        /// <param name="pCMSBloque"></param>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentHTML ObtenerFichaHtmlLibre(CMSComponenteHTML pComponente, string pIdioma)
        {
            CMSComponenteHTML componenteHTML = (CMSComponenteHTML)pComponente;
            CMSComponentHTML fichaComponenteHTMLLibre = new CMSComponentHTML();
            fichaComponenteHTMLLibre.Key = componenteHTML.Clave;
            fichaComponenteHTMLLibre.Styles = componenteHTML.Estilos;
            fichaComponenteHTMLLibre.HTML = UtilCadenas.ObtenerTextoDeIdioma(componenteHTML.HTML, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteHTMLLibre.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteHTML.Titulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);

            return fichaComponenteHTMLLibre;
        }

        /// <summary>
        /// Obtiene la ficha de un componente destacado
        /// </summary>
        /// <param name="pCMSBloque"></param>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentHot ObtenerFichaComponenteDestacado(CMSComponenteDestacado pComponente, string pIdioma)
        {
            CMSComponenteDestacado componenteDestacado = (CMSComponenteDestacado)pComponente;
            CMSComponentHot fichaComponenteDestacado = new CMSComponentHot();
            fichaComponenteDestacado.Key = componenteDestacado.Clave;
            fichaComponenteDestacado.Styles = componenteDestacado.Estilos;
            fichaComponenteDestacado.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteDestacado.Titulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteDestacado.Link = UtilCadenas.ObtenerTextoDeIdioma(componenteDestacado.Enlace, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteDestacado.HTML = UtilCadenas.ObtenerTextoDeIdioma(componenteDestacado.HTML, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteDestacado.Image = UtilCadenas.ObtenerTextoDeIdioma(componenteDestacado.Imagen, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteDestacado.Subtitle = UtilCadenas.ObtenerTextoDeIdioma(componenteDestacado.Subtitulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);

            return fichaComponenteDestacado;
        }

        /// <summary>
        /// Obtiene la ficha de un grupo de componentes
        /// </summary>
        /// <param name="pCMSBloque"></param>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentGroupComponents ObtenerFichaGrupoComponentes(CMSBloque pCMSBloque, CMSComponenteGrupoComponentes pComponente, string pIdioma)
        {
            CMSComponenteGrupoComponentes componenteGrupo = (CMSComponenteGrupoComponentes)pComponente;
            CMSComponentGroupComponents fichaComponenteGrupo = new CMSComponentGroupComponents();
            fichaComponenteGrupo.Key = componenteGrupo.Clave;
            fichaComponenteGrupo.Styles = componenteGrupo.Estilos;
            fichaComponenteGrupo.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteGrupo.Titulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteGrupo.ComponentList = new List<CMSComponent>();
            foreach (Guid componenteID in componenteGrupo.ListaGuids)
            {
                if (GestorCMSActual.ListaComponentes.ContainsKey(componenteID))
                {
                    CMSComponent componente = ObtenerFichaDeComponente(pCMSBloque, GestorCMSActual.ListaComponentes[componenteID], pIdioma);
                    if (componente != null)
                    {
                        fichaComponenteGrupo.ComponentList.Add(componente);
                    }
                }
            }
            return fichaComponenteGrupo;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de envio de correo
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentMail ObtenerFichaEnvioCorreo(CMSComponenteEnvioCorreo pComponente, string pIdioma)
        {
            CMSComponenteEnvioCorreo componenteEnvioCorreo = pComponente;
            CMSComponentMail fichaComponenteEnvioCorreo = new CMSComponentMail();
            fichaComponenteEnvioCorreo.Key = componenteEnvioCorreo.Clave;
            fichaComponenteEnvioCorreo.Styles = componenteEnvioCorreo.Estilos;
            fichaComponenteEnvioCorreo.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteEnvioCorreo.Titulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteEnvioCorreo.TextButton = UtilCadenas.ObtenerTextoDeIdioma(componenteEnvioCorreo.TextoBoton, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteEnvioCorreo.TextOK = UtilCadenas.ObtenerTextoDeIdioma(componenteEnvioCorreo.TextoMensajeOK, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);

            fichaComponenteEnvioCorreo.FormFields = new List<CMSComponentMail.CMSFormFiled>();
            foreach (short orden in componenteEnvioCorreo.ListaCamposEnvioCorreo.Keys)
            {
                string nombreCampo = UtilCadenas.ObtenerTextoDeIdioma(componenteEnvioCorreo.ListaCamposEnvioCorreo[orden][TipoPropiedadEnvioCorreo.Nombre], pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
                bool obligatorio = bool.Parse(componenteEnvioCorreo.ListaCamposEnvioCorreo[orden][TipoPropiedadEnvioCorreo.Obligatorio]);
                CMSComponentMail.CMSFormFiled.CMSFormFiledType TipoCampo = (CMSComponentMail.CMSFormFiled.CMSFormFiledType)short.Parse(componenteEnvioCorreo.ListaCamposEnvioCorreo[orden][TipoPropiedadEnvioCorreo.TipoCampo]); ;

                CMSComponentMail.CMSFormFiled campoFormulario = new CMSComponentMail.CMSFormFiled();
                campoFormulario.Name = nombreCampo;
                campoFormulario.Order = orden;
                campoFormulario.Required = obligatorio;
                campoFormulario.FormFiledType = TipoCampo;
                fichaComponenteEnvioCorreo.FormFields.Add(campoFormulario);
            }
            fichaComponenteEnvioCorreo.UrlSendForm = mControlador.BaseURLIdioma;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (ProyectoSeleccionado.Clave != ProyectoAD.MetaProyecto)
            {
                fichaComponenteEnvioCorreo.UrlSendForm = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, ProyectoSeleccionado.NombreCorto);
            }
            fichaComponenteEnvioCorreo.UrlSendForm += "/CMSPagina/send-form";

            return fichaComponenteEnvioCorreo;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de menu
        /// </summary>
        /// <param name="pCMSBloque"></param>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentMenu ObtenerFichaMenu(CMSBloque pCMSBloque, CMSComponenteMenu pComponente, string pIdioma)
        {
            CMSComponenteMenu componenteMenu = pComponente;
            CMSComponentMenu fichaComponenteMenu = new CMSComponentMenu();
            fichaComponenteMenu.Key = componenteMenu.Clave;
            fichaComponenteMenu.Styles = componenteMenu.Estilos;
            fichaComponenteMenu.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteMenu.Titulo, pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteMenu.ItemList = new List<CMSComponentMenu.CMSComponentMenuItem>();

            string valorSeleccionado = "";
            if (pCMSBloque != null && pCMSBloque.PropiedadesComponentesBloque.ContainsKey(pComponente.Clave) && pCMSBloque.PropiedadesComponentesBloque[pComponente.Clave].ContainsKey(TipoPropiedadCMS.ValorSeleccionado))
            {
                valorSeleccionado = pCMSBloque.PropiedadesComponentesBloque[pComponente.Clave][TipoPropiedadCMS.ValorSeleccionado];
            }
            short nivelAnterior = 0;
            Dictionary<int, List<CMSComponentMenu.CMSComponentMenuItem>> listaOpcinesPadresDisponibles = new Dictionary<int, List<CMSComponentMenu.CMSComponentMenuItem>>();
            listaOpcinesPadresDisponibles.Add(0, fichaComponenteMenu.ItemList);
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            string urlcomunidad = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, ProyectoSeleccionado.NombreCorto);
            foreach (short orden in componenteMenu.ListaOpcionesMenu.Keys)
            {
                short nivel = componenteMenu.ListaOpcionesMenu[orden].Key;
                string nombre = UtilCadenas.ObtenerTextoDeIdioma(componenteMenu.ListaOpcionesMenu[orden].Value[TipoPropiedadMenu.Nombre], pIdioma, ParametrosGeneralesRow.IdiomaDefecto);
                string enlace = UtilCadenas.ObtenerTextoDeIdioma(componenteMenu.ListaOpcionesMenu[orden].Value[TipoPropiedadMenu.Enlace], pIdioma, ParametrosGeneralesRow.IdiomaDefecto);

                if (!enlace.StartsWith("http://"))
                {
                    enlace = urlcomunidad + "/" + enlace;
                }

                CMSComponentMenu.CMSComponentMenuItem opcionMenu = new CMSComponentMenu.CMSComponentMenuItem();
                opcionMenu.ItemList = new List<CMSComponentMenu.CMSComponentMenuItem>();
                if (listaOpcinesPadresDisponibles.ContainsKey(nivel + 1))
                {
                    listaOpcinesPadresDisponibles[nivel + 1] = opcionMenu.ItemList;
                }
                else
                {
                    listaOpcinesPadresDisponibles.Add(nivel + 1, opcionMenu.ItemList);
                }
                opcionMenu.Name = nombre;
                opcionMenu.Link = enlace;
                if (orden.ToString() == valorSeleccionado)
                {
                    opcionMenu.Active = true;
                }
                if (listaOpcinesPadresDisponibles.ContainsKey(nivel))
                {
                    listaOpcinesPadresDisponibles[nivel].Add(opcionMenu);
                }
                else
                {
                    listaOpcinesPadresDisponibles[0].Add(opcionMenu);
                }

                nivelAnterior = nivel;
            }
            return fichaComponenteMenu;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de listado de recursos estático
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentResourceList ObtenerFichaListadoEstatico(CMSComponente pComponente, string pIdioma)
        {
            CMSComponenteListadoEstatico componenteListadoEstatico = (CMSComponenteListadoEstatico)pComponente;

            List<string> BaseURLsContent = new List<string>();
            BaseURLsContent.Add(mControlador.BaseURLContent);

            CMSComponentResourceList fichaComponenteListadoRecursos = new CMSComponentResourceList();
            fichaComponenteListadoRecursos.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteListadoEstatico.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListadoRecursos.Key = pComponente.Clave;
            fichaComponenteListadoRecursos.Styles = pComponente.Estilos;
            fichaComponenteListadoRecursos.ResourceList = new List<ResourceModel>();
            //fichaComponenteListadoRecursos.URLSeeMore = ObtenerURLPaginaConFiltrosEnIdiomaActual(componenteListadoEstatico.URLVerMas, mComunidad.Tabs);
            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();
            Stopwatch sw = null;
            try
            {
                string parametros = "listadoRecursosEstatico:";
                foreach (Guid idRecurso in componenteListadoEstatico.ListaGuids)
                {
                    parametros += "," + idRecurso.ToString();
                }
                bool obtenerDatosExtraRecursos = false;
                bool obtenerIdentidades = false;
                bool obtenerDatosExtraIdentidades = false;
                ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                sw = LoggingService.IniciarRelojTelemetria();
                ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, false, false, UsuarioAD.Invitado, parametros, false, pIdioma, TipoBusqueda.Recursos, componenteListadoEstatico.ListaGuids.Count, "", mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultados", false, "ObtenerFichaListadoEstatico", sw, true);
                foreach (ResourceModel fichaRecurso in resultadoModel.ListaResultados)
                {
                    fichaComponenteListadoRecursos.ResourceList.Add(fichaRecurso);
                }
                //if (!string.IsNullOrEmpty(componenteListadoEstatico.URLVerMas))
                //{
                //    fichaComponenteListadoRecursos.URLSeeMore = ObtenerURLPaginaConFiltrosEnIdiomaActual(componenteListadoEstatico.URLVerMas, mComunidad.Tabs);
                //}
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente ListadoEstatico con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente ListadoEstatico con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaListadoEstatico", sw, false);
            }

            return fichaComponenteListadoRecursos;
        }



        /// <summary>
        /// Obtiene la ficha de un componente de listado de recursos por parametro
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentResourceList ObtenerFichaListadoPorParametros(CMSComponente pComponente, string pIdioma)
        {
            CMSComponenteListadoPorParametros componenteListadoPorParametros = (CMSComponenteListadoPorParametros)pComponente;

            List<string> BaseURLsContent = new List<string>();
            BaseURLsContent.Add(mControlador.BaseURLContent);

            CMSComponentResourceList fichaComponenteListadoRecursos = new CMSComponentResourceList();
            fichaComponenteListadoRecursos.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteListadoPorParametros.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListadoRecursos.Key = pComponente.Clave;
            fichaComponenteListadoRecursos.Styles = pComponente.Estilos;
            fichaComponenteListadoRecursos.ResourceList = new List<ResourceModel>();

            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();
            Stopwatch sw = null;
            try
            {
                int numItemsMax = 10;

                //System.Data.DataRow numItemsMaxConfig = ParametrosAplicacionDS.ParametroAplicacion.FindByParametro("MaxRecursosComponenteListadoPorParametros");
                AD.EntityModel.ParametroAplicacion numItemsMaxConfig = ListaParametrosAplicacion.FirstOrDefault(parametro => parametro.Parametro.Equals("MaxRecursosComponenteListadoPorParametros"));

                if (numItemsMaxConfig != null)
                {
                    int.TryParse(numItemsMaxConfig.Valor, out numItemsMax);
                }

                List<Guid> ListaGuids = new List<Guid>();
                string parametros = "listadoRecursosEstatico:";

                string paramListaIDs = mHttpContextAccessor.HttpContext.Request.Query["listaIDs"];
                if (!string.IsNullOrEmpty(paramListaIDs))
                {
                    string[] listaIDs = paramListaIDs.Split(',');
                    foreach (string idRecurso in listaIDs)
                    {
                        Guid documentoID;

                        if (Guid.TryParse(idRecurso, out documentoID))
                        {
                            ListaGuids.Add(documentoID);
                            parametros += "," + idRecurso;
                        }
                        //Configurar un limite de recursos por petición en parametroAplicacion
                        if (listaIDs.Length >= numItemsMax)
                        {
                            break;
                        }
                    }
                }

                bool obtenerDatosExtraRecursos = false;
                bool obtenerIdentidades = false;
                bool obtenerDatosExtraIdentidades = false;

                if (ListaGuids.Count > 0)
                {
                    ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                    sw = LoggingService.IniciarRelojTelemetria();
                    ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, false, false, UsuarioAD.Invitado, parametros, false, pIdioma, TipoBusqueda.Recursos, ListaGuids.Count, "", mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                    mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultados", false, "ObtenerFichaListadoPorParametros", sw, true);
                    foreach (ResourceModel fichaRecurso in resultadoModel.ListaResultados)
                    {
                        fichaComponenteListadoRecursos.ResourceList.Add(fichaRecurso);
                    }
                }
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente ListadoPorParametros con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente ListadoPorParametros con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaListadoPorParametros", sw, false);
            }

            return fichaComponenteListadoRecursos;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de listado de recursos dinámico
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentResourceList ObtenerFichaListadoDinamico(CMSComponente pComponente, string pIdioma)
        {
            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();

            CMSComponenteListadoDinamico componenteListadoDinamico = (CMSComponenteListadoDinamico)pComponente;

            componenteListadoDinamico.URLBusqueda = ReemplazarDatosUsuarioActual(componenteListadoDinamico.URLBusqueda);

            #region Parámetros de búsqueda

            string parametros = componenteListadoDinamico.URLBusqueda;

            if (parametros.Contains("?"))
            {
                parametros = parametros.Substring(parametros.IndexOf("?") + 1);
            }

            KeyValuePair<TipoBusqueda, Guid> tipoBusqueda = new KeyValuePair<TipoBusqueda, Guid>();
            try
            {
                tipoBusqueda = ObtenerTipoBusqueda(componenteListadoDinamico.URLBusqueda);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente Listado dinámico con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
            }

            Guid proyectoid = mControlador.ProyectoSeleccionado.Clave;
            //Comprobamos la pestaña
            AD.EntityModel.Models.ProyectoDS.ProyectoPestanyaBusqueda filaPestanya = mControlador.ProyectoSeleccionado.GestorProyectos.DataWrapperProyectos.ListaProyectoPestanyaBusqueda.FirstOrDefault(item => item.PestanyaID.Equals(tipoBusqueda.Value));
            if (filaPestanya != null)
            {
                parametros += "||parametrosAdicionales:" + filaPestanya.CampoFiltro;
                if (filaPestanya.ProyectoOrigenID.HasValue)
                {
                    proyectoid = filaPestanya.ProyectoOrigenID.Value;
                }
            }
            parametros = parametros.Replace("&", "|");

            #endregion


            CMSComponentResourceList fichaComponenteListadoRecursos = new CMSComponentResourceList();
            fichaComponenteListadoRecursos.Title = UtilCadenas.ObtenerTextoDeIdioma(componenteListadoDinamico.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListadoRecursos.Key = pComponente.Clave;
            fichaComponenteListadoRecursos.Styles = pComponente.Estilos;
            fichaComponenteListadoRecursos.ResourceList = new List<ResourceModel>();
            Guid identidadID = UsuarioAD.Invitado;
            bool estaEnProyecto = false;
            if (pComponente.TipoCaducidadComponenteCMS == TipoCaducidadComponenteCMS.NoCache)
            {
                if (proyectoid.Equals(mControlador.ProyectoSeleccionado.Clave))
                {
                    identidadID = IdentidadID;
                    estaEnProyecto = !EsIdentidadInvitada;
                }
                else
                {
                    identidadID = mControlador.IdentidadActual.ObtenerIdentidadEnProyectoDeIdentidad(proyectoid);
                    if (identidadID.Equals(Guid.Empty))
                    {
                        identidadID = UsuarioAD.Invitado;
                        estaEnProyecto = false;
                    }
                    else
                    {
                        estaEnProyecto = true;
                    }
                }
            }


            Stopwatch sw = null;

            try
            {
                bool obtenerDatosExtraRecursos = false;
                bool obtenerIdentidades = false;
                bool obtenerDatosExtraIdentidades = false;
                ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                sw = LoggingService.IniciarRelojTelemetria();
                ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(proyectoid, estaEnProyecto, false, identidadID, parametros, false, pIdioma, tipoBusqueda.Key, componenteListadoDinamico.NumeroItems, componenteListadoDinamico.URLBusqueda, mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultados", false, "ObtenerFichaListadoDinamico", sw, true);
                foreach (ObjetoBuscadorModel fichaRecurso in resultadoModel.ListaResultados)
                {
                    fichaComponenteListadoRecursos.ResourceList.Add((ResourceModel)fichaRecurso);
                }

                if (!string.IsNullOrEmpty(componenteListadoDinamico.URLVerMas))
                {
                    fichaComponenteListadoRecursos.URLSeeMore = ObtenerURLPaginaConFiltrosEnIdiomaActual(componenteListadoDinamico.URLVerMas, mComunidad.Tabs);
                }
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente ListadoDinamico con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente ListadoDinamico con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaListadoDinamico", sw, false);
            }

            return fichaComponenteListadoRecursos;
        }


        /// <summary>
        /// Obtiene la ficha de un componente buscador
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentSearch ObtenerFichaBuscador(CMSComponenteBuscador pComponente, string pFiltro, int pPagina, string pIdioma)
        {
            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();

            string urlBusqueda = ReemplazarDatosUsuarioActual(pComponente.URLBusqueda);

            #region Obtenemos los parametros de busqueda
            string parametros = urlBusqueda;

            if (parametros.Contains("?"))
            {
                parametros = parametros.Substring(parametros.IndexOf("?") + 1);
            }

            KeyValuePair<TipoBusqueda, Guid> tipoBusqueda = new KeyValuePair<TipoBusqueda, Guid>();
            try
            {
                tipoBusqueda = ObtenerTipoBusqueda(urlBusqueda);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente Buscador con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
            }

            //Comprobamos la pestaña
            foreach (AD.EntityModel.Models.ProyectoDS.ProyectoPestanyaBusqueda filaPestanya in mControlador.ProyectoSeleccionado.GestorProyectos.DataWrapperProyectos.ListaProyectoPestanyaBusqueda)
            {
                if (tipoBusqueda.Value == filaPestanya.ProyectoPestanyaMenu.PestanyaID)
                {
                    parametros += "&&parametrosAdicionales:" + filaPestanya.CampoFiltro;
                }
            }

            if (pPagina > 1)
            {
                parametros += "&pagina=" + pPagina.ToString();
            }
            if (!string.IsNullOrEmpty(pFiltro))
            {
                string[] filtros = pFiltro.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> listaFiltros = filtros.OfType<string>().ToList();

                string filtroDeAtributo = "";
                List<string> listaFiltrosExtra = new List<string>();

                foreach (string filtro in listaFiltros)
                {
                    if (!filtro.Contains("="))
                    {
                        filtroDeAtributo = filtro;
                    }
                    else
                    {
                        listaFiltrosExtra.Add(filtro);
                    }
                }

                if (!string.IsNullOrEmpty(filtroDeAtributo))
                {
                    if (parametros.Contains(pComponente.AtributoDeBusqueda + "="))
                    {
                        int filtroInicio = parametros.IndexOf(pComponente.AtributoDeBusqueda + "=");
                        int filtroFin = parametros.IndexOf("&", filtroInicio + 1);
                        if (filtroFin == -1)
                        {
                            filtroFin = parametros.Length;
                        }
                        string filtroActual = parametros.Substring(filtroInicio, filtroFin - filtroInicio);
                        if (filtroActual.Contains("=<>"))
                        {
                            parametros = parametros.Replace(filtroActual, pComponente.AtributoDeBusqueda + "=<>" + filtroDeAtributo);
                        }
                        else
                        {
                            parametros = parametros.Replace(filtroActual, pComponente.AtributoDeBusqueda + "=" + filtroDeAtributo);
                        }
                    }
                    else
                    {
                        parametros += "&" + pComponente.AtributoDeBusqueda + "=" + filtroDeAtributo;
                    }
                }

                foreach (string filtro in listaFiltrosExtra)
                {
                    //Eliminamos de parametros los filtros que vengan en filtros extra
                    string clave = filtro.Split('=')[0];
                    string valor = filtro.Split('=')[1];
                    int i = 0;
                    while (parametros.Contains(clave + "=") || i > 100)
                    {
                        int filtroInicio = parametros.IndexOf(clave + "=");
                        int filtroFin = parametros.IndexOf("&", filtroInicio + 1);
                        if (filtroFin == -1)
                        {
                            filtroFin = parametros.Length;
                        }
                        if (filtroInicio > 0)
                        {
                            filtroInicio--;
                        }
                        parametros = parametros.Replace(parametros.Substring(filtroInicio, filtroFin - filtroInicio), "");
                        i++;
                    }
                }

                if (listaFiltrosExtra.Count > 0)
                {
                    //Agregamos los filtros extra
                    foreach (string filtro in listaFiltrosExtra)
                    {
                        if (parametros.StartsWith("&&"))
                        {
                            parametros = filtro + parametros;
                        }
                        else
                        {
                            parametros = filtro + "&" + parametros;
                        }
                    }
                }
            }
            else
            {
                if (parametros.Contains(pComponente.AtributoDeBusqueda + "="))
                {
                    int filtroInicio = parametros.IndexOf(pComponente.AtributoDeBusqueda + "=");
                    int filtroFin = parametros.IndexOf("&", filtroInicio + 1);
                    if (filtroFin == -1)
                    {
                        filtroFin = parametros.Length;
                    }
                    string filtroActual = parametros.Substring(filtroInicio, filtroFin - filtroInicio);
                    if (filtroActual.Contains("=<>"))
                    {
                        pFiltro = filtroActual.Substring(filtroActual.IndexOf("=<>") + 3);
                    }
                    else
                    {
                        pFiltro = filtroActual.Substring(filtroActual.IndexOf("=") + 1);
                    }
                }
            }

            parametros = parametros.Replace("&", "|");



            #endregion

            ResultadoModel resultadoModel;

            Guid identidadID = UsuarioAD.Invitado;
            bool estaEnProyecto = false;
            if (pComponente.TipoCaducidadComponenteCMS == TipoCaducidadComponenteCMS.NoCache)
            {
                identidadID = IdentidadID;
                estaEnProyecto = !EsIdentidadInvitada;
            }

            Stopwatch sw = null;

            try
            {
                bool obtenerDatosExtraRecursos = false;
                bool obtenerIdentidades = false;
                bool obtenerDatosExtraIdentidades = false;
                ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                sw = LoggingService.IniciarRelojTelemetria();
                resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, estaEnProyecto, false, identidadID, parametros, false, pIdioma, tipoBusqueda.Key, pComponente.NumeroItems, urlBusqueda, mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultados", false, "ObtenerFichaBuscador", sw, true);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente Buscador con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente Buscador con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaBuscador", sw, false);
                resultadoModel = new ResultadoModel();
                resultadoModel.ListaResultados = new List<ObjetoBuscadorModel>();
                resultadoModel.NumeroPaginaActual = pPagina;
                resultadoModel.NumeroResultadosPagina = pComponente.NumeroItems;
                resultadoModel.NumeroResultadosTotal = 0;
                resultadoModel.UrlBusqueda = "";
            }


            CMSComponentSearch fichaComponentebuscador = new CMSComponentSearch();
            fichaComponentebuscador.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponentebuscador.Key = pComponente.Clave;
            fichaComponentebuscador.Styles = pComponente.Estilos;
            fichaComponentebuscador.Resultado = resultadoModel;
            fichaComponentebuscador.Filter = pFiltro;
            fichaComponentebuscador.AttributeSearchTittle = UtilCadenas.ObtenerTextoDeIdioma(pComponente.TituloAtributoDeBusqueda, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);

            fichaComponentebuscador.UrlSearcherCMS = mControlador.BaseURLIdioma;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (mControlador.ProyectoSeleccionado.Clave != ProyectoAD.MetaProyecto)
            {
                fichaComponentebuscador.UrlSearcherCMS = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
            }
            fichaComponentebuscador.UrlSearcherCMS += "/CMSPagina/searcher-cms";

            return fichaComponentebuscador;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de actividadReciente
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentRecentActivity ObtenerFichaActividadReciente(CMSComponenteActividadReciente pComponente, string pIdioma, int pPagina)
        {
            CMSComponentRecentActivity fichaComponenteActividadReciente = new CMSComponentRecentActivity();
            ActividadReciente actividadReciente = new ActividadReciente(mLoggingService, mEntityContext, mConfigService, mHttpContextAccessor, mRedisCacheWrapper, mVirtuosoAD, mGnossCache, mEntityContextBASE, mViewEngine);
            fichaComponenteActividadReciente.RecentActivity = actividadReciente.ObtenerActividadReciente(pPagina, pComponente.NumeroItems, pComponente.TipoActividadReciente, null, false, pComponente.Clave);
            fichaComponenteActividadReciente.RecentActivity.ComponentKey = pComponente.Clave;
            fichaComponenteActividadReciente.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteActividadReciente.Styles = pComponente.Estilos;

            fichaComponenteActividadReciente.RecentActivity.UrlLoadMoreActivity = mControlador.BaseURLIdioma;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (mControlador.ProyectoSeleccionado.Clave != ProyectoAD.MetaProyecto)
            {
                fichaComponenteActividadReciente.RecentActivity.UrlLoadMoreActivity = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
            }
            fichaComponenteActividadReciente.RecentActivity.UrlLoadMoreActivity += "/CMSPagina/load-more-activity";

            return fichaComponenteActividadReciente;
        }


        /// <summary>
        /// Obtiene la ficha de un componente de Faceta
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentFacet ObtenerFichaFaceta(CMSComponenteFaceta pComponente, string pFiltro, string pIdioma)
        {
            CargadorFacetas cargadorFacetas = new CargadorFacetas();
            cargadorFacetas.Url = mConfigService.ObtenerUrlServicioFacetas();

            string urlBusqueda = ReemplazarDatosUsuarioActual(pComponente.URLBusqueda);

            #region Obtenemos los parametros de busqueda

            string parametros = urlBusqueda;

            if (parametros.Contains("?"))
            {
                parametros = parametros.Substring(parametros.IndexOf("?") + 1);
            }

            KeyValuePair<TipoBusqueda, Guid> tipoBusqueda = new KeyValuePair<TipoBusqueda, Guid>();
            try
            {
                tipoBusqueda = ObtenerTipoBusqueda(urlBusqueda);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente Faceta con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
            }

            //Comprobamos la pestaña
            string parametrosAdicionales = "";
            foreach (AD.EntityModel.Models.ProyectoDS.ProyectoPestanyaBusqueda filaPestanya in mControlador.ProyectoSeleccionado.GestorProyectos.DataWrapperProyectos.ListaProyectoPestanyaBusqueda)
            {
                if (tipoBusqueda.Value == filaPestanya.ProyectoPestanyaMenu.PestanyaID)
                {
                    parametrosAdicionales = filaPestanya.CampoFiltro;
                }
            }

            if (!string.IsNullOrEmpty(pFiltro))
            {
                string[] filtros = pFiltro.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> listaFiltros = filtros.OfType<string>().ToList();
                foreach (string filtro in listaFiltros)
                {
                    //Eliminamos de parametros los filtros que vengan en filtros extra
                    string clave = filtro.Split('=')[0];
                    string valor = filtro.Split('=')[1];
                    int i = 0;
                    while (parametros.Contains(clave + "=") || i > 100)
                    {
                        int filtroInicio = parametros.IndexOf(clave + "=");
                        int filtroFin = parametros.IndexOf("&", filtroInicio + 1);
                        if (filtroFin == -1)
                        {
                            filtroFin = parametros.Length;
                        }
                        if (filtroInicio > 0)
                        {
                            filtroInicio--;
                        }
                        parametros = parametros.Replace(parametros.Substring(filtroInicio, filtroFin - filtroInicio), "");
                        i++;
                    }
                }

                if (listaFiltros.Count > 0)
                {
                    //Agregamos los filtros extra
                    foreach (string filtro in listaFiltros)
                    {
                        if (parametros.StartsWith("&&"))
                        {
                            parametros = filtro + parametros;
                        }
                        else
                        {
                            parametros = filtro + "&" + parametros;
                        }
                    }
                }

                if (urlBusqueda.Contains("?"))
                {
                    urlBusqueda = urlBusqueda.Substring(0, urlBusqueda.IndexOf("?")) + "?" + parametros;
                }
            }

            parametros = parametros.Replace("&", "|");

            #endregion

            Guid identidadID = UsuarioAD.Invitado;
            bool estaEnProyecto = false;
            if (pComponente.TipoCaducidadComponenteCMS == TipoCaducidadComponenteCMS.NoCache)
            {
                identidadID = IdentidadID;
                estaEnProyecto = !EsIdentidadInvitada;
            }

            Stopwatch sw = null;
            FacetedModel facetadoModel = null;
            try
            {
                sw = LoggingService.IniciarRelojTelemetria();
                facetadoModel = cargadorFacetas.CargarFacetasJson(mControlador.ProyectoSeleccionado.Clave, estaEnProyecto, false, identidadID, parametros, "", false, pIdioma, false, tipoBusqueda.Key, -1, pComponente.Faceta, mControlador.ProyectoSeleccionado.Clave.ToString(), parametrosAdicionales, "", ObtenerUrlBusquedaEnIdiomaActual(urlBusqueda, pIdioma), false);
                mLoggingService.AgregarEntradaDependencia("Llamar al servicio de facetas", false, "ObtenerFichaFaceta", sw, true);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente Faceta con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente Faceta con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaFaceta", sw, false);
            }

            CMSComponentFacet fichaComponenteFaceta = new CMSComponentFacet();
            fichaComponenteFaceta.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteFaceta.Key = pComponente.Clave;
            fichaComponenteFaceta.Styles = pComponente.Estilos;
            if (facetadoModel != null && facetadoModel.FacetList != null && facetadoModel.FacetList.Count > 0)
            {
                fichaComponenteFaceta.FacetModel = facetadoModel.FacetList[0];
            }

            fichaComponenteFaceta.PresentatioType = (CMSComponentFacet.CMSComponentFacetPresentation)(short)pComponente.TipoPresentacionFaceta;

            fichaComponenteFaceta.UrlSearcherCMS = mControlador.BaseURLIdioma;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (mControlador.ProyectoSeleccionado.Clave != ProyectoAD.MetaProyecto)
            {
                fichaComponenteFaceta.UrlSearcherCMS = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
            }
            fichaComponenteFaceta.UrlSearcherCMS += "/CMSPagina/searcher-cms";

            return fichaComponenteFaceta;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de Tesauro
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentThesaurus ObtenerFichaTesauro(CMSComponenteTesauro pComponente, string pIdioma)
        {
            CMSComponentThesaurus fichaComponenteTesauro = new CMSComponentThesaurus();
            fichaComponenteTesauro.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteTesauro.Key = pComponente.Clave;
            fichaComponenteTesauro.Styles = pComponente.Estilos;
            fichaComponenteTesauro.Image = pComponente.TieneImagen;


            TesauroCL tesauroCL = new TesauroCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
            GestionTesauro gestTesauro = new GestionTesauro(tesauroCL.ObtenerTesauroDeProyecto(pComponente.ProyectoID), mLoggingService, mEntityContext);
            CategoriaTesauro catTesauro = gestTesauro.ListaCategoriasTesauro[pComponente.ElementoID];

            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);

            fichaComponenteTesauro.CategoryName = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, utilIdiomasAux.LanguageCode, mControlador.ParametrosGeneralesRow.IdiomaDefecto);

            fichaComponenteTesauro.UrlIndex = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + mControlador.UtilIdiomas.GetText("URLSEM", "INDICE");
            fichaComponenteTesauro.UrlBaseCategories = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasAux.GetText("URLSEM", "CATEGORIA");

            short? maxItems = pComponente.NumeroItemsMostrar;

            fichaComponenteTesauro.Categories = new List<CategoryModel>();
            short i = 0;
            foreach (CategoriaTesauro catHija in catTesauro.Hijos)
            {
                if (maxItems.HasValue && i == maxItems)
                {
                    break;
                }
                CategoryModel categoria = new CategoryModel();
                categoria.Name = catHija.Nombre[pIdioma];
                categoria.LanguageName = catHija.Nombre[pIdioma];
                categoria.Key = catHija.Clave;
                fichaComponenteTesauro.Categories.Add(categoria);
                i++;
            }
            return fichaComponenteTesauro;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de Datos comunidad
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentCommunityInfo ObtenerFichaDatosComunidad(CMSComponenteDatosComunidad pComponente, string pIdioma)
        {
            CMSComponentCommunityInfo fichaComponenteDatosComunidad = new CMSComponentCommunityInfo();
            fichaComponenteDatosComunidad.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteDatosComunidad.Key = pComponente.Clave;
            fichaComponenteDatosComunidad.Styles = pComponente.Estilos;

            FacetaCL facetaCL = new FacetaCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
            FacetadoCN facCN = new FacetadoCN(mControlador.UrlIntragnoss, mControlador.ProyectoSeleccionado.Clave.ToString(), mEntityContext, mLoggingService, mConfigService, mVirtuosoAD);
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            fichaComponenteDatosComunidad.ResourcesUrl = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasAux.GetText("URLSEM", "RECURSOS");
            fichaComponenteDatosComunidad.IdentitiesUrl = UrlsSemanticas.ObtenerURLComunidad(mControlador.UtilIdiomas, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasAux.GetText("URLSEM", "PERSONASYORGANIZACIONES");

            NumeroRecursosYPersonasYOrganizacoinesComunidad(fichaComponenteDatosComunidad, pComponente.ContarPersonasNoVisibles);

            facetaCL.Dispose();
            facCN.Dispose();

            return fichaComponenteDatosComunidad;
        }

        private void NumeroRecursosYPersonasYOrganizacoinesComunidad(CMSComponentCommunityInfo pFichaComponenteDatosComunidad, bool pContarPersonasNoVisibles)
        {
            ProyectoCL proyCL = new ProyectoCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService, mVirtuosoAD);

            bool esMovil = RequestParams("esMovil") == "true";

            int? numRecursos = proyCL.ObtenerContadorRecursosComunidad(mControlador.UrlIntragnoss, mControlador.ProyectoVirtual.FilaProyecto.ProyectoID, mControlador.ProyectoVirtual.FilaProyecto.OrganizacionID, mControlador.ProyectoVirtual.TipoProyecto, esMovil);

            if (numRecursos.HasValue)
            {
                pFichaComponenteDatosComunidad.ResourcesCount = numRecursos.Value;
            }

            int? numPersonasYOrganizaciones = proyCL.ObtenerContadorPersonasYOrganizacionesComunidad(mControlador.UrlIntragnoss, mControlador.ProyectoVirtual.FilaProyecto.ProyectoID, mControlador.ProyectoVirtual.TipoProyecto, pContarPersonasNoVisibles);

            if (numPersonasYOrganizaciones.HasValue)
            {
                pFichaComponenteDatosComunidad.IdentitiesCount = numPersonasYOrganizaciones.Value;
            }
            proyCL.Dispose();
        }

        /// <summary>
        /// Obtiene la ficha de un componente de Usuarios Recomendados
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentRecommendedUsers ObtenerFichaUsuariosRecomendados(CMSComponenteUsuariosRecomendados pComponente, string pIdioma)
        {
            CMSComponentRecommendedUsers fichaComponenteUsuariosRecomendados = new CMSComponentRecommendedUsers();
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (string.IsNullOrEmpty(pComponente.Titulo))
            {
                fichaComponenteUsuariosRecomendados.Title = utilIdiomasAux.GetText("COMADMINCMS", "PERSONASQUEDEBERIASCONOCER");
            }
            else
            {
                fichaComponenteUsuariosRecomendados.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            }

            fichaComponenteUsuariosRecomendados.Key = pComponente.Clave;
            fichaComponenteUsuariosRecomendados.Styles = pComponente.Estilos;

            UsuariosRecomendadosController usuariosRecomendadosController = new UsuariosRecomendadosController(mControlador, IdentidadActual, mEntityContext, mLoggingService, mConfigService, mRedisCacheWrapper, mVirtuosoAD, mHttpContextAccessor, mGnossCache);
            fichaComponenteUsuariosRecomendados.RecomendedUsers = usuariosRecomendadosController.ObtenerUsuariosRecomendados(pComponente.NumeroItems);

            return fichaComponenteUsuariosRecomendados;
        }

        /// <summary>  
        /// Obtiene la ficha de un componente de Caja buscador
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentSearchBox ObtenerFichaCajaBuscador(CMSComponenteCajaBuscador pComponente, string pIdioma)
        {
            CMSComponentSearchBox fichaComponenteCajaBuscador = new CMSComponentSearchBox();
            fichaComponenteCajaBuscador.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteCajaBuscador.Key = pComponente.Clave;
            fichaComponenteCajaBuscador.Styles = pComponente.Estilos;
            fichaComponenteCajaBuscador.DefaultText = UtilCadenas.ObtenerTextoDeIdioma(pComponente.TextoDefecto, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteCajaBuscador.AutocompleteID = Guid.Empty;
            try
            {
                fichaComponenteCajaBuscador.AutocompleteID = ObtenerTipoBusqueda(ReemplazarDatosUsuarioActual(pComponente.URLBusqueda)).Value;
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente CajaBuscador con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
            }
            return fichaComponenteCajaBuscador;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de listado de recursos dinámico
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentSearch ObtenerFichaBuscadorSPARQL(CMSComponenteBuscadorSPARQL pComponente, string pIdioma, int pPagina, string pFiltros)
        {
            string querySPARQL = pComponente.QuerySPARQL;

            querySPARQL = ReemplazarParametrosConsultaConfigurables(querySPARQL, pIdioma, pFiltros);

            CMSComponentSearch fichaComponenteListadoRecursos = new CMSComponentSearch();
            fichaComponenteListadoRecursos.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListadoRecursos.Key = pComponente.Clave;
            fichaComponenteListadoRecursos.Styles = pComponente.Estilos;
            Guid identidadID = UsuarioAD.Invitado;
            bool estaEnProyecto = false;
            if (pComponente.TipoCaducidadComponenteCMS == TipoCaducidadComponenteCMS.NoCache)
            {
                identidadID = IdentidadID;
                estaEnProyecto = !EsIdentidadInvitada;
            }

            CargadorResultados cargadorResultados = new CargadorResultados();

            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();
            Stopwatch sw = null;

            try
            {
                bool obtenerDatosExtraRecursos = false;
                bool obtenerIdentidades = false;
                bool obtenerDatosExtraIdentidades = false;
                ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                sw = LoggingService.IniciarRelojTelemetria();
                fichaComponenteListadoRecursos.Resultado = cargadorResultados.CargarResultadosGadgetSPARQL(System.Uri.EscapeDataString(querySPARQL), mControlador.ProyectoSeleccionado.Clave, pComponente.NumeroItems, pPagina, pIdioma, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultado", false, "ObtenerFichaBuscadorSPARQL", sw, true);
            }
            catch (Exception ex)
            {
                mLoggingService.GuardarLogError(ex, "Error producido en el componente BuscadorSPARQL con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                mLoggingService.AgregarEntradaDependencia($"Error producido en el componente BuscadorSPARQL con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "ObtenerFichaBuscadorSPARQL", sw, false);

                fichaComponenteListadoRecursos.Resultado = new ResultadoModel();
                fichaComponenteListadoRecursos.Resultado.ListaResultados = new List<ObjetoBuscadorModel>();
                fichaComponenteListadoRecursos.Resultado.NumeroPaginaActual = pPagina;
                fichaComponenteListadoRecursos.Resultado.NumeroResultadosPagina = pComponente.NumeroItems;
                fichaComponenteListadoRecursos.Resultado.NumeroResultadosTotal = 0;
                fichaComponenteListadoRecursos.Resultado.UrlBusqueda = "";
            }

            fichaComponenteListadoRecursos.UrlSearcherCMS = mControlador.BaseURLIdioma;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            if (mControlador.ProyectoSeleccionado.Clave != ProyectoAD.MetaProyecto)
            {
                fichaComponenteListadoRecursos.UrlSearcherCMS = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
            }
            fichaComponenteListadoRecursos.UrlSearcherCMS += "/CMSPagina/searcher-cms";

            return fichaComponenteListadoRecursos;
        }


        /// <summary>
        /// Obtiene la ficha de un componente de lFichaDescripcionDocumento
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentResourceDescription ObtenerFichaFichaDescripcionDocumento(CMSComponenteFichaDescripcionDocumento pComponente, string pIdioma)
        {
            DocumentacionCN docCN = new DocumentacionCN(mEntityContext, mLoggingService, mConfigService);
            GestorDocumental gestorDoc = new GestorDocumental(docCN.ObtenerDocumentoPorID(pComponente.DocumentoID), mLoggingService, mEntityContext);
            docCN.Dispose();
            Documento documento = gestorDoc.ListaDocumentos[pComponente.DocumentoID];

            CMSComponentResourceDescription fichaComponenteFichaDescripcionDocumento = new CMSComponentResourceDescription();
            fichaComponenteFichaDescripcionDocumento.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteFichaDescripcionDocumento.Key = pComponente.Clave;
            fichaComponenteFichaDescripcionDocumento.Styles = pComponente.Estilos;
            UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
            fichaComponenteFichaDescripcionDocumento.SemanticResourceModel = SemCmsController.ObtenerControladorSemCMS(documento, mControlador.ProyectoSeleccionado, IdentidadActual, mControlador.BaseURLFormulariosSem, utilIdiomasAux, mControlador.BaseURL, mControlador.BaseURLIdioma, mControlador.BaseURLContent, mControlador.BaseURLStatic, mControlador.UrlIntragnoss, false, null, null).SemanticResourceModel;

            return fichaComponenteFichaDescripcionDocumento;
        }

        private SemCmsController mSemCmsController;
        private SemCmsController SemCmsController
        {
            get
            {
                if (mSemCmsController == null)
                    mSemCmsController = new SemCmsController(new SemanticResourceModel(), null, Guid.Empty, null, ProyectoSeleccionado, IdentidadActual, UtilIdiomas, BaseURL, BaseURLIdioma, BaseURLContent, BaseURL, UrlIntragnoss, mLoggingService, mEntityContext, mConfigService, mHttpContextAccessor, mRedisCacheWrapper, mGnossCache, mVirtuosoAD, mEntityContextBASE);

                return mSemCmsController;
            }
        }



        /// <summary>
        /// Obtiene la ficha de un componente de ResumenPerfil
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentProfileSummary ObtenerFichaResumenPerfil(CMSComponenteResumenPerfil pComponente, string pIdioma)
        {
            CMSComponentProfileSummary fichaComponenteResumenPerfil = null;
            if (!EsUsuarioInvitado)
            {
                IdentidadCN identidadCN = new IdentidadCN(mEntityContext, mLoggingService, mConfigService);
                int numRecursosEspacioPersonal = identidadCN.ObtenerNumRecursosEnEspacioPersonalPorPerfil(PerfilID);
                int numRecursosComunidades = identidadCN.ObtenerNumRecursosEnComunidadesPorPerfil(PerfilID);
                int numSeguidores = 0;
                GestionIdentidades gestorIdentidadesSeguidores = new GestionIdentidades(identidadCN.ObtenerIdentidadesSusucritasAPerfil(PerfilID), mLoggingService, mEntityContext, mConfigService);
                numSeguidores = gestorIdentidadesSeguidores.ListaIdentidades.Count;
                int numSiguiendo = 0;
                GestionIdentidades gestorIdentidadesSiguiendo = new GestionIdentidades(identidadCN.ObtenerIdentidadesSusucritasPorPerfil(PerfilID), mLoggingService, mEntityContext, mConfigService);
                numSiguiendo = gestorIdentidadesSiguiendo.ListaIdentidades.Count;

                UtilIdiomas utilIdiomasAux = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);

                fichaComponenteResumenPerfil = new CMSComponentProfileSummary();
                fichaComponenteResumenPerfil.ProfileUrl = UrlsSemanticas.ObtenerUrlMiPerfil(mControlador.BaseURL, utilIdiomasAux, "", mControlador.UrlPerfil);
                fichaComponenteResumenPerfil.ProfileName = IdentidadActual.Nombre();
                fichaComponenteResumenPerfil.ProfileUrlImage = mControlador.BaseURLContent + "/" + UtilArchivos.ContentImagenes + IdentidadActual.UrlImagenGrande; ;
                fichaComponenteResumenPerfil.ProfileFollowersUrl = UrlsSemanticas.ObtenerUrlMiPerfil(mControlador.BaseURL, utilIdiomasAux, "", mControlador.UrlPerfil) + "?seguidores";
                fichaComponenteResumenPerfil.ProfileFollowersNumber = numSeguidores;
                fichaComponenteResumenPerfil.ProfileFollowingUrl = UrlsSemanticas.ObtenerUrlMiPerfil(mControlador.BaseURL, utilIdiomasAux, "", mControlador.UrlPerfil) + "?sigue-a";
                fichaComponenteResumenPerfil.ProfileFollowingNumber = numSiguiendo;
                fichaComponenteResumenPerfil.ProfilePersonalResourcesUrl = mControlador.BaseURLIdioma + mControlador.UrlPerfil + utilIdiomasAux.GetText("URLSEM", "MISRECURSOS");
                fichaComponenteResumenPerfil.ProfilePersonalResourcesNumber = numRecursosEspacioPersonal;
                fichaComponenteResumenPerfil.ProfileCommunityResourcesUrl = mControlador.BaseURLIdioma + mControlador.UrlPerfil + utilIdiomasAux.GetText("URLSEM", "MISCONTRIBUCIONES");
                fichaComponenteResumenPerfil.ProfileCommunityResourcesNumber = numRecursosComunidades;

                fichaComponenteResumenPerfil.Key = pComponente.Clave;
                fichaComponenteResumenPerfil.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                fichaComponenteResumenPerfil.Styles = pComponente.Estilos;
            }
            return fichaComponenteResumenPerfil;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de MasVistos
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentMoreView ObtenerFichaMasVistos(CMSComponenteMasVistos pComponente, string pIdioma)
        {
            CMSComponentMoreView fichaComponenteMasVistos = new CMSComponentMoreView();
            fichaComponenteMasVistos.Key = pComponente.Clave;
            fichaComponenteMasVistos.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteMasVistos.Styles = pComponente.Estilos;
            fichaComponenteMasVistos.MoreVisitedWeek = new List<ResourceModel>();
            fichaComponenteMasVistos.MoreVisitedMonth = new List<ResourceModel>();
            fichaComponenteMasVistos.MoreVisited = new List<ResourceModel>();
            //TODO CORE-2945
            BaseVisitasCN baseVisitasCN = new BaseVisitasCN("base", mEntityContext, mLoggingService, mConfigService);
            //Pedimos el doble de elementos por si alguno esta eliminado o es privado
            List<Guid> listaMasVisitadosSemana = baseVisitasCN.ObtenerRecursosMasVisistadosProyecto(mControlador.ProyectoSeleccionado.Clave, 7, (pComponente.NumeroItems * 2));
            List<Guid> listaMasVisitadosMes = baseVisitasCN.ObtenerRecursosMasVisistadosProyecto(mControlador.ProyectoSeleccionado.Clave, 30, (pComponente.NumeroItems * 2));
            baseVisitasCN.Dispose();

            DocumentacionCN documentacionCN = new DocumentacionCN(mEntityContext, mLoggingService, mConfigService);
            List<Guid> listaMasVisitados = documentacionCN.ObtenerDocumentosMasVistosProyecto(mControlador.ProyectoSeleccionado.Clave, pComponente.NumeroItems);
            documentacionCN.Dispose();

            List<Guid> listaTodosGuids = new List<Guid>();

            string parametros = "listadoRecursosEstatico:";
            foreach (Guid idRecurso in listaMasVisitadosSemana)
            {
                if (!listaTodosGuids.Contains(idRecurso))
                {
                    listaTodosGuids.Add(idRecurso);
                    parametros += "," + idRecurso.ToString();
                }
            }
            foreach (Guid idRecurso in listaMasVisitadosMes)
            {
                if (!listaTodosGuids.Contains(idRecurso))
                {
                    listaTodosGuids.Add(idRecurso);
                    parametros += "," + idRecurso.ToString();
                }
            }
            foreach (Guid idRecurso in listaMasVisitados)
            {
                if (!listaTodosGuids.Contains(idRecurso))
                {
                    listaTodosGuids.Add(idRecurso);
                    parametros += "," + idRecurso.ToString();
                }
            }

            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();

            bool obtenerDatosExtraRecursos = false;
            bool obtenerIdentidades = false;
            bool obtenerDatosExtraIdentidades = false;
            ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
            Stopwatch sw = LoggingService.IniciarRelojTelemetria();
            ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, false, false, UsuarioAD.Invitado, parametros, false, pIdioma, TipoBusqueda.Recursos, listaTodosGuids.Count, "", mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
            mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultado", false, "ObtenerFichaMasVistos", sw, true);
            foreach (ResourceModel fichaRecurso in resultadoModel.ListaResultados)
            {
                if (listaMasVisitadosSemana.Contains(fichaRecurso.Key))
                {
                    fichaComponenteMasVistos.MoreVisitedWeek.Add(fichaRecurso);
                }
                if (listaMasVisitadosMes.Contains(fichaRecurso.Key))
                {
                    fichaComponenteMasVistos.MoreVisitedMonth.Add(fichaRecurso);
                }
                if (listaMasVisitados.Contains(fichaRecurso.Key))
                {
                    fichaComponenteMasVistos.MoreVisited.Add(fichaRecurso);
                }
            }

            return fichaComponenteMasVistos;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de Listado de proyectos
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentCommunityList ObtenerFichaListadoProyectos(CMSComponenteListadoProyectos pComponente, string pIdioma)
        {
            List<Proyecto> mListaProyectos = new List<Proyecto>();
            ProyectoCN proyCN = new ProyectoCN(mEntityContext, mLoggingService, mConfigService);
            switch (pComponente.TipoListadoProyectos)
            {
                case TipoListadoProyectosCMS.RecomendadosProyecto:
                    //Algoritmo de toda la vida
                    ControladorProyecto controladorProyecto = new ControladorProyecto(mLoggingService, mEntityContext, mConfigService, mRedisCacheWrapper, mGnossCache, mEntityContextBASE, mVirtuosoAD, mHttpContextAccessor);
                    List<ElementoGnoss> listaProyectos = controladorProyecto.CargarComunidadesRelacionadasProyecto(mControlador.ProyectoSeleccionado);

                    if (mControlador.ProyectoSeleccionado.TipoAcceso == TipoAcceso.Privado)
                    {
                        List<ElementoGnoss> listaProyectosAux = new List<ElementoGnoss>();
                        listaProyectosAux.AddRange(listaProyectos);

                        //Elimino comunidades reservadas:
                        foreach (ElementoGnoss proyecto in listaProyectosAux)
                        {
                            if (((Proyecto)proyecto).TipoAcceso == TipoAcceso.Reservado)
                            {
                                listaProyectos.Remove(proyecto);
                            }
                        }
                    }
                    foreach (Proyecto proyecto in listaProyectos)
                    {
                        mListaProyectos.Add(proyecto);
                    }
                    break;
                case TipoListadoProyectosCMS.Estaticos:
                    //Los ID que están cargados
                    GestionProyecto gestorProyEstaticos = new GestionProyecto(proyCN.ObtenerProyectosPorIDsCargaLigera(pComponente.ListaGuids), mLoggingService, mEntityContext);

                    foreach (Guid proyectoID in pComponente.ListaGuids)
                    {
                        if (gestorProyEstaticos.ListaProyectos.ContainsKey(proyectoID))
                        {
                            mListaProyectos.Add(gestorProyEstaticos.ListaProyectos[proyectoID]);
                        }
                    }
                    break;
                case TipoListadoProyectosCMS.RecomendadosUsuario:
                    //Recomendaciones personalizadas (comunidades ordenadas por popularidad de las que no soy miembro)
                    GestionProyecto gestorProyUsuario = new GestionProyecto(proyCN.ObtenerProyectosRecomendadosPorPersona(IdentidadActual.PersonaID.Value, pComponente.NumeroItems), mLoggingService, mEntityContext);

                    foreach (Proyecto proyecto in gestorProyUsuario.ListaProyectos.Values)
                    {
                        mListaProyectos.Add(proyecto);
                    }
                    break;
            }
            proyCN.Dispose();

            CMSComponentCommunityList fichaComponenteListaProyectos = new CMSComponentCommunityList();
            fichaComponenteListaProyectos.Key = pComponente.Clave;
            fichaComponenteListaProyectos.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListaProyectos.Styles = pComponente.Estilos;

            fichaComponenteListaProyectos.Communities = new List<CommunityModel>();

            foreach (Proyecto proy in mListaProyectos)
            {
                CommunityModel comunidad = new CommunityModel();
                comunidad.Name = proy.Nombre;
                comunidad.Description = UtilCadenas.ObtenerTextoDeIdioma(proy.FilaProyecto.Descripcion, mControlador.UtilIdiomas.LanguageCode, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                comunidad.ShortName = proy.NombreCorto;
                comunidad.Url = UrlsSemanticas.ObtenerURLComunidad(mControlador.UtilIdiomas, mControlador.BaseURLIdioma, proy.NombreCorto);

                string nombreImagenePeque = new ControladorProyecto(mLoggingService, mEntityContext, mConfigService, mRedisCacheWrapper, mGnossCache, mEntityContextBASE, mVirtuosoAD, mHttpContextAccessor).ObtenerFilaParametrosGeneralesDeProyecto(proy.Clave).NombreImagenPeque;
                string urlFoto = mControlador.BaseURLContent + "/" + UtilArchivos.ContentImagenes + "/" + UtilArchivos.ContentImagenesProyectos + "/" + nombreImagenePeque;
                if (nombreImagenePeque == "peque")
                {
                    urlFoto = mControlador.BaseURLStatic + "/img" + "/" + UtilArchivos.ContentImgIconos + "/" + UtilArchivos.ContentImagenesProyectos + "/" + "anonimo_peque.png";
                }
                comunidad.Logo = urlFoto;

                fichaComponenteListaProyectos.Communities.Add(comunidad);
            }

            return fichaComponenteListaProyectos;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de Listado de usuarios
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentUserList ObtenerFichaListadoUsuarios(CMSComponenteListadoUsuarios pComponente, string pIdioma)
        {
            CMSComponentUserList fichaComponenteListaUsuarios = new CMSComponentUserList();
            fichaComponenteListaUsuarios.Key = pComponente.Clave;
            fichaComponenteListaUsuarios.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteListaUsuarios.Styles = pComponente.Estilos;

            fichaComponenteListaUsuarios.Users = new List<ProfileModel>();

            IdentidadCN identidadCN = new IdentidadCN(mEntityContext, mLoggingService, mConfigService);
            GestionIdentidades gestorIdentidades = new GestionIdentidades(identidadCN.ObtenerIdentidadesDeProyectoParaMosaicoIdentidades(mControlador.ProyectoSeleccionado.Clave, pComponente.NumeroItems, pComponente.TipoListadoUsuarios), mLoggingService, mEntityContext, mConfigService);
            Dictionary<Identidad, int> listaIdentidades = new Dictionary<Identidad, int>();
            foreach (Identidad identidad in gestorIdentidades.ListaIdentidades.Values)
            {
                ProfileModel perfilContacta = new ProfileModel();
                perfilContacta.NamePerson = identidad.NombreCompuesto();

                if (!identidad.UrlImagen.ToLower().Contains("personas/anonimo") && !identidad.UrlImagen.ToLower().Contains("organizaciones/anonimo"))
                {
                    perfilContacta.UrlFoto = UtilArchivos.ContentImagenes + identidad.UrlImagen;
                }

                perfilContacta.UrlPerson = UrlsSemanticas.GetURLPerfilDeIdentidad(mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto, mControlador.UtilIdiomas, identidad);
                perfilContacta.ListActions = new ProfileModel.UrlActions();
                perfilContacta.ListActions.UrlFollow = perfilContacta.UrlPerson.TrimEnd('/') + "/follow";

                fichaComponenteListaUsuarios.Users.Add(perfilContacta);
            }

            return fichaComponenteListaUsuarios;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de MasVistosEnXDias
        /// </summary>
        /// <param name="pComponente"></param>
        /// <param name="pIdioma"></param>
        /// <returns></returns>
        public CMSComponentResourceList ObtenerFichaMasVistosEnXDias(CMSComponenteMasVistosEnXDias pComponente, string pIdioma)
        {
            CMSComponentResourceList fichaComponenteMasVistos = new CMSComponentResourceList();
            fichaComponenteMasVistos.Key = pComponente.Clave;
            fichaComponenteMasVistos.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteMasVistos.Styles = pComponente.Estilos;
            //TODO CORE-2945
            BaseVisitasCN baseVisitasCN = new BaseVisitasCN("base", mEntityContext, mLoggingService, mConfigService);
            //Pedimos el doble de elementos por si alguno esta eliminado o es privado
            List<Guid> listaMasVisitados = baseVisitasCN.ObtenerRecursosMasVisistadosProyecto(mControlador.ProyectoSeleccionado.Clave, pComponente.NumeroDias, (pComponente.NumeroItems * 2));
            baseVisitasCN.Dispose();


            string parametros = "listadoRecursosEstatico:";
            foreach (Guid idRecurso in listaMasVisitados)
            {
                parametros += "," + idRecurso.ToString();
            }

            CargadorResultados cargadorResultados = new CargadorResultados();
            cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();

            bool obtenerDatosExtraRecursos = false;
            bool obtenerIdentidades = false;
            bool obtenerDatosExtraIdentidades = false;
            ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
            Stopwatch sw = LoggingService.IniciarRelojTelemetria();
            ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, false, false, UsuarioAD.Invitado, parametros, false, pIdioma, TipoBusqueda.Recursos, listaMasVisitados.Count, "", mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
            mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultado", false, "ObtenerFichaMasVistosEnXDias", sw, true);
            foreach (ResourceModel fichaRecurso in resultadoModel.ListaResultados)
            {
                if (listaMasVisitados.Contains(fichaRecurso.Key))
                {
                    fichaComponenteMasVistos.ResourceList.Add(fichaRecurso);
                }
            }

            return fichaComponenteMasVistos;
        }


        /// <summary>
        /// Obtiene la ficha de un componente de listado de UltimosRecursosVisitados
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentResourceList ObtenerFichaUltimosRecursosVisitados(CMSComponenteUltimosRecursosVisitados pComponente, string pIdioma)
        {

            BaseComunidadCN baseComunidadCN = new BaseComunidadCN("base", mEntityContext, mLoggingService, mEntityContextBASE, mConfigService);
            List<Guid> listaRecursos = baseComunidadCN.ObtenerUltimosRecursosVisitadosDeProyecto(mControlador.ProyectoSeleccionado.Clave);
            baseComunidadCN.Dispose();


            List<string> BaseURLsContent = new List<string>();
            BaseURLsContent.Add(mControlador.BaseURLContent);

            CMSComponentResourceList fichaComponenteListadoRecursos = null;
            if (listaRecursos != null && listaRecursos.Count > 0)
            {
                fichaComponenteListadoRecursos = new CMSComponentResourceList();
                fichaComponenteListadoRecursos.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                fichaComponenteListadoRecursos.Key = pComponente.Clave;
                fichaComponenteListadoRecursos.Styles = pComponente.Estilos;
                fichaComponenteListadoRecursos.ResourceList = new List<ResourceModel>();
                CargadorResultados cargadorResultados = new CargadorResultados();
                cargadorResultados.Url = mConfigService.ObtenerUrlServicioResultados();
                Stopwatch sw = null;
                try
                {
                    string parametros = "listadoRecursosEstatico:";

                    List<Guid> documentosVistosPorElUsuario = new List<Guid>();
                    if (mHttpContextAccessor.HttpContext.Session.Keys.Contains("DocumentoVisto"))
                    {
                        documentosVistosPorElUsuario = mHttpContextAccessor.HttpContext.Session.Get<List<Guid>>("DocumentoVisto");
                    }

                    //Cargamos los recursos omitiendo los que ya ha visitado el usuario
                    short i = 0;
                    foreach (Guid idRecurso in listaRecursos)
                    {
                        if (!documentosVistosPorElUsuario.Contains(idRecurso))
                        {
                            i++;
                            parametros += "," + idRecurso.ToString();
                            if (i == pComponente.NumeroItems)
                            {
                                break;
                            }
                        }
                    }

                    //Si no llega al número que hay que mostrar lo rellenamos con recursos aunque el usuario los haya visitado
                    if (i < pComponente.NumeroItems && listaRecursos.Count > i)
                    {
                        foreach (Guid idRecurso in listaRecursos)
                        {
                            if (!parametros.Contains(idRecurso.ToString()))
                            {
                                i++;
                                parametros += "," + idRecurso.ToString();
                                if (i >= pComponente.NumeroItems)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    bool obtenerDatosExtraRecursos = false;
                    bool obtenerIdentidades = false;
                    bool obtenerDatosExtraIdentidades = false;
                    ObtenerDatoExtraRecursosComponente(pComponente, ref obtenerDatosExtraRecursos, ref obtenerIdentidades, ref obtenerDatosExtraIdentidades);
                    sw = LoggingService.IniciarRelojTelemetria();
                    ResultadoModel resultadoModel = cargadorResultados.CargarResultadosGadgetJSON(mControlador.ProyectoSeleccionado.Clave, false, false, UsuarioAD.Invitado, parametros, false, pIdioma, TipoBusqueda.Recursos, listaRecursos.Count, "", mRefrescar, obtenerDatosExtraRecursos, obtenerIdentidades, obtenerDatosExtraIdentidades);
                    mLoggingService.AgregarEntradaDependencia("Llamar al servicio de resultado", false, "UltimosRecursosVisitados", sw, true);
                    foreach (ResourceModel fichaRecurso in resultadoModel.ListaResultados)
                    {
                        fichaComponenteListadoRecursos.ResourceList.Add(fichaRecurso);
                    }
                }
                catch (Exception ex)
                {
                    mLoggingService.GuardarLogError(ex, "Error producido en el componente UltimosRecursosVisitados con ID='" + pComponente.Clave.ToString() + "' en la comunidad " + mControlador.ProyectoSeleccionado.Nombre + " \n ");
                    mLoggingService.AgregarEntradaDependencia($"Error producido en el componente UltimosRecursosVisitados con ID '{pComponente.Clave.ToString()}' en la comunidad '{mControlador.ProyectoSeleccionado.Nombre}'", false, "UltimosRecursosVisitados", sw, false);
                }
            }

            return fichaComponenteListadoRecursos;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de consulta SPARQL
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentQuerySPARQL ObtenerFichaConsultaSPARQL(CMSComponenteConsultaSPARQL pComponente, string pIdioma)
        {
            string querySPARQL = ReemplazarDatosUsuarioActual(pComponente.QuerySPARQL, false);

            string pFiltros = "";
            if (RequestParams("filtro") != null)
            {
                pFiltros = RequestParams("filtro");
            }
            querySPARQL = ReemplazarParametrosConsultaConfigurables(querySPARQL, pIdioma, pFiltros);


            bool usarMaster = false;
            if (querySPARQL.StartsWith("#USARMASTER"))
            {
                querySPARQL = querySPARQL.Replace("#USARMASTER", "");
                usarMaster = true;
            }

            querySPARQL = ReemplazarParametrosConsulta(querySPARQL);

            CMSComponentQuerySPARQL fichaComponenteConsultaSPARQL = new CMSComponentQuerySPARQL();
            fichaComponenteConsultaSPARQL.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteConsultaSPARQL.Key = pComponente.Clave;
            fichaComponenteConsultaSPARQL.Styles = pComponente.Estilos;

            FacetadoCN facCN = new FacetadoCN(mControlador.UrlIntragnoss, mEntityContext, mLoggingService, mConfigService, mVirtuosoAD);

            fichaComponenteConsultaSPARQL.DataSetResult = new DataSet();
            FacetadoDS facetadoDS = facCN.RealizarConsultaAVirtuoso(mControlador.ProyectoSeleccionado.Clave.ToString().ToLower(), querySPARQL);
            if (facetadoDS != null && facetadoDS.Tables.Count > 0)
            {
                fichaComponenteConsultaSPARQL.DataSetResult.Tables.Add(facetadoDS.Tables[0].Copy());
            }
            facetadoDS.Dispose();
            facCN.Dispose();

            return fichaComponenteConsultaSPARQL;
        }

        /// <summary>
        /// Obtiene la ficha de un componente de consulta SQLSERVER
        /// </summary>
        /// <param name="pComponente"></param>
        /// <returns></returns>
        public CMSComponentQuerySQLSERVER ObtenerFichaConsultaSQLSERVER(CMSComponenteConsultaSQLSERVER pComponente, string pIdioma)
        {
            string querySQLSERVER = ReemplazarDatosUsuarioActual(pComponente.QuerySQLSERVER, false);

            CMSComponentQuerySQLSERVER fichaComponenteConsultaSQLSERVER = new CMSComponentQuerySQLSERVER();
            fichaComponenteConsultaSQLSERVER.Title = UtilCadenas.ObtenerTextoDeIdioma(pComponente.Titulo, pIdioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
            fichaComponenteConsultaSQLSERVER.Key = pComponente.Clave;
            fichaComponenteConsultaSQLSERVER.Styles = pComponente.Estilos;

            CMSCN cmsCN = new CMSCN(mEntityContext, mLoggingService, mConfigService);
            fichaComponenteConsultaSQLSERVER.DataSetResult = cmsCN.ObtenerConsultaComponenteSQLSERVER(querySQLSERVER);
            cmsCN.Dispose();

            return fichaComponenteConsultaSQLSERVER;
        }

        #endregion

        #region Métodos auxiliares

        /// <summary>
        /// Reemplaza en pTexto los datos correspondientes con el usuario actual
        /// </summary>
        /// <param name="pTexto">Texto para reemplazar</param>
        /// <returns>Texto con los remplazos</returns>
        private string ReemplazarDatosUsuarioActual(string pTexto)
        {
            return ReemplazarDatosUsuarioActual(pTexto, true);
        }

        /// <summary>
        /// Reemplaza en pTexto los datos correspondientes con el usuario actual
        /// </summary>
        /// <param name="pTexto">Texto para reemplazar</param>
        /// <returns>Texto con los remplazos</returns>
        private string ReemplazarDatosUsuarioActual(string pTexto, bool pReemplazarInterrogantes)
        {
            Dictionary<string, string> listaClavesReemplazar = new Dictionary<string, string>();
            foreach (string idClave in UtilComponentes.ListaDatosUsuarioActual)
            {
                switch (idClave)
                {
                    case "<USUARIOID>":
                        //<USUARIOID>
                        if (UsuarioID.HasValue)
                        {
                            listaClavesReemplazar.Add("<USUARIOID>", UsuarioID.ToString().ToUpper());
                        }
                        else
                        {
                            listaClavesReemplazar.Add("<USUARIOID>", Guid.Empty.ToString().ToUpper());
                        }
                        break;
                    case "<IDENTIDADID>":
                        //<IDENTIDADID>
                        listaClavesReemplazar.Add("<IDENTIDADID>", IdentidadID.ToString().ToUpper());
                        break;
                    case "<PROYECTOID>":
                        //<PROYECTOID>
                        listaClavesReemplazar.Add("<PROYECTOID>", mControlador.ProyectoSeleccionado.Clave.ToString().ToUpper());
                        break;
                    case "<PROYECTOID_MINUS>":
                        //<PROYECTOID_MINUS>
                        listaClavesReemplazar.Add("<PROYECTOID_MINUS>", mControlador.ProyectoSeleccionado.Clave.ToString().ToLower());
                        break;
                    case "<NOMBRECORTO_PROYECTO>":
                        //<PROYECTOID>
                        listaClavesReemplazar.Add("<NOMBRECORTO_PROYECTO>", mControlador.ProyectoSeleccionado.NombreCorto);
                        break;
                }
            }

            foreach (string clave in listaClavesReemplazar.Keys)
            {
                pTexto = pTexto.Replace(clave, listaClavesReemplazar[clave]);
            }
            if (pReemplazarInterrogantes)
            {
                pTexto = pTexto.Replace("#", "?");
            }
            return pTexto;
        }

        public string ReemplazarParametrosConsulta(string pTexto)
        {
            int indiceParam = pTexto.IndexOf("<param_");

            if (indiceParam >= 0)
            {
                int indiceFinParam = pTexto.IndexOf(">", indiceParam);
                string parametroReemplazar = pTexto.Substring(indiceParam, indiceFinParam - indiceParam + 1);

                string parametro = parametroReemplazar.Replace("<param_", "").Trim('>');

                string valor = RequestParams(parametro);

                pTexto = pTexto.Replace(parametroReemplazar, valor);

                pTexto = ReemplazarParametrosConsulta(pTexto);
            }

            return pTexto;
        }


        private string ReemplazarParametrosConsultaConfigurables(string pQuerySPARQL, string pIdioma, string pFiltros)
        {
            //{GETDATE} //AAAAMMDDhhmmss
            pQuerySPARQL = pQuerySPARQL.Replace("{GETDATE}", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //{GETLANG}
            pQuerySPARQL = pQuerySPARQL.Replace("{GETLANG}", pIdioma);


            //querysparql: {PARAM-INICIO|||and ?o >= INICIO||| } {PARAM-FIN|||and ?o <= FIN||| }
            //filtros: INICIO=XXX|||FIN=XXXX
            string[] filtros = pFiltros.Split(new string[] { "|||" }, StringSplitOptions.None);
            Dictionary<string, string> filtrosDictionary = new Dictionary<string, string>();
            foreach (string filtro in filtros)
            {
                string[] fil = filtro.Split('=');
                if (fil.Length == 2 && !string.IsNullOrEmpty(fil[0]) && !string.IsNullOrEmpty(fil[1]))
                {
                    filtrosDictionary.Add(fil[0], fil[1]);
                }
            }
            while (pQuerySPARQL.Contains("{PARAM-"))
            {
                int inicio = pQuerySPARQL.IndexOf("{PARAM-");
                int fin = 0;

                int numCorchetes = 1;
                for (int i = inicio + 1; i < pQuerySPARQL.Length - 1; i++)
                {
                    if (pQuerySPARQL[i] == '{')
                    {
                        numCorchetes++;
                    }
                    else if (pQuerySPARQL[i] == '}')
                    {
                        numCorchetes--;
                    }
                    if (numCorchetes == 0)
                    {
                        fin = i;
                        break;
                    }

                }

                //int fin = querySPARQL.IndexOf("}", inicio);
                if (inicio > -1 && fin > -1)
                {
                    string cadena = pQuerySPARQL.Substring(inicio, fin - inicio);
                    string[] cadenaArray = cadena.Split(new string[] { "||" }, StringSplitOptions.None);
                    string nombreParam = cadenaArray[0].Replace("{PARAM-", "");
                    string filtroConParam = cadenaArray[1];
                    string filtroSinParam = cadenaArray[2];

                    if (filtrosDictionary.ContainsKey(nombreParam))
                    {
                        filtroConParam = filtroConParam.Replace(nombreParam, filtrosDictionary[nombreParam]);
                        pQuerySPARQL = pQuerySPARQL.Substring(0, inicio) + filtroConParam + pQuerySPARQL.Substring(fin + 1);
                    }
                    else
                    {
                        pQuerySPARQL = pQuerySPARQL.Substring(0, inicio) + filtroSinParam + pQuerySPARQL.Substring(fin + 1);
                    }
                }
            }

            pQuerySPARQL = ReemplazarDatosUsuarioActual(pQuerySPARQL, false);

            return pQuerySPARQL;
        }

        /// <summary>
        /// Obtiene el tipo de búsqueda
        /// </summary>
        public KeyValuePair<TipoBusqueda, Guid> ObtenerTipoBusqueda(string pUrl)
        {
            string idiomaOriginal = IdiomaUsuario;

            try
            {
                if (ProyectoSeleccionado.FilaProyecto.URLPropia.Contains("@"))
                {
                    // El proyecto tiene url con idiomas, comprobamos en qué idioma está la url
                    var urlPorIdiomas = UtilCadenas.ObtenerTextoPorIdiomas(ProyectoSeleccionado.FilaProyecto.URLPropia);
                    idiomaOriginal = urlPorIdiomas.First(url => pUrl.StartsWith(url.Value)).Key;
                }

                Uri uri = new Uri(pUrl);
                pUrl = pUrl.Replace(uri.Scheme + "://" + uri.Host, mControlador.BaseURL);
            }
            catch (Exception)
            {
                throw new Exception("La URL " + pUrl + " no es una URL correcta");
            }
            if (pUrl.Contains(mControlador.BaseURL + "/"))
            {
                string urlRelativa = pUrl.Replace(mControlador.BaseURL + "/", "");

                UtilIdiomas utilIdiomasUrlOriginal = UtilIdiomas;
                if (idiomaOriginal != IdiomaUsuario)
                {
                    utilIdiomasUrlOriginal = new UtilIdiomas(idiomaOriginal, mLoggingService, mEntityContext, mConfigService);
                }
                else if (urlRelativa.Contains("/"))
                {
                    if (urlRelativa.Substring(0, urlRelativa.IndexOf("/")).Length == 2)
                    {
                        idiomaOriginal = urlRelativa.Substring(0, urlRelativa.IndexOf("/"));
                        utilIdiomasUrlOriginal = new UtilIdiomas(idiomaOriginal, mLoggingService, mEntityContext, mConfigService);
                    }
                }
                else
                {
                    utilIdiomasUrlOriginal = new UtilIdiomas(IdiomaPorDefecto, mLoggingService, mEntityContext, mConfigService);
                }

                string pUrlAux = pUrl;
                if (pUrl.Contains("?"))
                {
                    pUrlAux = pUrl.Substring(0, pUrl.IndexOf("?"));
                }

                string urlComunidad = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasUrlOriginal, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
                if (!pUrlAux.ToLower().StartsWith(urlComunidad.ToLower()))
                {
                    throw new Exception($"No es correcta la URL {pUrlAux}, debe comenzar con {urlComunidad}");
                }
                else
                {
                    pUrlAux = pUrlAux.Replace(urlComunidad + "/", "");
                }

                ProyectoPestanyaMenu pestanyaBusqueda = mControlador.ProyectoSeleccionado.ListaPestanyasMenu.Values.FirstOrDefault(p => string.Equals(p.Ruta, pUrlAux, StringComparison.InvariantCultureIgnoreCase));
                if (pestanyaBusqueda != null)
                {
                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Recursos, pestanyaBusqueda.Clave);
                }
                else
                {
                    foreach (Guid idPestanya in mControlador.ProyectoSeleccionado.ListaPestanyasMenu.Keys)
                    {
                        ProyectoPestanyaMenu pestanya = mControlador.ProyectoSeleccionado.ListaPestanyasMenu[idPestanya];
                        string ruta = null;
                        if (!string.IsNullOrEmpty(pestanya.Ruta))
                        {
                            ruta = UtilCadenas.ObtenerTextoDeIdioma(pestanya.Ruta.Trim(), idiomaOriginal, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                        }
                        else
                        {
                            ruta = UtilCadenas.ObtenerTextoDeIdioma(pestanya.Ruta, idiomaOriginal, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                        }

                        switch (pestanya.TipoPestanya)
                        {
                            case TipoPestanyaMenu.BusquedaSemantica:
                                if (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux)
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Recursos, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.Recursos:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "RECURSOS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Recursos, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.Debates:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "DEBATES")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Debates, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.Preguntas:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "PREGUNTAS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Preguntas, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.Encuestas:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "ENCUESTAS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.Encuestas, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.PersonasYOrganizaciones:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "PERSONASYORGANIZACIONES")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.PersonasYOrganizaciones, pestanya.Clave);
                                }
                                break;
                            case TipoPestanyaMenu.BusquedaAvanzada:
                                if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "BUSQUEDAAVANZADA")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                                {
                                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.BusquedaAvanzada, pestanya.Clave);
                                }
                                break;
                        }
                    }
                }
                if (pUrlAux == utilIdiomasUrlOriginal.GetText("URLSEM", "BUSQUEDAAVANZADA"))
                {
                    return new KeyValuePair<TipoBusqueda, Guid>(TipoBusqueda.BusquedaAvanzada, Guid.Empty);
                }
            }

            throw new Exception("La URL " + pUrl + " debe ser una URL de búsqueda de la comunidad");
        }

        /// <summary>
        /// Obtiene el id de la pestanya (Guid.empty si es la busqueda avanzada y null si no la encuentra)
        /// </summary>
        public Guid? ObtenerPestanyaID(string pUrl)
        {
            pUrl = pUrl.Replace("#", "?");
            try
            {
                Uri uri = new Uri(pUrl);
                pUrl = pUrl.Replace(uri.Scheme + "://" + uri.Host, mControlador.BaseURL);
            }
            catch (Exception)
            {
                return null;
            }
            if (pUrl.Contains(mControlador.BaseURL + "/"))
            {
                string pUrlAux = pUrl.Replace(mControlador.BaseURL + "/", "");
                //Comprobación multiIdioma
                string idioma = "es";
                if (pUrlAux.Contains("/"))
                {
                    idioma = pUrlAux.Substring(0, pUrlAux.IndexOf("/"));
                }
                Recursos.UtilIdiomas utilIdiomasAux = new UtilIdiomas(idioma, mLoggingService, mEntityContext, mConfigService);

                if (pUrl.Contains("?"))
                {
                    pUrlAux = pUrl.Substring(0, pUrl.IndexOf("?"));
                }
                else
                {
                    pUrlAux = pUrl;
                }
                string urlComunidad = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
                if (!pUrlAux.StartsWith(urlComunidad))
                {
                    return null;
                }
                else
                {
                    pUrlAux = pUrlAux.Replace(urlComunidad + "/", "");
                }

                foreach (Guid idPestanya in mControlador.ProyectoSeleccionado.ListaPestanyasMenu.Keys)
                {
                    ProyectoPestanyaMenu pestanya = mControlador.ProyectoSeleccionado.ListaPestanyasMenu[idPestanya];
                    string ruta = UtilCadenas.ObtenerTextoDeIdioma(pestanya.Ruta?.Trim(), idioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                    switch (pestanya.TipoPestanya)
                    {
                        case TipoPestanyaMenu.BusquedaSemantica:
                            if (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux)
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.Recursos:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "RECURSOS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.Debates:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "DEBATES")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.Preguntas:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "PREGUNTAS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.Encuestas:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "ENCUESTAS")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.PersonasYOrganizaciones:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "PERSONASYORGANIZACIONES")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        case TipoPestanyaMenu.BusquedaAvanzada:
                            if ((string.IsNullOrEmpty(ruta) && pUrlAux == utilIdiomasAux.GetText("URLSEM", "BUSQUEDAAVANZADA")) || (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux))
                            {
                                return pestanya.Clave;
                            }
                            break;
                        default:
                            if (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux)
                            {
                                return pestanya.Clave;
                            }
                            break;
                    }
                }
                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "BUSQUEDAAVANZADA"))
                {
                    return Guid.Empty;
                }
            }

            return null;
        }

        private string ObtenerURLPaginaConFiltrosEnIdiomaActual(string pURL, List<CommunityModel.TabModel> pTabs)
        {
            if (pURL == null) { return null; }
            string parametrosBusqueda = "";
            string urlPestanya = pURL;
            if (pURL.Contains("?"))
            {
                parametrosBusqueda = pURL.Substring(pURL.IndexOf("?"));
                urlPestanya = pURL.Substring(0, pURL.IndexOf("?"));
            }
            urlPestanya = ObtenerURLPaginaSinFiltrosEnIdiomaActual(urlPestanya, mComunidad.Tabs);
            return urlPestanya + parametrosBusqueda;
        }

        private string ObtenerURLPaginaSinFiltrosEnIdiomaActual(string pURL, List<CommunityModel.TabModel> pTabs)
        {
            Guid? idPestanya = ObtenerPestanyaID(pURL);
            if (idPestanya.HasValue)
            {
                foreach (CommunityModel.TabModel pestanya in pTabs)
                {
                    if (pestanya.Key == idPestanya)
                    {
                        pURL = pestanya.Url;
                        break;
                    }
                    if (pestanya.SubTab != null && pestanya.SubTab.Count > 0)
                    {
                        pURL = ObtenerURLPaginaSinFiltrosEnIdiomaActual(pURL, pestanya.SubTab);
                    }
                }
            }
            return pURL;
        }

        /// <summary>
        /// Obtiene la URL de una búsqueda en el idioma especificado
        /// </summary>
        private string ObtenerUrlBusquedaEnIdiomaActual(string pUrl, string pIdioma)
        {
            try
            {
                Uri uri = new Uri(pUrl);
                pUrl = pUrl.Replace(uri.Scheme + "://" + uri.Host, mControlador.BaseURL);
            }
            catch (Exception)
            {
                throw new Exception("La URL " + pUrl + " no es una URL correcta");
            }
            if (pUrl.Contains(mControlador.BaseURL + "/"))
            {
                string pUrlAux = pUrl.Replace(mControlador.BaseURL + "/", "");
                //Comprobación multiIdioma
                string idioma = "es";
                if (pUrlAux.Contains("/"))
                {
                    idioma = pUrlAux.Substring(0, pUrlAux.IndexOf("/"));
                }
                UtilIdiomas utilIdiomasAux = new UtilIdiomas(idioma, mLoggingService, mEntityContext, mConfigService);
                UtilIdiomas utilIdiomasActual = new UtilIdiomas(pIdioma, mLoggingService, mEntityContext, mConfigService);
                string urlExtra = "";

                if (pUrl.Contains("?"))
                {
                    urlExtra = "?" + pUrl.Substring(pUrl.IndexOf("?") + 1);
                    pUrlAux = pUrl.Substring(0, pUrl.IndexOf("?"));
                }
                else
                {
                    pUrlAux = pUrl;
                }
                string urlComunidad = UrlsSemanticas.ObtenerURLComunidad(utilIdiomasAux, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto);
                if (!pUrlAux.StartsWith(urlComunidad))
                {
                    throw new Exception("No es correcta la URL");
                }
                else
                {
                    pUrlAux = pUrlAux.Replace(urlComunidad + "/", "");
                }

                foreach (Guid idPestanya in mControlador.ProyectoSeleccionado.ListaPestanyasMenu.Keys)
                {
                    ProyectoPestanyaMenu pestanya = mControlador.ProyectoSeleccionado.ListaPestanyasMenu[idPestanya];
                    string pestanyaRuta = pestanya.Ruta;
                    if (!string.IsNullOrEmpty(pestanyaRuta))
                    {
                        pestanyaRuta = pestanyaRuta.Trim();
                    }
                    string ruta = UtilCadenas.ObtenerTextoDeIdioma(pestanyaRuta, idioma, mControlador.ParametrosGeneralesRow.IdiomaDefecto);
                    string rutaIdiomaActual = UtilCadenas.ObtenerTextoDeIdioma(pestanyaRuta, utilIdiomasActual.LanguageCode, mControlador.ParametrosGeneralesRow.IdiomaDefecto);

                    if (!string.IsNullOrEmpty(ruta) && ruta == pUrlAux)
                    {
                        return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + rutaIdiomaActual + urlExtra;
                    }
                    else if (string.IsNullOrEmpty(ruta))
                    {
                        switch (pestanya.TipoPestanya)
                        {
                            case TipoPestanyaMenu.Recursos:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "RECURSOS"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "RECURSOS") + urlExtra;
                                }
                                break;
                            case TipoPestanyaMenu.Debates:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "DEBATES"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "DEBATES") + urlExtra;
                                }
                                break;
                            case TipoPestanyaMenu.Preguntas:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "PREGUNTAS"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "PREGUNTAS") + urlExtra;
                                }
                                break;
                            case TipoPestanyaMenu.Encuestas:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "ENCUESTAS"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "ENCUESTAS") + urlExtra;
                                }
                                break;
                            case TipoPestanyaMenu.PersonasYOrganizaciones:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "PERSONASYORGANIZACIONES"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "PERSONASYORGANIZACIONES") + urlExtra;
                                }
                                break;
                            case TipoPestanyaMenu.BusquedaAvanzada:
                                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "BUSQUEDAAVANZADA"))
                                {
                                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "BUSQUEDAAVANZADA") + urlExtra;
                                }
                                break;
                        }
                    }
                }

                if (pUrlAux == utilIdiomasAux.GetText("URLSEM", "BUSQUEDAAVANZADA"))
                {
                    return UrlsSemanticas.ObtenerURLComunidad(utilIdiomasActual, mControlador.BaseURLIdioma, mControlador.ProyectoSeleccionado.NombreCorto) + "/" + utilIdiomasActual.GetText("URLSEM", "BUSQUEDAAVANZADA") + urlExtra;
                }
            }

            throw new Exception("La URL " + pUrl + " debe ser una URL de búsqueda de la comunidad");
        }

        #endregion

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene la lista de idiomas del ecosistema
        /// </summary>
        private List<string> ListaIdiomas
        {
            get
            {
                if (mListaIdiomas == null)
                {
                    mListaIdiomas = mConfigService.ObtenerListaIdiomas();
                }
                return mListaIdiomas;
            }
        }

        /// <summary>
        /// Gestor de CMS de la página actual
        /// </summary>
        public GestionCMS GestorCMSActual
        {
            get
            {
                if (mGestorCMSActual == null)
                {
                    if (mTipoUbicacionCMSPaginaActual.HasValue)
                    {
                        if (VistaPrevia)
                        {
                            CMSCN cmsCNPriv = new CMSCN(mEntityContext, mLoggingService, mConfigService);
                            mGestorCMSActual = new GestionCMS(cmsCNPriv.ObtenerCMSDeUbicacionDeProyecto(mTipoUbicacionCMSPaginaActual.Value, ProyectoSeleccionado.Clave, 1, true), mLoggingService, mEntityContext);
                            cmsCNPriv.Dispose();
                        }
                        else
                        {
                            CMSCL cmsCLPriv = new CMSCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
                            mGestorCMSActual = new GestionCMS(cmsCLPriv.ObtenerCMSDeUbicacionDeProyecto(mTipoUbicacionCMSPaginaActual.Value, ProyectoSeleccionado.Clave, true), mLoggingService, mEntityContext);
                            cmsCLPriv.Dispose();
                        }
                    }
                    else if (mComponenteID.HasValue)
                    {
                        CMSCN cms2CN = new CMSCN(mEntityContext, mLoggingService, mConfigService);
                        Guid proyectoID = ProyectoSeleccionado.Clave;
                        if (ProyectoSeleccionado.FilaProyecto.ProyectoSuperiorID.HasValue)
                        {
                            proyectoID = ProyectoSeleccionado.FilaProyecto.ProyectoSuperiorID.Value;
                        }
                        mGestorCMSActual = new GestionCMS(cms2CN.ObtenerComponentePorID(mComponenteID.Value, proyectoID), mLoggingService, mEntityContext);

                        if (!mGestorCMSActual.ListaComponentes.Any())
                        {
                            mGestorCMSActual = new GestionCMS(cms2CN.ObtenerComponentePorID(mComponenteID.Value, ProyectoSeleccionado.Clave), mLoggingService, mEntityContext);
                        }

                        var listaGrupos = mGestorCMSActual.ListaComponentes.Values.Where(item => item is CMSComponenteGrupoComponentes).ToList();
                        foreach (CMSComponente componente in listaGrupos)
                        {
                            CargarGrupoComponentes((CMSComponenteGrupoComponentes)componente);
                            if (componente is CMSComponenteGrupoComponentes)
                            {
                                CMSComponenteGrupoComponentes grupo = (CMSComponenteGrupoComponentes)componente;
                                foreach (Guid idComponente in grupo.ListaGuids)
                                {
                                    mGestorCMSActual.CMSDW.Merge(cms2CN.ObtenerComponentePorID(idComponente, proyectoID));
                                }
                            }
                        }
                        mGestorCMSActual.CargarComponentes();
                        cms2CN.Dispose();
                    }
                }
                return mGestorCMSActual;
            }
        }

        private void CargarGrupoComponentes(CMSComponenteGrupoComponentes pGrupoComponentes)
        {
            CMSCN cmsCN = new CMSCN(mEntityContext, mLoggingService, mConfigService);
            foreach (Guid idComponente in pGrupoComponentes.ListaGuids)
            {
                mGestorCMSActual.CMSDW.Merge(cmsCN.ObtenerComponentePorID(idComponente, ProyectoSeleccionado.Clave));
            }

            mGestorCMSActual.CargarComponentes();

            var listaGrupos = mGestorCMSActual.ListaComponentes.Values.Where(item => item is CMSComponenteGrupoComponentes && pGrupoComponentes.ListaGuids.Contains(item.Clave)).ToList();
            foreach (CMSComponente componente in listaGrupos)
            {
                CargarGrupoComponentes((CMSComponenteGrupoComponentes)componente);
            }
        }

        /// <summary>
        /// Lista de componentes cacheados
        /// </summary>
        public Dictionary<Guid, CMSComponent> ListaComponentesCache
        {
            get
            {
                if (mListaComponentesCache == null)
                {
                    if (mTipoUbicacionCMSPaginaActual.HasValue)
                    {
                        //Si es pagina CMS obtenemos de caché
                        List<Guid> listaComponentes = new List<Guid>();
                        foreach (Guid idComponente in GestorCMSActual.ListaComponentes.Keys)
                        {
                            listaComponentes.Add(idComponente);
                        }

                        CMSCL cms2CL = new CMSCL(mEntityContext, mLoggingService, mRedisCacheWrapper, mConfigService);
                        mListaComponentesCache = cms2CL.ObtenerListaComponentesPorIDEnProyecto(ProyectoSeleccionado.Clave, listaComponentes, IdiomaUsuario);
                        cms2CL.Dispose();
                    }
                    else
                    {
                        //Si es componente CMS no obtenemos nada
                        mListaComponentesCache = new Dictionary<Guid, CMSComponent>();
                    }
                }
                return mListaComponentesCache;
            }
        }

        public DataWrapperVistaVirtual VistaVirtualDW
        {
            get
            {
                if (mVistaVirtualDW == null)
                {
                    VistaVirtualCL vistaVirtualCL = new VistaVirtualCL(mEntityContext, mLoggingService, mGnossCache, mRedisCacheWrapper, mConfigService);
                    mVistaVirtualDW = vistaVirtualCL.ObtenerVistasVirtualPorProyectoID(ProyectoSeleccionado.Clave, PersonalizacionEcosistemaID, ComunidadExcluidaPersonalizacionEcosistema);
                    vistaVirtualCL.Dispose();
                }
                return mVistaVirtualDW;
            }
        }

        public CommunityModel Comunidad
        {
            get
            {
                return mComunidad;
            }
            set
            {
                mComunidad = value;
            }
        }

        public bool VistaPrevia
        {
            get
            {
                return mVistaPrevia;
            }
            set
            {
                mVistaPrevia = value;
            }
        }

        public bool PintarComponente
        {
            get; set;
        }

        public Guid? UsuarioID
        {
            get
            {
                if (mUsuarioID.HasValue)
                {
                    return mUsuarioID.Value;
                }
                else if (UsuarioActual != null)
                {
                    return UsuarioActual.UsuarioID;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                mUsuarioID = value;
            }
        }

        public Guid IdentidadID
        {
            get
            {
                if (mIdentidadID.HasValue)
                {
                    return mIdentidadID.Value;
                }
                else
                {
                    return mControlador.IdentidadActual.Clave;
                }
            }
            set
            {
                mIdentidadID = value;
            }
        }

        public Guid PerfilID
        {
            get
            {
                if (!mPerfilID.HasValue)
                {
                    if (IdentidadID.Equals(UsuarioAD.Invitado))
                    {
                        mPerfilID = IdentidadID;
                    }
                    else
                    {
                        IdentidadCN identCN = new IdentidadCN(mEntityContext, mLoggingService, mConfigService);
                        mPerfilID = identCN.ObtenerPerfilIDDeIdentidadID(IdentidadID);
                    }
                }
                return mPerfilID.Value;
            }
        }

        public bool EsIdentidadInvitada
        {
            get
            {
                if (UsuarioActual != null)
                {
                    return UsuarioActual.EsIdentidadInvitada;
                }
                else
                {
                    return IdentidadID.Equals(UsuarioAD.Invitado);
                }
            }
        }

        public bool EsUsuarioInvitado
        {
            get
            {
                if (UsuarioActual != null)
                {
                    return UsuarioActual.EsUsuarioInvitado;
                }
                else
                {
                    return IdentidadID.Equals(UsuarioAD.Invitado);
                }
            }
        }

        public Identidad IdentidadActual
        {
            get
            {
                if (mControlador.IdentidadActual != null)
                {
                    return mControlador.IdentidadActual;
                }
                else if (mIdentidadActual == null)
                {
                    IdentidadCN identCN = new IdentidadCN(mEntityContext, mLoggingService, mConfigService);
                    if (!EsIdentidadInvitada)
                    {
                        GestionIdentidades gestorIdentidades = new GestionIdentidades(identCN.ObtenerIdentidadesDePerfil(PerfilID), mLoggingService, mEntityContext, mConfigService);
                        mIdentidadActual = gestorIdentidades.ListaIdentidades[IdentidadID];
                    }
                    else
                    {
                        GestionIdentidades gestorIdentidades = new GestionIdentidades(identCN.ObtenerIdentidadInvitado(), mLoggingService, mEntityContext, mConfigService);
                        mIdentidadActual = gestorIdentidades.ListaIdentidades[IdentidadID];
                    }
                }
                return mIdentidadActual;
            }
        }

        /// <summary>
        /// Lista de grupo a los que pertenece la identidad actual
        /// </summary>
        public List<Guid> ListaGruposIdentidadActual
        {
            get
            {
                if (mControlador.ListaGruposIdentidadActual != null)
                {
                    return mControlador.ListaGruposIdentidadActual;
                }
                else if (mListaGruposIdentidadActual == null)
                {
                    mListaGruposIdentidadActual = new List<Guid>();
                    if (IdentidadActual != null && !UsuarioActual.EsIdentidadInvitada)
                    {
                        IdentidadCN identidadCN = new IdentidadCN(mEntityContext, mLoggingService, mConfigService);
                        GestionIdentidades gestorIdentidades = new GestionIdentidades(identidadCN.ObtenerGruposParticipaIdentidad(IdentidadActual.Clave, true), mLoggingService, mEntityContext, mConfigService);
                        if (IdentidadActual.IdentidadMyGNOSS != null && (IdentidadActual.ModoParticipacion == TiposIdentidad.ProfesionalCorporativo || IdentidadActual.ModoParticipacion == TiposIdentidad.ProfesionalPersonal))
                        {
                            gestorIdentidades.DataWrapperIdentidad.Merge(identidadCN.ObtenerGruposParticipaIdentidad(IdentidadActual.IdentidadMyGNOSS.Clave, true));
                        }
                        identidadCN.Dispose();
                        gestorIdentidades.CargarGrupos();

                        foreach (Guid idGrupo in gestorIdentidades.ListaGrupos.Keys)
                        {
                            mListaGruposIdentidadActual.Add(idGrupo);
                        }
                    }
                }
                return mListaGruposIdentidadActual;
            }
        }

        #endregion

    }
}
