namespace Articles.Web.Controllers
{
    using System.Web.Http;
    using Articles.Data.Repository;
    using Articles.Models;
    //using Articles.Services.Contracts;
    using Articles.Services;
    using Articles.Web.Models.BindingModels;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;

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

        public IHttpActionResult Post(ArticleBindingModel article)
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
        public IHttpActionResult GetTopArticles()
        {
            List<Article> articles = this.articlesService.GetTopTenByLikes();
            // TODO: Bind the models
            return this.Ok(articles);
        }
    }
}