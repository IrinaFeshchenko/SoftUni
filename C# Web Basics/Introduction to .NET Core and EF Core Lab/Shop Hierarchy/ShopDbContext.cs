namespace Shop_Hierarchy
{
    using Microsoft.EntityFrameworkCore;

    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        
        public DbSet<Salesman> Salesman { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=COMP\SQLEXPRESS;Database=ShopDb;Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Salesman>()
                   .HasMany<Customer>(x => x.Customers)
                   .WithOne(x => x.Salesman)
                   .HasForeignKey(x => x.SalesmanId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            builder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId);
        }
    }
}

