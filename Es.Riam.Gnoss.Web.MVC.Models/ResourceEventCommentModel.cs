namespace Es.Riam.Gnoss.Web.MVC.Models
{
    public partial class ResourceEventCommentModel : ResourceEventModel
    {
        public Guid CommentKey { get; set; }
        public CommentModel Comment { get; set; }
    }
}
