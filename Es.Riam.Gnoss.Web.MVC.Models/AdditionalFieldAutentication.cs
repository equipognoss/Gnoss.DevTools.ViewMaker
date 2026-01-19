namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de campo adicional del registro
    /// </summary>
    public partial class AdditionalFieldAutentication
    {
        /// <summary>
        /// Nombre del campo
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Identificador del campo
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Indica si el campo es obligatorio
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Opciones para seleccionar si el campo es de tipo combo
        /// </summary>
        public Dictionary<Guid, string> Options { get; set; }
        /// <summary>
        /// Identificador del campo del que depende, no tiene por que tener valor
        /// </summary>
        public string DependencyFields { get; set; }
        /// <summary>
        /// Valor del campo adicional
        /// </summary>
        public string FieldValue { get; set; }
        /// <summary>
        /// Indica si el campo se va a autocompletar
        /// </summary>
        public bool AutoCompleted { get; set; }
        /// <summary>
        /// Indica si el campo será visible en la edicion del perfil
        /// </summary>
        public bool Visible { get; set; }
    }
}
