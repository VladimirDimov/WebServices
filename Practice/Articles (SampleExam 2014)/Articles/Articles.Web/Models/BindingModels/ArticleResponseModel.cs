namespace Articles.Web.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Articles.Models;
    using System.Data.Entity;

    public class ArticleResponseModel
    {
        public ArticleResponseModel()
        {
        }

        public ArticleResponseModel(Article article)
        {
            this.Title = article.Title;
            this.Category = article.Category.Name;
            this.Content = article.Content;
            this.Tags = article
                            .Tags
                            .Select(t => new TagResponseModel { Name = t.Name });
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public virtual IEnumerable<TagResponseModel> Tags { get; set; }

        public static Expression<Func<Article, ArticleResponseModel>> FromModel
        {
            get
            {
                return a => new ArticleResponseModel
                {
                    Title = a.Title,
                    Category = a.Category.Name,
                    Content = a.Content,
                    Tags = a.Tags.Select(x => new TagResponseModel { Name = x.Name })
                };
            }
        }
    }
}