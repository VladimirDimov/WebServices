namespace Articles.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Articles.Data.ArticlesDbContext>
    {
        public Configuration()
        {
            base.AutomaticMigrationsEnabled = true;
            base.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Articles.Data.ArticlesDbContext context)
        {
        }
    }
}
