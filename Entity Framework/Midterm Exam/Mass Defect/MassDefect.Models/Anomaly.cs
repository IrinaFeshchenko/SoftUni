
namespace MassDefect.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Anomaly
    {
        public Anomaly()
        {
            Persons = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("OriginPlanet")]
        public int OriginPlanetId { get; set; }
        public virtual Planet OriginPlanet { get; set; }

        [ForeignKey("TeleportPlanet")]
        public int TeleportPlanetId { get; set; }
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
