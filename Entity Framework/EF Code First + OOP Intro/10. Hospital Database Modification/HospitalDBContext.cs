namespace _10.Hospital_Database_Modification
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalDBContext : DbContext
    {
        // Your context has been configured to use a 'HospitalDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_10.Hospital_Database_Modification.HospitalDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HospitalDBContext' 
        // connection string in the application configuration file.
        public HospitalDBContext()
            : base("name=HospitalDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HospitalDBContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Patient> patients { get; set; }
        public virtual DbSet<Visitation> visitations { get; set; }
        public virtual DbSet<Diagnose> diagnoses { get; set; }
        public virtual DbSet<Medicament> medicaments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}