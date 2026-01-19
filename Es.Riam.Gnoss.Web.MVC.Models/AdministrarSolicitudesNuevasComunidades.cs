using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class AdministrarSolicitudesNuevasComunidades
    {
        public List<SolicitudNuevaComunidadModel> SolicitudesNuevasComunidades { get; set; }
        public string PageName { get; set; }
        public int NumeroResultadosTotal { get; set; }
        public int NumeroPaginaActual { get; set; }
        public string UrlBusqueda { get; set; }
        public string ComunidadUrl { get; set; }
    }
}
