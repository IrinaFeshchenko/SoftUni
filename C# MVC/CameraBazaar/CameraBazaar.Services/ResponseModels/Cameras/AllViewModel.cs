using CameraBazaar.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CameraBazaar.Services.ResponseModels.Cameras
{
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
