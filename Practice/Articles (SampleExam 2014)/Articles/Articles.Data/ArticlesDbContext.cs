namespace Articles.Data
{
    using Articles.Models;
    using ChatSystem.Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ArticlesDbContext : IdentityDbContext<User>, IArticlesDbContext
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        public virtual DbSet<Dislike> Dislikes { get; set; }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
