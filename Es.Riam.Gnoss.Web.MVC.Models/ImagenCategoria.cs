using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class ImagenCategoria
    {
        public Guid CategoriaID { get; set; }
        public string SizeXS { get; set; }
        public string SizeS { get; set; }
        public string SizeM { get; set; }
        public string SizeL { get; set; }
        public string SizeXL { get; set; }
        public string Original { get; set; }
    }
}
