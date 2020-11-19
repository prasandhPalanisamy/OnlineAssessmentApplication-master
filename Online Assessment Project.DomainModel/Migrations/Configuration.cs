namespace Online_Assessment_Project.DomainModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Online_Assessment_Project.DomainModel.AssessmentPortalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Online_Assessment_Project.DomainModel.AssessmentPortalDbContext";
        }

        protected override void Seed(Online_Assessment_Project.DomainModel.AssessmentPortalDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
