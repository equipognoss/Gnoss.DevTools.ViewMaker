namespace Es.Riam.Gnoss.Web.MVC.Models
{
    /// <summary>
    /// Modelo de comentario
    /// </summary>
    public partial class CommentSearchModel : ObjetoBuscadorModel
    {
        /// <summary>
        /// Identificador del comentario
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Descrpción del comentario
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Titulo del recurso del comentario
        /// </summary>
        public string ResourceTitle { get; set; }
        /// <summary>
        /// URL del recurso del comentario
        /// </summary>
        public string ResourceUrl { get; set; }
        /// <summary>
        /// URL de la imagen del recurso del comentario
        /// </summary>
        public string ResourceImageUrl { get; set; }
        /// <summary>
        /// Indica si el comentario ha sido leido
        /// </summary>
        public bool Readed { get; set; }
        /// <summary>
        /// Fecha en la que se realizó el comentario
        /// </summary>
        public DateTime DateComment { get; set; }
        /// <summary>
        /// Clave del publicador del comentario
        /// </summary>
        public Guid PublisherKey { get; set; }
        /// <summary>
        /// Publicador del comentario
        /// </summary>
        public ProfileModel Publisher { get; set; }
    }
}
