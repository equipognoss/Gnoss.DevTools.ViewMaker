using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class SolicitudUsuarioComunidadModel
    {
        public Guid SolicitudID { get; set; }
        public Guid UsuarioID { get; set; }
        public Guid PersonaID { get; set; }
        public Guid PerfilID { get; set; }
        public string Nombre { get; set; }
        public string NombreCorteUsu { get; set; }
    }
}
