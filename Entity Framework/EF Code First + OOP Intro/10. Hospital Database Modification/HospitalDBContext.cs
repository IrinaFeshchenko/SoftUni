namespace _10.Hospital_Database_Modification
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Migrations;

    public partial class HospitalDBContext : DbContext
    {
        public HospitalDBContext()
            : base("name=HospitalDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDBContext, Configuration>());
        }

        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }



    }
}
