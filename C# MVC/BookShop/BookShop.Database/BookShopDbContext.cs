using BookShop.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Database
{
    public class BookShopDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryBooks> CategoryBooks { get; set; }

        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<CategoryBooks>()
                .HasKey(cb => new { cb.BookId, cb.CategoryId });

            builder
                .Entity<Book>()
                .HasOne(b => b.Autor)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder
                .Entity<Book>()
                .HasMany(b => b.CategoryBooks)
                .WithOne(cb => cb.Book)
                .HasForeignKey(cb => cb.BookId);

            builder
                .Entity<Category>()
                .HasMany(c => c.CategoryBooks)
                .WithOne(cb => cb.Category)
                .HasForeignKey(cb => cb.CategoryId);
        }
    }
}
