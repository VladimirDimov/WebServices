using Cookies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesSystem.Data
{
    public class CookiesSystemDbContext : DbContext
    {
        public CookiesSystemDbContext()
            : base("CookiesSystem")
        {
        }

        DbSet<Cookie> Cookies { get; set; }
    }
}
