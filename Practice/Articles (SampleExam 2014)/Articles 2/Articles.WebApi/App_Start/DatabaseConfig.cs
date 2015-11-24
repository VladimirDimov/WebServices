namespace Articles.WebApi.App_Start
{
    using Articles.Data;
    using Articles.Data.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
            ArticlesDbContext.Create().Database.Initialize(true);
        }
    }
}