namespace CookiesSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CookiesSystem.Data.CookiesSystemDbContext>
    {
        public Configuration()
        {
            base.AutomaticMigrationsEnabled = true;
            base.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CookiesSystem.Data.CookiesSystemDbContext context)
        {
        }
    }
}
