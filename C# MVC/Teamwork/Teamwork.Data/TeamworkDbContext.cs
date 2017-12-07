using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teamwork.Data.Models;

namespace Teamwork.Web.Data
{
    public class TeamworkDbContext : IdentityDbContext<User>
    {
        public TeamworkDbContext(DbContextOptions<TeamworkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<StudentProject> StudentProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
