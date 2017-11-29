namespace CameraBazaar.App.Services
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using CameraBazaar.App.Models.Cameras;
    using CameraBazaar.App.Infrastructure.Extensions;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        private readonly UserManager<User> userManager;

        public CameraService(CameraBazaarDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public void Add(AddCameraViewModel reqModel)
        {
            // map models
            var camera = new Camera();
            camera = Map(reqModel, camera);
            camera.Model = reqModel.CameraModel;
            camera.LightMetering = (LightMeteringType)reqModel.LightMetering.Select(lm => (int)lm).Sum();

            db.Cameras.Add(camera);
            db.SaveChanges();
        }

        public List<AllViewModel> GetAll(string userId = "" )
        {
            var cameras = db.Cameras.OrderBy(c => c.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                cameras = cameras.Where(c => c.UserId == userId);
            }

            var allCameraModels = new List<AllViewModel>();

            foreach (var camera in cameras.ToList())
            {
                // map models
                var cameraModel = new AllViewModel();
                cameraModel = Map(camera, cameraModel);

                allCameraModels.Add(cameraModel);
            }

            return allCameraModels;
        }

        public DetailsViewModel GetDetails(int id)
        {
            var camera = db.Cameras.Find(id);
            var user = db.Users.Find(camera.UserId);

            var cameraDetails = new DetailsViewModel();
            cameraDetails = Map(camera, cameraDetails);
            cameraDetails.SellerName = user.UserName;
            cameraDetails.CameraModel = camera.Model;
            List<string> lightMetering = new List<string>();

            if (camera.LightMetering.Contains(LightMeteringType.centerWeighted))
            {
                lightMetering.Add("Center Weighted");
            }
            if (camera.LightMetering.Contains(LightMeteringType.evaluative))
            {
                lightMetering.Add("Evaluative");
            }
            if (camera.LightMetering.Contains(LightMeteringType.spot))
            {
                lightMetering.Add("Spot");
            }

            cameraDetails.LightMetering = lightMetering;

            return cameraDetails;
        }

        public SellerCamerasViewModel GetSellerCameras(string sellerId)
        {
            // create the return model
            SellerCamerasViewModel sellerCameras = new SellerCamerasViewModel
            {
                // ger seller cameras
                Cameras = GetAll(sellerId)
            };

            // get seller info
            sellerCameras = Map(db.Users.First(u => u.Id == sellerId), sellerCameras);

            int camerasCount = sellerCameras.Cameras.Count();
            int camerasInStock = sellerCameras.Cameras.Count(c => c.Quantity > 0);
            int camerasOutOfStock = camerasCount - camerasInStock;

            sellerCameras.CamerasStock = $"{camerasInStock} in stock / {camerasOutOfStock} out of stock";

            return sellerCameras;
        }

        public TDst Map<TSrc, TDst>(TSrc source, TDst dest)
        {
            var destProperties = dest.GetType().GetProperties();

            foreach (var destProperty in destProperties)
            {
                try
                {
                    var sourceProperty = source.GetType().GetProperty(destProperty.Name);

                    if (sourceProperty != null)
                    {
                        destProperty.SetValue(dest, sourceProperty.GetValue(source, null), null);
                    }
                }
                catch (System.Exception){}
            }

            return dest;
        }
    }
}
