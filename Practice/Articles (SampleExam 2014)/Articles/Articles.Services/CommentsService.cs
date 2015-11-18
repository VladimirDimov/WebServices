namespace Articles.Services
{
    using Models;
    using Data.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Add(Comment commentToAdd)
        {
            this.comments.Add(commentToAdd);
            this.comments.SaveChanges();
        }
    }
}
