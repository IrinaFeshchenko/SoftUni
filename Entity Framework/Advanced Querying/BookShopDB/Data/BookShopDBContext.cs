namespace _1.Books_Titles_by_Age_Restriction
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookShopDBContext : DbContext
    {
        public BookShopDBContext()
            : base("name=BookShopDBContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("CategoryBooks"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Books1)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("RelatedBooks").MapLeftKey("BookId").MapRightKey("RelatedId"));
        }
    }
}
