namespace Articles.Services
{
    using Articles.Data.Repositories;
    using Articles.Models;
    using System;
    using System.Linq;

    public class LikesServices
    {
        private IRepository<Article> articles;
        private IRepository<Like> likes;

        public LikesServices(IRepository<Like> likes, IRepository<Article> articles)
        {
            this.likes = likes;
            this.articles = articles;
        }

        public void LikeArticle(int articleId, string userId)
        {
            var article = this.articles.GetById(articleId);
            if (article == null)
            {
                throw new InvalidOperationException("Invalid article id!");
            }

            if (article.Likes.Any(a => a.UserId == userId))
            {
                throw new InvalidOperationException("You have already liked this article");
            }

            article.Likes.Add(new Like
            {
                Article = article,
                UserId = userId
            });

            this.likes.SaveChanges();
            this.articles.SaveChanges();
        }

        public void UnlikeArticle(int articleId, string userId)
        {
            var article = this.articles.GetById(articleId);
            if (article == null)
            {
                throw new InvalidOperationException("Invalid article id!");
            }

            var likeToRemove = article.Likes.FirstOrDefault(a => a.UserId == userId);

            if (likeToRemove == null)
            {
                throw new InvalidOperationException("This article is not liked by you!");
            }

            this.likes.Delete(likeToRemove);

            this.likes.SaveChanges();
            this.articles.SaveChanges();
        }
    }
}
