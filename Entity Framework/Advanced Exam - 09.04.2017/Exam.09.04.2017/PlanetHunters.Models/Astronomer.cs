
namespace PlanetHunters.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Astronomer
    {
        public Astronomer()
        {
            PioneerDiscoveries = new HashSet<Discovery>();
            ObserveDiscoveries = new HashSet<Discovery>();
        }

        public int Id { get; set; }

        [MaxLength(50),Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        public virtual ICollection<Discovery> PioneerDiscoveries { get; set; }

        public virtual ICollection<Discovery> ObserveDiscoveries { get; set; }
    }
}
