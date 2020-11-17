using System.Data.Entity;

namespace Online_Assessment_Project.DomainModel
{
    public class AssessmentPortalDbContext :DbContext
    {
        public AssessmentPortalDbContext() : base("AssessmentPortalDbContext")
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
