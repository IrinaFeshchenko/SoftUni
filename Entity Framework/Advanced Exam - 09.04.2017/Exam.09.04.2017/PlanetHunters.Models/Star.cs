
namespace PlanetHunters.Models
{
    using CustomValidationAttributes;
    using System.ComponentModel.DataAnnotations;
    public class Star
    {
        public int Id { get; set; }

        [Required,MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [CustomValidation(typeof(TemperatureValidation), "ValidateTemperature")]
        public int Temperature { get; set; }

        //not nullable int = required
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
