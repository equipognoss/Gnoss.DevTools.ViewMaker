using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.AD.ServiciosGenerales
{
    public class SectionAttribute : Attribute
    {
        public string Nombre { get; set; }
        public SectionAttribute(string name)
        {
            this.Nombre = name;
        }
    }
}
