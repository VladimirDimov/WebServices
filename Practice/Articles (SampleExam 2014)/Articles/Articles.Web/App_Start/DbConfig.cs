using Articles.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Articles.Data.Migrations;

namespace Articles.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
            ArticlesDbContext.Create().Database.Initialize(true);
        }
    }
}