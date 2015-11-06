namespace CookiesSystem.Web
{
    using CookiesSystem.Data;
    using CookiesSystem.Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CookiesSystemDbContext, Configuration>());
            CookiesSystemDbContext.Create().Database.Initialize(true);
        }
    }
}