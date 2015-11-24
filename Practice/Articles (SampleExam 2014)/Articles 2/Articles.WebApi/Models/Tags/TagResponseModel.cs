namespace Articles.WebApi.Models.Tags
{
    using global::Articles.Models;
    using System;
    using System.Linq.Expressions;

    public class TagResponseModel
    {
        public string Name { get; set; }

        public static Expression<Func<Tag, TagResponseModel>> FromModel
        {
            get
            {
                return t => new TagResponseModel
                {
                    Name = t.Name
                };
            }
        }

    }
}