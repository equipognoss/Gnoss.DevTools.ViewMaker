using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.AD.ServiciosGenerales
{
    public enum PermisoEcosistema : ulong
    {
        [Description("DESCPERMISOECOSISTEMATRADUCCIONES")]
        [Section("ECOSISTEMA")]
        GestionarTraduccionesEcosistema = 1,
        [Description("DESCPERMISOECOSISTEMADATOSEXTRA")]
        [Section("ECOSISTEMA")]
        GestionarDatosExtraRegistroEcosistema = 2,
        [Description("DESCPERMISOECOSISTEMACORREO")]
        [Section("ECOSISTEMA")]
        GestionarBuzonDeCorreoEcosistema = 4,
        [Description("DESCPERMISOECOSISTEMAEVENTOS")]
        [Section("ECOSISTEMA")]
        GestionarEventosExternosEcosistema = 8,
        [Description("DESCPERMISOECOSISTEMACATEGORIAS")]
        [Section("ECOSISTEMA")]
        GestionarCategoriasDePlataforma = 16,
        [Description("DESCPERMISOECOSISTEMACONFIGURACION")]
        [Section("ECOSISTEMA")]
        GestionarLaConfiguracionPlataforma = 32,
        [Description("DESCPERMISOECOSISTEMASHAREPOINT")]
        [Section("ECOSISTEMA")]
        ConfiguracionDeSharePoint = 64,
        [Description("DESCPERMISOECOSISTEMAVISTAS")]
        [Section("ECOSISTEMA")]
        GestionarVistasEcosistema = 128,
        [Description("DESCPERMISOECOSISTEMAIC")]
        [Section("ECOSISTEMA")]
        AdministrarIntegracionContinua = 256,
        [Description("DESCPERMISOECOSISTEMASOLICITUDES")]
        [Section("ECOSISTEMA")]
        AdministrarSolicitudesComunidad = 512,
        [Description("DESCPERMISOECOSISTEMAROLES")]
        [Section("ECOSISTEMA")]
        GestionarRolesYPermisosEcosistema = 1024,
        [Description("DESCPERMISOECOSISTEMAMIEMBROS")]
        [Section("ECOSISTEMA")]
        AdministrarMiembrosEcosistema = 2048
    }
}
