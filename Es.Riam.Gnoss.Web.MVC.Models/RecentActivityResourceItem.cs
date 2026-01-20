using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class RecentActivityResourceItem : RecentActivityItem
    {
        public ResourceModel Resource { get; set; }
        public List<ResourceEventModel> Events { get; set; }
    }
}
