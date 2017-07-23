
namespace PlanetHunters.Models
{
    using CustomValidationAttributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Telescope
    {
        public Telescope()
        {
            Discoveries = new HashSet<Discovery>();
        }
        public int Id { get; set; }

        [MaxLength(255),Required]
        public string Name { get; set; }

        [MaxLength(255), Required]
        public string Location { get; set; }

        [CustomValidation(typeof(PositiveValueValidation), "ValidateGreaterThanZero")]
        public decimal? MirrorDiameter { get; set; }

        public virtual  ICollection<Discovery> Discoveries { get; set; }
    }
}
