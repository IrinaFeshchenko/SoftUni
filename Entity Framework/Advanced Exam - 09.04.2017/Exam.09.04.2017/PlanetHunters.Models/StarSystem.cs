
namespace PlanetHunters.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class StarSystem
    {
        public StarSystem()
        {
            Stars = new HashSet<Star>();
            Planets = new HashSet<Planet>();
        }
        public int Id { get; set; }

        [MaxLength(255),Required]
        public string Name { get; set; }
    
        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}