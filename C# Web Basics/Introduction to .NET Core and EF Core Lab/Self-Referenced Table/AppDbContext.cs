using Microsoft.EntityFrameworkCore;

namespace Self_Referenced_Table
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=COMP\SQLEXPRESS;Database=TestDb;Integrated Security = True;");
        }

        protected internal void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                   .HasMany<Employee>(e => e.Employees)
                   .WithOne(e => e.Manager)
                   .HasForeignKey(e => e.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

