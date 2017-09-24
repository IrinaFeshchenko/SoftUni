namespace Self_Referenced_Table
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=COMP\SQLEXPRESS;Database=TestDb;Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                   .HasMany<Employee>(e => e.Employees)
                   .WithOne(e => e.Manager)
                   .HasForeignKey(e => e.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

