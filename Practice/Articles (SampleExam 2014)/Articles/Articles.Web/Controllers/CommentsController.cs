namespace Articles.Web.Controllers
{
    using Articles.Models;
    using Services;
    using Articles.Web.Models.BindingModels;
    using Microsoft.AspNet.Identity;
    using System.Web.Http;

    public class CommentsController : ApiController
    {
        private CommentsService comments;

        public CommentsController(CommentsService comments)
        {
            this.comments = comments;
        }

        public IHttpActionResult Post(int id, CommentRequestModel comment)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var currentUserId = this.User.Identity.GetUserId();

            var commentToAdd = new Comment
            {
                ArticleId = id,
                Content = comment.Content,
                UserId = currentUserId
            };

            this.comments.Add(commentToAdd);

            return this.Ok("Comment added!");
        }
    }
}