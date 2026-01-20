using Es.Riam.Semantica.OWL;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para la edición de las categorías del tesauro para el recurso.
    /// </summary>
    public partial class ThesaurusEditorModel
    {
        /// <summary>
        /// Categorías del tesauro disponibles del editor.
        /// </summary>
        public List<CategoryModel> ThesaurusCategories;
        /// <summary>
        /// Categorías del tesauro disponibles del editor.
        /// </summary>
        public List<CategoryModel> SuggestedThesaurusCategories;

        /// <summary>
        /// Lista con los IDs de las categorías seleccionadas.
        /// </summary>
        public List<Guid> SelectedCategories;

        /// <summary>
        /// Lista con los IDs de las categorías deshabilitadas.
        /// </summary>
        public List<Guid> DisabledCategories;

        /// <summary>
        /// Indica si se debe ocultar el selector de árbol o lista.
        /// </summary>
        public bool HideTreeListSelector;

        /// <summary>
        /// Categorías que deben pintarse expandidas en el tesauro.
        /// </summary>
        public List<Guid> ExpandedCategories;

        /// <summary>
        /// Categorías que deben pintarse expandidas en el tesauro.
        /// </summary>
        public List<Guid> SharedCategories;

        /// <summary>
        /// Propiedades extra de las categorias semánticas.
        /// </summary>
        public Dictionary<string, Propiedad> ExtraPropertiesCategories;
    }
}
