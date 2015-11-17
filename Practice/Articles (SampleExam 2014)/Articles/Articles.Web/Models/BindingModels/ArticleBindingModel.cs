using Articles.Models;
using System;
using System.Collections.Generic;
namespace Articles.Web.Models.BindingModels
{
    public class ArticleBindingModel
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public virtual IEnumerable<string> Tags { get; set; }
    }
}