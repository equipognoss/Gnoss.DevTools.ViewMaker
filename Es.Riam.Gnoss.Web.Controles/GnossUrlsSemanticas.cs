using Es.Riam.Gnoss.Recursos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Clase para construir urls semánticas
/// </summary>
public class GnossUrlsSemanticas
{
    public GnossUrlsSemanticas()
    {

    }

    public string ObtenerURLAdministracionComunidad(UtilIdiomasSerializable pUtilIdiomas, string pBaseURLIdioma, string pNombreCorto, string pNombreSemPaginaDestino)
    {
        return pBaseURLIdioma;
    }

    public string ObtenerURLComunidad(UtilIdiomasSerializable pUtilIdiomas, string pBaseURLIdioma, string pNombreCorto)
    {
        return null;
    }

}
