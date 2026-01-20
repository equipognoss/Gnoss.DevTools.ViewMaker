using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class SolicitudNuevaComunidadModel
    {
        public Guid? ComunidadPrivadaPadreID { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public Guid PeticionID { get; set; }
        public bool IsPrivate { get; set; }
        public short TipoComunidad { get; set; }
        public DateTime FechaPeticion { get; set; }
        public string NombreCreador { get; set; }
        public string NombreCortoOrganizacion { get; set; }
        public string UrlPerfil { get; set; }
    }
}
