namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de un curriculum simple
    /// </summary>
    public partial class CurriculumModel
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Provincia o estado
        /// </summary>
        public string ProvinceOrState { get; set; }
        /// <summary>
        /// País
        /// </summary>
        public string Countryname { get; set; }
        /// <summary>
        /// Cargo en la empresa actual
        /// </summary>
        public string PositionTitleEmpresaActual { get; set; }
        /// <summary>
        /// Nombre de la empresa actual
        /// </summary>
        public string CurrentOrganizationName { get; set; }
        /// <summary>
        /// Descripción del curriculum
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Lista de tags del curriculum
        /// </summary>
        public List<string> ListTags { get; set; }
    }
}
