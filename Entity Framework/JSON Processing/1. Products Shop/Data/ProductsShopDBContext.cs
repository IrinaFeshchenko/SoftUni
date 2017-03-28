namespace _1.Products_Shop
{
    using Models;
    using System.Data.Entity;

    public class ProductsShopDBContext : DbContext
    {
        public ProductsShopDBContext()
            : base("name=ProductsShopDBContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ProductsShopDBContext>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany(f => f.Users)
                .Map( uf =>
                {
                    uf.ToTable("UserFriends");
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FriendId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}