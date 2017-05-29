namespace MassDefect.Data
{
    using Models;
    using System.Data.Entity;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
           .HasMany(a => a.Persons)
           .WithMany(p => p.Anomalies)
           .Map(pa =>
           {
               pa.ToTable("AnomalyVictims");
               pa.MapLeftKey("AnomalyId");
               pa.MapRightKey("PersonId");
           });

            modelBuilder.Entity<Planet>()
                .HasMany(p => p.OriginalAnomalies)
                .WithRequired(a => a.OriginPlanet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planet>()
                .HasMany(p => p.TeleportedAnomalies)
                .WithRequired(a => a.TeleportPlanet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Star>()
                .HasMany(p => p.Planets)
                .WithRequired(a => a.Sun)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Anomaly> Anomalies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
    }
}