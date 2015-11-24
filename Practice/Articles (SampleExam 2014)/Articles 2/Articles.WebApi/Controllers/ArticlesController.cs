namespace Articles.WebApi.Controllers
{
    using Articles.Models;
    using Articles.Services;
    using Common;
    using Models.Articles;
    using System;
    using System.Linq;
    using System.Web.Http;

    [Authorize]
    public class ArticlesController : ApiController
    {
        private ArticlesServices articles;
        private CategoriesServices categories;
        private TagsServices tags;

        public ArticlesController(ArticlesServices articles, CategoriesServices categories, TagsServices tags)
        {
            this.articles = articles;
            this.categories = categories;
            this.tags = tags;
        }

        // api/articles
        [HttpPost]
        public IHttpActionResult CreateArticle(ArticlesRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var articleToCreate = new Article
            {
                Title = model.Title,
                Content = model.Content,
                Category = this.categories.GetByName(model.Category),
                Tags = this.tags.GetTagCollection(model.Tags),
                DateCreated = DateTime.Now
            };

            Article createdArticle = this.articles.Add(articleToCreate);

            return this.Ok(ArticleResponseModel.GetFromModel(createdArticle));
        }

        public IHttpActionResult Get(int page = 1)
        {
            var articlesCollection = this.articles
                 .GetByPage(page, Constants.DefaultPageSize)
                 .Select(ArticleResponseModel.FromModel)
                 .ToList();

            return this.Ok(articlesCollection);
        }

        public IHttpActionResult Get(string category, int page = 1)
        {
            var articlesCollection = this.articles
                 .GetByCategory(category, page, Constants.DefaultPageSize)
                 .Select(ArticleResponseModel.FromModel)
                 .ToList();

            return this.Ok(articlesCollection);
        }
    }
}