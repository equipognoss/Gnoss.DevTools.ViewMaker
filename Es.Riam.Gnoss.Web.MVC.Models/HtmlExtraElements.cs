using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    [Serializable]
    public partial class HtlmExtraElements
    {
        public string Content { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public string TagName { get; set; }
        public UbicacionHtmlProyecto Ubication { get; set; }
        public List<int> ElementIDUserList { get; set; }
        public int HeadElementID { get; set; }
        public bool CookiesControl { get; set; }
        public bool HasPrivateElementsInCommunity { get; set; }
    }
}
