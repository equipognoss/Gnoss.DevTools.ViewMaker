using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Semantica.Plantillas
{
    // <summary>
    /// Tipo de campo de una ontología: entero, texto, etc.
    /// </summary>
    public enum TipoCampoOntologia
    {
        Texto = 0,
        Entero = 1,
        Numerico = 2,
        Boleano = 3,
        DateTime = 4,
        Date = 5,
        ListaTexto = 6,
        ListaEnteros = 7,
        ListaNumeros = 8,
        ListaBoleanos = 9,
        ListaDateTimes = 10,
        ListaDates = 11,
        Imagen = 12,
        Video = 13,
        Tiny = 14,
        Time = 15,
        ListaTimes = 16,
        Archivo = 17,
        Checks = 18,
        TextArea = 19,
        Link = 20,
        EmbebedLink = 21,
        ImagenExterna = 22,
        EmbebedObject = 23,
        ArchivoLink = 24
    }
}
