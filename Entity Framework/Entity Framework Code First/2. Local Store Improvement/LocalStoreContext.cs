namespace _2.Local_Store_Improvement
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("name=LocalStoreContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}