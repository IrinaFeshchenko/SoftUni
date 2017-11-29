using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Data.Models
{
    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public MakeType Make { get; set; }

        [Required]
        [RegularExpression("[A-Z00-9-]+")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(minimum:0, maximum:100)]
        public int Quantity { get; set; }

        [Range(minimum:1, maximum:30)]
        public int MinShutterSpeed { get; set; }

        [Range(minimum: 2000, maximum: 8000)]
        public int MaxShutterSpeed { get; set; }

        public MinISOType MinISO { get; set; }

        [Range(minimum: 200, maximum: 409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [StringLength(15)]
        public string VideoResolution { get; set; }

        public LightMeteringType LightMetering { get; set; }

        [MaxLength(6000)]
        public string Description { get; set; }

        [RegularExpression("^(http:\\/\\/.*)|(https:\\/\\/.*)")]
        public string ImageURL { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
