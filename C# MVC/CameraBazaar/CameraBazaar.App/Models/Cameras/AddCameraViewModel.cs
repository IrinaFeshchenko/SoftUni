namespace CameraBazaar.App.Models.Cameras
{
    using CameraBazaar.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddCameraViewModel
    {
        public string UserId { get; set; }

        [Required]
        public MakeType Make { get; set; }

        [Required]
        [RegularExpression("[A-Z0-9-]+", ErrorMessage = "Must contain Upper case letters and number only.")]
        public string CameraModel { get; set; }

        public decimal Price { get; set; }

        [Range(minimum: 0, maximum: 100)]
        public int Quantity { get; set; }

        [Display(Name = "Minimum Shutter Speed")]
        [Range(minimum: 1, maximum: 30)]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Maximum Shutter Speed")]
        [Range(minimum: 2000, maximum: 8000)]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Minimum ISO")]
        public MinISOType MinISO { get; set; }

        [Display(Name = "Maximum ISO")]
        [Range(minimum: 200, maximum: 409600)]
        public int MaxISO { get; set; }

        [Display(Name = "Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [Display(Name = "Video Resolution")]
        [StringLength(15)]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public List<LightMeteringType> LightMetering { get; set; } = new List<LightMeteringType>();

        [MaxLength(6000)]
        public string Description { get; set; }

        [Display(Name = "image URL")]
        [RegularExpression("^(http:\\/\\/.*)|(https:\\/\\/.*)", ErrorMessage = "Must start with http:// or https://")]
        public string ImageURL { get; set; }
    }
}
