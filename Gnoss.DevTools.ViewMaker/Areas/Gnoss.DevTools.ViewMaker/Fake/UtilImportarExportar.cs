using System;

namespace Es.Riam.Gnoss.ExportarImportar
{
    public class UtilImportarExportar
    {
        public static string PasarFechaEnFormatoEstandar(DateTime date)
        {
            DateTime localDate = new DateTime(date.Ticks, DateTimeKind.Local);
            return localDate.ToString("yyyy-MM-ddTHH:mm:ss%K");
        }
    }
}