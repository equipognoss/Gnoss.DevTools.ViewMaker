namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo para las respuestas de una encuesta.
    /// </summary>
    public partial class PollAnswersModel
    {
        /// <summary>
        /// Respuestas de la encuesta.
        /// </summary>
        public List<string> Answers { get; set; }
    }
}
