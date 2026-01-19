namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para la edición de licencia.
    /// </summary>
    public partial class LicenseEditorModel
    {
        /// <summary>
        /// Indica si la licencia no es editable.
        /// </summary>
        public bool NotEditable { get; set; }

        /// <summary>
        /// Licencia por defecto para el editor.
        /// </summary>
        public string DefaultLicense { get; set; }

        /// <summary>
        /// Mensaje de la comunidad para la licencia por defecto.
        /// </summary>
        public string MessageDefaultLicense { get; set; }

        /// <summary>
        /// Licencia actual.
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Nombre del ecosistema del proyecto.
        /// </summary>
        public string EcosystemProjectName { get; set; }
    }
}
