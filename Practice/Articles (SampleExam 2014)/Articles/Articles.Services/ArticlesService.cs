namespace Articles.Services
{
    using Articles.Data.Repository;
    using Articles.Models;
    using System.Collections.Generic;
    using System.Linq;
    //using Articles.Services.Contracts;

    public class ArticlesService
    {
        private readonly IRepository<User> users;
        private IRepository<Article> articles;

        public ArticlesService(IRepository<User> users, IRepository<Article> articles)
        {
            this.users = users;
            this.articles = articles;
        }

        public void Add(Article article)
        {
            this.articles.Add(article);
            this.articles.SaveChanges();
        }

        public List<Article> GetTopTenByLikes()
        {
            return this.articles.All()
                .OrderByDescending(a => a.Likes.Count)
                .Take(10)
                .ToList();
        }
    }
}
