namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public class SharedSemCms
    {
        public SemanticPropertyModel semanticPropertyModel { get; set; }
        public SemanticPropertyModel.PropertyValue propertyValue { get; set; }
        public string pIdioma { get; set; }
        public int pNumValor { get; set; }
        public string pValor { get; set; }
        public bool pTesauroSemSimple { get; set; }
        public SemanticPropertyModel.ResourceLinkedToEntitySelector pRecLink { get; set; }
        public short pTipoCampo { get; set; }
        public List<SemanticPropertyModel.PropertyValue> pValores { get; set; }
    }
}
