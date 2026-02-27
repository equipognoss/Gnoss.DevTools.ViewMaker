using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.AD.ServiciosGenerales
{
    public enum PermisoRecursos : ulong
    {
        [Description("DESCPERMISOCREARADJUNTO")]
        [Section("RECURSOS")]
        CrearRecursoTipoAdjunto = 1,
        [Description("DESCPERMISOEDITARADJUNTO")]
        [Section("RECURSOS")]
        EditarRecursoTipoAdjunto = 2,
        [Description("DESCPERMISOELIMINARADJUNTO")]
        [Section("RECURSOS")]
        EliminarRecursoTipoAdjunto = 4,

        [Description("DESCPERMISOCREARREFERENCIA")]
        [Section("RECURSOS")]
        CrearRecursoTipoReferenciaADocumentoFisico = 8,
        [Description("DESCPERMISOEDITARREFERENCIA")]
        [Section("RECURSOS")]
        EditarRecursoTipoReferenciaADocumentoFisico = 16,
        [Description("DESCPERMISOELIMINARREFERNCIA")]
        [Section("RECURSOS")]
        EliminarRecursoTipoReferenciaADocumentoFisico = 32,

        [Description("DESCPERMISOCREARENLACE")]
        [Section("RECURSOS")]
        CrearRecursoTipoEnlace = 64,
        [Description("DESCPERMISOEDITARENLACE")]
        [Section("RECURSOS")]
        EditarRecursoTipoEnlace = 128,
        [Description("DESCPERMISOELIMINARENLACE")]
        [Section("RECURSOS")]
        EliminarRecursoTipoEnlace = 256,

        [Description("DESCPERMISOCREARNOTA")]
        [Section("RECURSOS")]
        CrearNota = 512,
        [Description("DESCPERMISOEDITARNOTA")]
        [Section("RECURSOS")]
        EditarNota = 1024,
        [Description("DESCPERMISOELIMINARNOTA")]
        [Section("RECURSOS")]
        EliminarNota = 2048,

        [Description("DESCPERMISOCREARPREGUNTA")]
        [Section("RECURSOS")]
        CrearPregunta = 4096,
        [Description("DESCPERMISOEDITARPREGUNTA")]
        [Section("RECURSOS")]
        EditarPregunta = 8192,
        [Description("DESCPERMISOELIMINARPREGUNTA")]
        [Section("RECURSOS")]
        EliminarPregunta = 16384,

        [Description("DESCPERMISOCREARENCUESTA")]
        [Section("RECURSOS")]
        CrearEncuesta = 32768,
        [Description("DESCPERMISOEDITARENCUESTA")]
        [Section("RECURSOS")]
        EditarEncuesta = 65536,
        [Description("DESCPERMISOELIMINARENCUESTA")]
        [Section("RECURSOS")]
        EliminarEncuesta = 131072,

        [Description("DESCPERMISOCREARDEBATE")]
        [Section("RECURSOS")]
        CrearDebate = 262144,
        [Description("DESCPERMISOEDITARDEBATE")]
        [Section("RECURSOS")]
        EditarDebate = 524288,
        [Description("DESCPERMISOELIMINARDEBATE")]
        [Section("RECURSOS")]
        EliminarDebate = 1048576,

        [Description("DESCPERMISOCREARSEMANTICO")]
        [Section("RECURSOS")]
        CrearRecursoSemantico = 2097152,
        [Description("DESCPERMISOEDITARSEMANTICO")]
        [Section("RECURSOS")]
        EditarRecursoSemantico = 4194304,
        [Description("DESCPERMISOELIMINARSEMANTICO")]
        [Section("RECURSOS")]
        EliminarRecursoSemantico = 8388608,

        [Description("DESCPERMISORESTAURARVERSIONENLACE")]
        [Section("RECURSOS")]
        RestaurarVersionEnlace = 16777216,
        [Description("DESCPERMISOELIMINARVERSIONENLACE")]
        [Section("RECURSOS")]
        EliminarVersionEnlace = 33554432,

        [Description("DESCPERMISORESTAURARVERSIONADJUNTO")]
        [Section("RECURSOS")]
        RestaurarVersionAdjunto = 67108864,
        [Description("DESCPERMISOELIMINARVERSIONADJUNTO")]
        [Section("RECURSOS")]
        EliminarVersionAdjunto = 134217728,

        [Description("DESCPERMISORESTAURARVERSIONREFERNCIA")]
        [Section("RECURSOS")]
        RestaurarVersionReferencia = 268435456,
        [Description("DESCPERMISOELIMINARVERSIONREFERNCIA")]
        [Section("RECURSOS")]
        EliminarVersionReferencia = 536870912,

        [Description("DESCPERMISORESTAURARVERSIONNOTA")]
        [Section("RECURSOS")]
        RestaurarVersionNota = 1073741824,
        [Description("DESCPERMISORESELIMINARVERSIONNOTA")]
        [Section("RECURSOS")]
        EliminarVersionNota = 2147483648,

        [Description("DESCPERMISORESTAURARVERSIONPREGUNTA")]
        [Section("RECURSOS")]
        RestaurarVersionPregunta = 4294967296,
        [Description("DESCPERMISOELIMINARVERSIONPREGUNTA")]
        [Section("RECURSOS")]
        EliminarVersionPregunta = 8589934592,

        [Description("DESCPERMISORESTAURARVERSIONENCUESTA")]
        [Section("RECURSOS")]
        RestaurarVersionEncuesta = 17179869184,
        [Description("DESCPERMISOELIMINARVERSIONENCUESTA")]
        [Section("RECURSOS")]
        EliminarVersionEncuesta = 34359738368,

        [Description("DESCPERMISORESTAURARVERSIONDEBATE")]
        [Section("RECURSOS")]
        RestaurarVersionDebate = 68719476736,
        [Description("DESCPERMISOELIMINARVERSIONDEBATE")]
        [Section("RECURSOS")]
        EliminarVersionDebate = 137438953472,

        [Description("DESCPERMISOCERTIFICARRECURSO")]
        [Section("RECURSOS")]
        CertificarRecurso = 274877906944
    }
}
