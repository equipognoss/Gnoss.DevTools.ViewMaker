using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS del tipo Caja Buscador
    /// </summary>
    [Serializable]
    public class CMSComponentSearchBox : CMSComponent
    {
        public string DefaultText { get; set; }
        public Guid AutocompleteID { get; set; }
        public string UrlBusqueda { get; set; }
    }
}
