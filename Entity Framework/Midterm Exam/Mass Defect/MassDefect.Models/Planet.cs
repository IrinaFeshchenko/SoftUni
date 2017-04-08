
namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Planet
    {
        public Planet()
        {
            TeleportedAnomalies = new HashSet<Anomaly>();
            OriginalAnomalies = new HashSet<Anomaly>();
            Persons = new HashSet<Person>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty("OriginPlanet")]
        public virtual ICollection<Anomaly> OriginalAnomalies { get; set; }

        [InverseProperty("TeleportPlanet")]
        public virtual ICollection<Anomaly> TeleportedAnomalies { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        [Required]
        public int SunId { get; set; }
        public virtual Star Sun { get; set; }

        [Required]
        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
    }
}
