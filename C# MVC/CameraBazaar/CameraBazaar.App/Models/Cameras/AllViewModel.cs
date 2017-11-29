namespace CameraBazaar.App.Models.Cameras
{
    using CameraBazaar.Data.Models;

    public class AllViewModel
    {
        public int Id { get; set; }

        public MakeType Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageURL { get; set; }
    }
}
