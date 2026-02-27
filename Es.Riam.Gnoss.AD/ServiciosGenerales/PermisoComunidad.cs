using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.AD.ServiciosGenerales
{
    public enum PermisoComunidad : ulong
    {
        [Description("DESCPERMISOINFOGENERAL")]
        [Section("COMUNIDAD")]
        GestionarInformacionGeneral = 1,
        [Description("DESCPERMISOFLUJOS")]
        [Section("COMUNIDAD")]
        GestionarFlujos = 2,
        [Description("DESCPERMISOINTERACCIONESSOCIALES")]
        [Section("COMUNIDAD")]
        GestionarInteraccionesSociales = 4,
        [Description("DESCPERMISOMIEMBROS")]
        [Section("COMUNIDAD")]
        GestionarMiembros = 8,
        [Description("DESCPERMISOSOLICITUDESGRUPO")]
        [Section("COMUNIDAD")]
        GestionarSolicitudesDeAccesoAGrupo = 16,
        [Description("DESCPERMISONIVELESCERTIFICACION")]
        [Section("COMUNIDAD")]
        GestionarNivelesDeCertificacion = 32,
        [Description("DESCPERMISOPESOSAUTOCOMPLETAR")]
        [Section("ESTRUCTURA")]
        GestionarPesosAutocompletado = 64,
        [Description("DESCPERMISOREDIRECCIONES")]
        [Section("ESTRUCTURA")]
        GestionarRedirecciones = 128,
        [Description("DESCPERMISOOAUTH")]
        [Section("CONFIGURACION")]
        DescargarConfiguracionOAuth = 256,
        [Description("DESCPERMISOCOOKIES")]
        [Section("CONFIGURACION")]
        GestionarCookies = 512,
        [Description("DESCPERMISOFTP")]
        [Section("CONFIGURACION")]
        AccederAlFTP = 1024,
        [Description("DESCPERMISOTRADUCCIONES")]
        [Section("CONFIGURACION")]
        GestionarTraducciones = 2048,
        [Description("DESCPERMISODATOSEXTRA")]
        [Section("CONFIGURACION")]
        GestionarDatosExtraRegistro = 4096,
        [Description("DESCPERMISOTRAZAS")]
        [Section("CONFIGURACION")]
        GestionarTrazas = 8192,
        [Description("DESCPERMISOCONFIGURACIONES")]
        [Section("CONFIGURACION")]
        GestionarConfiguraciones = 16384,
        [Description("DESCPERMISOCACHE")]
        [Section("CONFIGURACION")]
        GestionarCache = 32768,
        [Description("DESCPERMISOSEO")]
        [Section("CONFIGURACION")]
        AdministrarSEOYGoogleAnalytics = 65536,
        [Description("DESCPERMISOESTADISTICAS")]
        [Section("CONFIGURACION")]
        AccederAEstadisticasDeLaComunidad = 131072,
        [Description("DESCPERMISOCLAUSULAS")]
        [Section("CONFIGURACION")]
        GestionarClausulasDeRegistro = 262144,
        [Description("DESCPERMISOCORREO")]
        [Section("CONFIGURACION")]
        GestionarBuzonDeCorreo = 524288,
        [Description("DESCPERMISOSERVICIOSEXTERNOS")]
        [Section("CONFIGURACION")]
        GestionarServiciosExternos = 1048576,
        [Description("DESCPERMISOESTADOSERVICIOS")]
        [Section("CONFIGURACION")]
        AccederAlEstadoDeLosServicios = 2097152,
        [Description("DESCPERMISOOPCIONESMETA")]
        [Section("CONFIGURACION")]
        GestionarOpcionesDelMetaadministrador = 4194304,
        [Description("DESCPERMISOEVENTOS")]
        [Section("CONFIGURACION")]
        GestionarEventosExternos = 8388608,
        [Description("DESCPERMISOSPARQL")]
        [Section("GRAFO")]
        AccesoSparqlEndpoint = 16777216,
        [Description("DESCPERMISOCARGAMASIVA")]
        [Section("GRAFO")]
        ConsultarCargasMasivas = 33554432,
        [Description("DESCPERMISOBORRADOMASIVO")]
        [Section("GRAFO")]
        EjecutarBorradoMasivo = 67108864,
        [Description("DESCPERMISOSUGERENCIASBUSQUEDA")]
        [Section("GRAFO")]
        GestionarSugerenciasDeBusqueda = 134217728,
        [Description("DESCPERMISOCONTEXTOS")]
        [Section("GRAFO")]
        GestionarInformacionContextual = 268435456,
        [Description("DESCPERMISOSEARCHPERSONALIZADO")]
        [Section("DESCUBRIMIENTO")]
        GestionarParametrosDeBusquedaPersonalizados = 536870912,
        [Description("DESCPERMISOMAPA")]
        [Section("DESCUBRIMIENTO")]
        GestionarMapa = 1073741824,
        [Description("DESCPERMISOGRAFICOS")]
        [Section("DESCUBRIMIENTO")]
        AdministrarGraficos = 2147483648,
        [Description("DESCPERMISOVISTAS")]
        [Section("APARIENCIA")]
        GestionarVistas = 4294967296,
        [Description("DESCPERMISOIC")]
        [Section("IC")]
        GestionarIntegracionContinua = 8589934592,
        [Description("DESCPERMISOREPROCESAR")]
        [Section("MANTENIMIENTO")]
        EjecutarReprocesadosDeRecursos = 17179869184,
        [Description("DESCPERMISOAPLICACIONES")]
        [Section("APLICACIONES")]
        GestionarAplicacionesEspecificas = 34359738368,
        [Description("DESCPERMISOROLES")]
        [Section("COMUNIDAD")]
        GestionarRolesYPermisos = 68719476736
    }
}
