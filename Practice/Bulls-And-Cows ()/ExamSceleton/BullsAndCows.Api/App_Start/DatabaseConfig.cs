using BullsAndCows.Data;
using BullsAndCows.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BullsAndCows.Api.App_Start
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
            BullsAndCowsDbContext.Create().Database.Initialize(true);
        }
    }

}