namespace BookShopDB.Data
{
    using Models;
    using System.Data.Entity;

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
