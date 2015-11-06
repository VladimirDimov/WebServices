namespace CookiesSystem.Data
{
    using Cookies.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class CookiesSystemDbContext : IdentityDbContext<User>
    {
        public CookiesSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Cookie> Cookies { get; set; }

        public static CookiesSystemDbContext Create()
        {
            return new CookiesSystemDbContext();
        }
    }
}
