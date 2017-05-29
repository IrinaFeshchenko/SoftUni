namespace _1.Local_Store
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalStoreDBContext : DbContext
    {
        public LocalStoreDBContext()
            : base("name=LocalStoreDBContext")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}