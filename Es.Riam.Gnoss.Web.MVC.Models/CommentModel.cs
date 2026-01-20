using Es.Riam.Gnoss.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class CommentModel
    {
        /// <summary>
        /// Identificador del comentario
        /// </summary>
        public Guid Key { get; set; }
        /// <summary>
        /// Texto del comentario
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Fecha de publicación del comentario
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// Publicador del comentario
        /// </summary>
        public ProfileModel PublisherCard { get; set; }
        /// <summary>
        /// Votos del comentario
        /// </summary>
        public VotesModel Votes { get; set; }
        /// <summary>
        /// Respuestas a el comentario
        /// </summary>
        public List<CommentModel> Replies { get; set; }
        /// <summary>
        /// Acciones permitidas en el comentario
        /// </summary>
        public ActionsModel Actions { get; set; }

        /// <summary>
        /// Modelo de acciones de un comentario
        /// </summary>
        [Serializable]
        public partial class ActionsModel
        {
            /// <summary>
            /// Indica si el usuario se puede eliminar el comentario
            /// </summary>
            public bool Delete { get; set; }
            /// <summary>
            /// Url de la accion de eliminar un comentario
            /// </summary>
            public string UrlDelete { get; set; }
            /// <summary>
            /// Indica si el usuario se puede editar el comentario
            /// </summary>
            public bool Edit { get; set; }
            /// <summary>
            /// Url de la accion de editar un comentario
            /// </summary>
            public string UrlEdit { get; set; }
            /// <summary>
            /// Indica si el usuario se puede responder el comentario
            /// </summary>
            public bool Reply { get; set; }
            /// <summary>
            /// Url de la accion de responder un comentario
            /// </summary>
            public string UrlReply { get; set; }
            /// <summary>
            /// Url de la accion de votar positivo un comentario
            /// </summary>
            public string UrlVotePositive { get; set; }
            /// <summary>
            /// Url de la accion de votar negativo un comentario
            /// </summary>
            public string UrlVoteNegative { get; set; }
            /// <summary>
            /// Url de la accion de eliminar el voto de un comentario
            /// </summary>
            public string UrlDeleteVote { get; set; }

        }
    }
}
