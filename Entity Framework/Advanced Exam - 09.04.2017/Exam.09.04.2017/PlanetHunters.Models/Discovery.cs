
namespace PlanetHunters.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Discovery
    {
        public Discovery()
        {
            Stars = new HashSet<Star>();
            Planets = new HashSet<Planet>();
            Pioneers = new HashSet<Astronomer>();
            Observers = new HashSet<Astronomer>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        // not nullable int = required
        public int TelescopeId { get; set; }
        public virtual Telescope Telescope { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> Pioneers { get; set; }

        public virtual ICollection<Astronomer> Observers { get; set; }
    }
}
