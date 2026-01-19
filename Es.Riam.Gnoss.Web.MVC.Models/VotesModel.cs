using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class VotesModel
    {
        /// <summary>
        /// Número de votos positivos
        /// </summary>
        public int NumPositiveVotes { get; set; }
        /// <summary>
        /// Número de votos Negativos
        /// </summary>
        public int NumNegativeVotes { get; set; }
        /// <summary>
        /// Indica si has votado positivo
        /// </summary>
        public bool IsVotedPositive { get; set; }
        /// <summary>
        /// Indica si has votado Negativo
        /// </summary>
        public bool IsVotedNegative { get; set; }
        /// <summary>
        /// Indica si eres el creador del objeto que se esta votando
        /// </summary>
        public bool IsOwnedAuthor { get; set; }
        /// <summary>
        /// Indica si se pueden mostrar los votantes
        /// </summary>
        public bool ShowVoters { get; set; }
        /// <summary>
        /// Indica si se puede votar negativo
        /// </summary>
        public bool AllowNegativeVotes { get; set; }
        /// <summary>
        /// Número de votos totales 
        /// </summary>
        public int NumVotes { get; set; }
        /// <summary>
        /// Lista de votantes
        /// </summary>
        public List<VoterModel> Voters { get; set; }
        /// <summary>
        /// Indica la url para votar positivo
        /// </summary>
        public string UrlVotePositive { get; set; }
        /// <summary>
        /// Indica la url para votar negativo
        /// </summary>
        public string UrlVoteNegative { get; set; }
        /// <summary>
        /// Indica la url para eliminar un voto
        /// </summary>
        public string UrlDeleteVote { get; set; }
        /// <summary>
        /// Modelo de un votante
        /// </summary>
        [Serializable]
        public partial class VoterModel
        {
            /// <summary>
            /// Nombre
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Url del perfil
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// Foto del votante
            /// </summary>
            public string Image { get; set; }
            /// <summary>
            /// Voto
            /// </summary>
            public int Vote { get; set; }
        }
    }
}
