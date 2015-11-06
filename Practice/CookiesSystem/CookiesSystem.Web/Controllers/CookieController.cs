namespace CookiesSystem.Web.Controllers
{
    using Cookies.Models;
    using CookiesSystem.Services;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    public class CookieController : ApiController
    {
        ICookiesService cookiesService;

        public CookieController(ICookiesService cookiesService)
        {
            this.cookiesService = cookiesService;
        }

        // GET: api/Cookie
        public IHttpActionResult Get(int page)
        {
            var cookies = this.cookiesService.All(page);

            return this.Ok(cookies);
        }

        // POST: api/Cookie
        public void Post([FromBody]string value)
        {
        }
    }
}
