namespace RoleBased.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class DBMigrationsConfig : DbMigrationsConfiguration<RoleBased.Models.ApplicationDbContext>
    {
        public DBMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "RoleBased.Models.ApplicationDbContext";
        }

        protected override void Seed(RoleBased.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
