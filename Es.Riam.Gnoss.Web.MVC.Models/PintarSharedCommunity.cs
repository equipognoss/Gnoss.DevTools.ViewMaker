using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    [Serializable]
    public class PintarSharedCommunity
    {
        public List<ResourceModel.SharedBRModel> listaBaseRecursos { get; set; }
        public int position { get; set; }
        public bool pintarNumerLimitado { get; set; }
        public ResourceModel resourceModel { get; set; }
    }
}
