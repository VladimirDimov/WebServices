namespace CookiesSystem.Services
{
    using Cookies.Models;
    using CookiesSystem.Data;
    using CookiesSytem.Common;
    using System.Linq;

    class CookiesService : ICookiesService
    {
        private IRepository<Cookie> cookies;

        public CookiesService(IRepository<Cookie> cookiesRepo)
        {
            this.cookies = cookiesRepo;
        }

        public IQueryable<Cookies.Models.Cookie> All(int page = 1, int pageSize = CookiesConstants.PageSize)
        {
            return cookies.All()
                .Skip(page - 1)
                .Take(pageSize);
        }
    }
}
