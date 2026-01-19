using Es.Riam.Gnoss.Web.MVC.Models.ViewModels;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    [Serializable]
    public class PintarCategoriasIndice
    {
        public CategoryModel categoryModel { get; set; }
        public IndexViewModel indexView { get; set; }
    }
}
