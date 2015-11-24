namespace Articles.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Articles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class ArticlesDbContext : IdentityDbContext<User>
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Dislike> Dislikes { get; set; }

        public DbSet<Alert> Alerts { get; set; }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
