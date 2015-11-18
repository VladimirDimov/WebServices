using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using Articles.Models;

namespace Articles.Web.Models.BindingModels
{
    public class TagResponseModel
    {
        public string Name { get; set; }

        public static Expression<Func<Tag, TagResponseModel>> FromModel
        {
            get
            {
                return tag => new TagResponseModel
                {
                    Name = tag.Name
                };
            }
        }
    }
}