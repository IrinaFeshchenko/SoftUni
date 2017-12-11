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

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentProject>()
                .HasKey(sp => new { sp.StudentId, sp.ProjectId });

            builder
                .Entity<User>()
                .HasMany(student => student.StudentProjects)
                .WithOne(sp => sp.Student)
                .HasForeignKey(sp => sp.StudentId);

            builder
                .Entity<Project>()
                .HasMany(p => p.StudentProjects)
                .WithOne(sp => sp.Project)
                .HasForeignKey(sp => sp.ProjectId);

            builder
                .Entity<Project>()
                .HasOne(p => p.Creator)
                .WithMany(c => c.CreatedProjects)
                .HasForeignKey(c => c.CreatorId);

            builder
                .Entity<Assessment>()
                .HasOne(a => a.Project)
                .WithMany(p => p.Assessments)
                .HasForeignKey(a => a.ProjectId);

            builder
                .Entity<Assessment>()
                .HasOne(a => a.FromStudent)
                .WithMany(fromStudent => fromStudent.AssesmentsGiven)
                .HasForeignKey(a => a.FromStudentId);

            builder
                .Entity<Assessment>()
                .HasOne(a => a.ForStudent)
                .WithMany(forStudent => forStudent.AssesmentsReceived)
                .HasForeignKey(a => a.FromStudentId);

            builder
                .Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);

            base.OnModelCreating(builder);
        }
    }
}
