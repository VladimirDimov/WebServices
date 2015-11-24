namespace Articles.WebApi.Models.Articles
{
    using global::Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class ArticlesRequestModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Category { get; set; }

        public IEnumerable<string> Tags { get; set; }       
    }
}