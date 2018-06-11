namespace EntityFrameworkText.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkText.BloggingContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFrameworkText.BloggingContex";
        }

        protected override void Seed(EntityFrameworkText.BloggingContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
