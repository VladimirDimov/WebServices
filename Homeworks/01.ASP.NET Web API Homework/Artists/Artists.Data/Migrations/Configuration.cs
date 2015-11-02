namespace Artists.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Artists.Data.ArtistsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // TODO: Make AutomaticMigrationDataLossAllowed = false
        }

        protected override void Seed(Artists.Data.ArtistsDbContext context)
        {
        }
    }
}
