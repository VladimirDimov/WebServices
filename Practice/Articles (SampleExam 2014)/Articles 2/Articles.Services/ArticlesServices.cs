namespace Articles.Services
{
    using Articles.Data.Repositories;
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArticlesServices
    {
        private IRepository<Article> articles;

        public ArticlesServices(IRepository<Article> articles)
        {
            this.articles = articles;
        }

        public Article Add(Article articleToCreate)
        {
            this.articles.Add(articleToCreate);
            this.articles.SaveChanges();

            return this.articles.GetById(articleToCreate.Id);
        }

        public IQueryable<Article> GetByPage(int page, int pageSize)
        {
            var result = this.articles.All()
                .OrderBy(a => a.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return result;
        }

        public IQueryable<Article> GetByCategory(string category, int page, int pageSize)
        {
            var result = this.GetByPage(page, pageSize)
                .Where(a => a.Category.Name == category);

            return result;
        }

        public Article GetById(int id)
        {
            return this.articles.GetById(id);
        }
    }
}
