namespace Many_to_Many_Relation
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server = COMP\SQLEXPRESS; Database = TestDb; Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<Student>()
                .HasMany<StudentCourses>(s => s.StudentCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            builder.Entity<Course>()
                .HasMany<StudentCourses>(c => c.StudentCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
