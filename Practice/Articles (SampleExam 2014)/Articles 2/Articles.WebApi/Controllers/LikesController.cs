namespace Articles.WebApi.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/articles/likes")]
    public class LikesController : ApiController
    {
        private ArticlesServices articles;
        private LikesServices likes;

        public LikesController(LikesServices likes, ArticlesServices articles)
        {
            this.likes = likes;
            this.articles = articles;
        }

        [Route("{id:int}")]
        public IHttpActionResult Post(int id)
        {
            try
            {
                this.likes.LikeArticle(id, this.User.Identity.GetUserId());
                return this.Ok(string.Format("Article likes: {0}", this.articles.GetById(id).Likes.Count));
            }
            catch (Exception m)
            {
                return this.BadRequest(m.Message);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id)
        {
            try
            {
                this.likes.UnlikeArticle(id, this.User.Identity.GetUserId());
                return this.Ok(string.Format("Article likes: {0}", this.articles.GetById(id).Likes.Count));
            }
            catch (Exception m)
            {
                return this.BadRequest(m.Message);
            }
        }
    }
}
