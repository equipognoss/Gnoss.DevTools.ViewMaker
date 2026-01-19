using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class RecentActivityItem
    {
        public string Key { get; set; }
        public bool Readed { get; set; }
        public string UrlCommunity { get; set; }
        public string NameCommunity { get; set; }
    }
}
