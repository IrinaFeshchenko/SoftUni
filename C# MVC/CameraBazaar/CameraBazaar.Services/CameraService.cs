using CameraBazaar.Services.RequestModels.Camera;
using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using CameraBazaar.Services.ResponseModels.Cameras;
using System.Collections.Generic;

namespace CameraBazaar.Services
{
    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        private readonly UserManager<User> userManager;

        public CameraService(CameraBazaarDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public void Add(AddCameraRequestModel reqModel)
        {
            // map models
            var camera = new Camera();
            camera = Map<AddCameraRequestModel, Camera>(reqModel, camera);
            camera.Model = reqModel.CameraModel;
            camera.LightMetering = (LightMeteringType)reqModel.LightMetering.Select(lm => (int)lm).Sum();

            db.Cameras.Add(camera);
            db.SaveChanges();
        }

        public List<AllViewModel> GetAll()
        {
            var cameras = db.Cameras.OrderBy(c => c.Id)
                            .ToList();
            var allCameraModels = new List<AllViewModel>();

            foreach (var camera in cameras)
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

            return cameraDetails;
        }

        public DT Map<ST,DT>(ST source, DT dest)
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
