namespace Articles.Services
{
    using Articles.Data.Repository;
    using Articles.Models;
    using System.Linq;
    using System;

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

        public IQueryable<Article> GetByPage(int page)
        {
            var articles = this.articles.All()
                .OrderByDescending(a => a.Likes.Count)
                .Skip((page - 1) * 10)
                .Take(10)
                .OrderBy(x => x.DateCreated);

            return articles;
        }

        public IQueryable<Article> GetByCategory(string categoryName, int page)
        {
            var articles = this.articles.All()
                .Where(a => a.Category.Name == categoryName)
                .OrderByDescending(a => a.Likes.Count)
                .Skip((page - 1) * 10)
                .Take(10)
                .OrderBy(x => x.DateCreated);

            return articles;
        }

        public Article GetById(int id)
        {
            var articleToReturn = this.articles.All()
                .FirstOrDefault(a => a.ArticleId == id);

            return articleToReturn;
        }
    }
}
