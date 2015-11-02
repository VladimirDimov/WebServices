namespace Artists.UI
{
    using Artists.Data;
    using Artists.Data.Migrations;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());

            var db = new ArtistsDbContext();
            db.Artists.Count();
        }
    }
}
