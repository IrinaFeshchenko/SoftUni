namespace CameraBazaar.App.Controllers
{
    using CameraBazaar.App.Models.Cameras;
    using CameraBazaar.Data.Models;
    using CameraBazaar.App.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CamerasController : Controller
    {
        private readonly ICameraService cameraService;

        private readonly UserManager<User> userManager;

        public CamerasController(ICameraService cameraService, UserManager<User> userManager)
        {
            this.cameraService = cameraService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCameraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.UserId = userManager.GetUserId(User);

            cameraService.Add(model);

            return RedirectToAction("/home");
        }

        [Authorize]
        public IActionResult All()
        {
            var allCameras = cameraService.GetAll();
            return View(allCameras);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var details = cameraService.GetDetails(id);
            return View(details);
        }

        [Authorize]
        public IActionResult Seller(string id)
        {
            var sellerCameras = cameraService.GetSellerCameras(id);

            return View(sellerCameras);
        }
    }
}
