using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.AD.ServiciosGenerales
{
    public enum PermisoContenidos : ulong
    {
        [Description("DESCPERMISOVERCATEGORIA")]
        [Section("COMUNIDAD")]
        VerCategorias = 1,
        [Description("DESCPERMISOANYADIRCATEGORIA")]
        [Section("COMUNIDAD")]
        AnyadirCategoria = 2,
        [Description("DESCPERMISOEDITARCATEGORIA")]
        [Section("COMUNIDAD")]
        ModificarCategoria = 4,
        [Description("DESCPERMISOELIMINARCATEGORIA")]
        [Section("COMUNIDAD")]
        EliminarCategoria = 8,

        [Description("DESCPERMISOVERPAGINA")]
        [Section("ESTRUCTURA")]
        VerPagina = 16,
        [Description("DESCPERMISOCREARPAGINA")]
        [Section("ESTRUCTURA")]
        CrearPagina = 32,
        [Description("DESCPERMISOPUBLICARPAGINA")]
        [Section("ESTRUCTURA")]
        PublicarPagina = 64,
        [Description("DESCPERMISOEDITARPAGINA")]
        [Section("ESTRUCTURA")]
        EditarPagina = 128,
        [Description("DESCPERMISOELIMINARPAGINA")]
        [Section("ESTRUCTURA")]
        EliminarPagina = 256,

        [Description("DESCPERMISOVERCMS")]
        [Section("ESTRUCTURA")]
        VerComponenteCMS = 512,
        [Description("DESCPERMISOCREARCMS")]
        [Section("ESTRUCTURA")]
        CrearComponenteCMS = 1024,
        [Description("DESCPERMISOEDITARCMS")]
        [Section("ESTRUCTURA")]
        EditarComponenteCMS = 2048,
        [Description("DESCPERMISOELIMINARCMS")]
        [Section("ESTRUCTURA")]
        EliminarComponenteCMS = 4096,
        [Description("DESCPERMISOMULTIMEDIACMS")]
        [Section("ESTRUCTURA")]
        GestionarMultimediaCMS = 8192,

        [Description("DESCPERMISOGESTIONAROC")]
        [Section("GRAFO")]
        GestionarOC = 16384,
        [Description("DESCPERMISOANYADIRSECUNDARIA")]
        [Section("GRAFO")]
        AnyadirValorEntidadSecundaria = 32768,
        [Description("DESCPERMISOMODIFICARSECUNDARIA")]
        [Section("GRAFO")]
        ModificarValorEntidadSecundaria = 65536,
        [Description("DESCPERMISOELIMINARSECUNDARIA")]
        [Section("GRAFO")]
        EliminarValorEntidadSecundaria = 131072,

        [Description("DESCPERMISOVERTESAURO")]
        [Section("GRAFO")]
        VerTesauroSemantico = 262144,
        [Description("DESCPERMISOANYADIRTESAURO")]
        [Section("GRAFO")]
        AnyadirValorTesauro = 524288,
        [Description("DESCPERMISOMODIFICARTESAURO")]
        [Section("GRAFO")]
        ModificarValorTesauro = 1048576,
        [Description("DESCPERMISOELIMINARTESAURO")]
        [Section("GRAFO")]
        EliminarValorTesauro = 2097152,

        [Description("DESCPERMISOVERFACETA")]
        [Section("DESCUBRIMIENTO")]
        VerFaceta = 4194304,
        [Description("DESCPERMISOCREARFACETA")]
        [Section("DESCUBRIMIENTO")]
        CrearFaceta = 8388608,
        [Description("DESCPERMISOMODIFICARFACETA")]
        [Section("DESCUBRIMIENTO")]
        ModificarFaceta = 16777216,
        [Description("DESCPERMISOELIMINARFACETA")]
        [Section("DESCUBRIMIENTO")]
        EliminarFaceta = 33554432,

        [Description("DESCPERMISORESTAURARVERSIONCMS")]
        [Section("ESTRUCTURA")]
        RestaurarVersionCMS = 67108864,
        [Description("DESCPERMISOELIMINARVERSIONCMS")]
        [Section("ESTRUCTURA")]
        EliminarVersionCMS = 134217728,

        [Description("DESCPERMISORESTAURARVERSIONPAGINA")]
        [Section("ESTRUCTURA")]
        RestaurarVersionPagina = 268435456,
        [Description("DESCPERMISOELIMINARVERSIONPAGINA")]
        [Section("ESTRUCTURA")]
        EliminarVersionPagina = 536870912
    }
}
