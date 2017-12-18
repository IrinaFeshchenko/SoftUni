using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Teamwork.Data.Models;

namespace Teamwork.Data
{
    public class TeamworkDbContext : IdentityDbContext<User>
    {
        public TeamworkDbContext(DbContextOptions<TeamworkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<StudentProject> StudentProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Keys for ManyToMany Tables
            builder
                .Entity<TeacherCourse>()
                .HasKey(tc => new { tc.TeacherId, tc.CourseId });

            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<StudentProject>()
                .HasKey(sp => new { sp.StudentId, sp.ProjectId });

            // OneToOne, Map Teacher and Student to User
            builder
                .Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserId);

            builder
                .Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);

            // Teacher courses
            builder
                .Entity<TeacherCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeacherCourses)
                .HasForeignKey(tc => tc.TeacherId);

            builder
                .Entity<TeacherCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeachersCourses)
                .HasForeignKey(tc => tc.CourseId);

            // Teacher Projects
            builder
                .Entity<Teacher>()
                .HasMany(t => t.Projects)
                .WithOne(p => p.Creator)
                .HasForeignKey(p => p.CreatorId);

            // Student courses 
            builder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sp => sp.StudentId);

            builder
                .Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(c => c.CourseId);

            // Student projects
            builder
                .Entity<StudentProject>()
                .HasOne(sp => sp.Student)
                .WithMany(s => s.StudentProjects)
                .HasForeignKey(sp => sp.StudentId);

            builder
                .Entity<StudentProject>()
                .HasOne(sp => sp.Project)
                .WithMany(c => c.StudentProjects)
                .HasForeignKey(c => c.ProjectId);

            // Student Assessment given
            builder
                .Entity<Assessment>()
                .HasOne(a => a.FromStudent)
                .WithMany(s => s.AssessmentsGiven)
                .HasForeignKey(a => a.FromStudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Student Assessment received
            builder
                .Entity<Assessment>()
                .HasOne(a => a.ForStudent)
                .WithMany(s => s.AssessmentsReceived)
                .HasForeignKey(a => a.ForStudentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
