using CameraBazaar.Services.RequestModels.Camera;
using CameraBazaar.Services.ResponseModels.Cameras;
using System.Collections.Generic;

namespace CameraBazaar.Services
{
    public interface ICameraService
    {
        void Add(AddCameraRequestModel reqModel);

        List<AllViewModel> GetAll();

        DT Map<ST, DT>(ST source, DT dest);

        DetailsViewModel GetDetails(int id);
    }
}
