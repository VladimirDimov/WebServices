using Articles.Models;
using Articles.WebApi.Models.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.WebApi.Models.Articles
{
    public class ArticleResponseModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public static Expression<Func<Article, ArticleResponseModel>> FromModel
        {
            get
            {
                return a => new ArticleResponseModel
                {
                    ID = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.Select(t => t.Name)
                };
            }
        }

        public static ArticleResponseModel GetFromModel(Article a)
        {
            return new ArticleResponseModel
            {
                ID = a.Id,
                Title = a.Title,
                Content = a.Content,
                Category = a.Category.Name,
                DateCreated = a.DateCreated,
                Tags = a.Tags.Select(t => t.Name)
            };
        }
    }
}