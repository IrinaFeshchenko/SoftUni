namespace CameraBazaar.App.Services
{
    using System.Collections.Generic;
    using CameraBazaar.App.Models.Cameras;

    public interface ICameraService
    {
        void Add(AddCameraViewModel camera);

        List<AllViewModel> GetAll(string userId = "");

        TDst Map<TSrc, TDst>(TSrc source, TDst dest);

        DetailsViewModel GetDetails(int id);

        SellerCamerasViewModel GetSellerCameras(string sellerId);
    }
}