namespace SimpleMvc.App.Controllers
{
    using System;
    using SimpleMvc.App.Models;
    using SimpleMvcFramework.Attributes.Methods;
    using SimpleMvcFramework.Contracts;
    using SimpleMvcFramework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IndexModel model)
        {
            return View();
        }
    }
}
