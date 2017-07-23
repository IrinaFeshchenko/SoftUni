
namespace PlanetHunters.Models
{
    using CustomValidationAttributes;
    using System.ComponentModel.DataAnnotations;

    public class Planet
    {
        public int Id { get; set; }

        [MaxLength(255),Required]
        public string Name { get; set; }

        [Required]
        [CustomValidation(typeof(PositiveValueValidation), "ValidateGreaterThanZero")]
        public decimal Mass { get; set; }

        //not nullable int = required
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
