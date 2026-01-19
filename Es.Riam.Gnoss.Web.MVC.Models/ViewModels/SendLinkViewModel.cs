namespace Es.Riam.Gnoss.Web.MVC.Models.ViewModels
{
    /// <summary>
    /// View model de la pagina de "Enviar enlace" 
    /// </summary>
    public class SendLinkViewModel
    {
        /// <summary>
        /// Url del recurso que queremos enviar
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// Nombre del recurso que queremos enviar
        /// </summary>
        public string LinkName { get; set; }
        /// <summary>
        /// Acciones extra que se deben realizan en el javascript al enviar un enlace
        /// </summary>
        public string ExtraActionSent { get; set; }
        /// <summary>
        /// Mensaje que queremos enviar junto al enlace
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Idioma en el que queremos enviar el mensaje
        /// </summary>
        public string Lang { get; set; }
        /// <summary>
        /// Identificadores y emails a los que queremos enviar el mensaje
        /// </summary>
        public string Receivers { get; set; }
    }
}
