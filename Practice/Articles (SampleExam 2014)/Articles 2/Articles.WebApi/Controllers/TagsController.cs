using Articles.Services;
using Articles.WebApi.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Articles.WebApi.Controllers
{
    public class TagsController : ApiController
    {
        private TagsServices tags;

        public TagsController(TagsServices tags)
        {
            this.tags = tags;
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var articlesToReturn = this.tags.GetArticlesByTagId(id)
                .Select(ArticleResponseModel.FromModel)
                .ToList();

                return this.Ok(articlesToReturn);
            }
            catch (Exception m)
            {
                return this.BadRequest(m.Message);
            }
        }
    }
}
