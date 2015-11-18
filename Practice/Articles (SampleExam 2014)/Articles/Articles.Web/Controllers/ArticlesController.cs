namespace Articles.Web.Controllers
{
    using Articles.Models;
    //using Articles.Services.Contracts;
    using Articles.Services;
    using Articles.Web.Models.BindingModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class ArticlesController : ApiController
    {
        private ArticlesService articlesService;
        private CategoriesService categories;
        private TagsService tags;

        public ArticlesController(ArticlesService articlesService, CategoriesService categories, TagsService tags)
        {
            this.articlesService = articlesService;
            this.categories = categories;
            this.tags = tags;
        }

        public IHttpActionResult Post(ArticleRequestModel article)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var currentUserId = this.User.Identity.GetUserId();

            var articleToAdd = new Article
            {
                AuthorId = currentUserId,
                Category = this.categories.GetByName(article.Category),
                Content = article.Content,
                DateCreated = DateTime.Now,
                Title = article.Title,
                Tags = this.tags.GetCollection(article.Tags)
            };

            this.articlesService.Add(articleToAdd);

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Get(page: 1);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var articles =
                this.articlesService
                .GetByPage(page)
                .Select(ArticleResponseModel.FromModel)
                .ToList();

            return this.Ok(articles);
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            return this.Get(category, page: 1);
        }

        [HttpGet]
        public IHttpActionResult Get(string category, int page)
        {
            var articles =
                this.articlesService
                .GetByCategory(category, page)
                .Select(ArticleResponseModel.FromModel)
                .ToList();

            return this.Ok(articles);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var article =
                this.articlesService
                .GetById(id);

            var articleToReturn = new ArticleResponseModel(article);

            return this.Ok(articleToReturn);
        }
    }
}