namespace CameraBazaar.App.Models.Cameras
{
    using System.Collections.Generic;

    public class SellerCamerasViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CamerasStock { get; set; }

        public List<AllViewModel> Cameras { get; set; }
    }
}
