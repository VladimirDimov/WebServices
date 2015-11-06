using Cookies.Models;
using CookiesSytem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesSystem.Services
{
    public interface ICookiesService
    {
        IQueryable<Cookie> All(int page = 1, int pageSize = CookiesConstants.PageSize);
    }
}
