namespace _4.Car_Dealer
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarsDBContext : DbContext
    {
        // Your context has been configured to use a 'CarsDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_4.Car_Dealer.CarsDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarsDBContext' 
        // connection string in the application configuration file.
        public CarsDBContext()
            : base("name=CarsDBContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CarsDBContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}