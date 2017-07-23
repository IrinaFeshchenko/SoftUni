namespace PlanetHunters.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // many to many astronomers discoveries --------------
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneerDiscoveries)
                .WithMany(p => p.Pioneers)
           .Map(pa =>
           {
               pa.ToTable("PioneerAstronomerDiscovery");
               pa.MapLeftKey("PioneerAstronomerId");
               pa.MapRightKey("PioneerDiscoveryId");
           });

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObserveDiscoveries)
                .WithMany(p => p.Observers)
            .Map(pa =>
            {
               pa.ToTable("ObserveAstronomerDiscovery");
               pa.MapLeftKey("ObserveAstronomerId");
               pa.MapRightKey("ObserveDiscoveryId");
            });

            //one to many ------------------------------------
            modelBuilder.Entity<Discovery>()
                .HasRequired(d => d.Telescope)
                .WithMany(t => t.Discoveries)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Stars)
                .WithOptional(s => s.Discovery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Planets)
                .WithOptional(s => s.Discovery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StarSystem>()
                .HasMany(d => d.Stars)
                .WithRequired(s => s.StarSystem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StarSystem>()
                .HasMany(d => d.Planets)
                .WithRequired(s => s.StarSystem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Telescope>().Property(p => p.MirrorDiameter).IsOptional();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Didscoveries { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
    }
}