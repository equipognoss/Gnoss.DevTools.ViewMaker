using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS que es una ConsultaSPARQL
    /// </summary>
    [Serializable]
    public class CMSComponentQuerySPARQL : CMSComponent
    {
        /// <summary>
        /// DATASET Result
        /// </summary>
        public DataSet DataSetResult { get; set; }

    }
}
