namespace BullsAndCows.WebApi.App_Start
{
    using BullsAndCows.Data;
    using BullsAndCows.Data.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SkeletonDbContext, Configuration>());
            SkeletonDbContext.Create().Database.Initialize(true);
        }
    }
}