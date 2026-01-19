namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para la página de administración de las categorías del espacio personal.
    /// </summary>
    public class AdminCatEspacioPersonalModel
    {
        /// <summary>
        /// Modelo para la edición del tesauro de la administración de categorías.
        /// </summary>
        public ThesaurusEditorModel ThesaurusEditorModel { get; set; }

        /// <summary>
        /// Lista de IDs mas nombre de categorías padre sobre las que se pueden crear nuevas categorías.
        /// </summary>
        public Dictionary<Guid, string> ParentCategoriesForCreateNewsCategories { get; set; }

        /// <summary>
        /// Url para volver atrás.
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// Backup de acciones realizadas hasta el momento.
        /// </summary>
        public string ActionsBackUp { get; set; }

        /// <summary>
        /// Nombres de las categorías que se van a mover.
        /// </summary>
        public List<string> CategoryNamesToMove { get; set; }

        /// <summary>
        /// Lista de IDs mas nombre de categorías padre sobre las que se pueden mover otras categorías.
        /// </summary>
        public Dictionary<Guid, string> ParentCategoriesForMoveCategories { get; set; }

        /// <summary>
        /// Lista de IDs mas nombre de categorías padre sobre las que se pueden ordenar (poner detrás) otras categorías.
        /// </summary>
        public Dictionary<Guid, string> ParentCategoriesForOrderCategories { get; set; }

        /// <summary>
        /// Lista de IDs mas nombre de categorías padre sobre las que se pueden mover los recursos de las categorías que se van a eliminar.
        /// </summary>
        public Dictionary<Guid, string> ParentCategoriesForDeleteCategories { get; set; }

        /// <summary>
        /// Nombres de las categorías que se van a ordenar.
        /// </summary>
        public List<string> CategoryNamesToOrder { get; set; }

        /// <summary>
        /// Nombres de las categorías que se van a eliminar.
        /// </summary>
        public List<string> CategoryNamesToDelete { get; set; }

        /// <summary>
        /// Indica si los recursos de las categorías que se van a eliminar son no huerfanos, es decir, que tienen otras categorías vinculadas a aparte de las que se van a eliminar.
        /// </summary>
        public bool ResourcesOfCategoriesDeletingAreNotOrphans { get; set; }
    }
}
