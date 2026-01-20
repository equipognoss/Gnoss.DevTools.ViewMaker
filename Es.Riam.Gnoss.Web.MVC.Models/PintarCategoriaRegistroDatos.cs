namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class PintarCategoriaRegistroDatos
    {
        public Dictionary<Guid, KeyValuePair<string, Dictionary<Guid, string>>> listaPreferencias { get; set; }
        public Guid catID { get; set; }
        public int numCat { get; set; }
    }
}
