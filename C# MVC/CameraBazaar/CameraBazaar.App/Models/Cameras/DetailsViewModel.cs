namespace CameraBazaar.App.Models.Cameras
{
    using CameraBazaar.Data.Models;
    using System.Collections.Generic;

    public class DetailsViewModel
    {
        public string SellerName { get; set; }

        public string UserId { get; set; }

        public MakeType Make { get; set; }

        public string CameraModel { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int MinShutterSpeed { get; set; }

        public int MaxShutterSpeed { get; set; }

        public MinISOType MinISO { get; set; }

        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        public string VideoResolution { get; set; }

        public List<string> LightMetering { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
