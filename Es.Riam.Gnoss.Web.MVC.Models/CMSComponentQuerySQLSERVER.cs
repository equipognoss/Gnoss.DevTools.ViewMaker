using System.Data;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Representa un componente del CMS que es una ConsultaSQLSERVER
    /// </summary>
    [Serializable]
    public class CMSComponentQuerySQLSERVER : CMSComponent
    {
        /// <summary>
        /// DATASET Result
        /// </summary>
        public DataSet DataSetResult { get; set; }

    }
}
