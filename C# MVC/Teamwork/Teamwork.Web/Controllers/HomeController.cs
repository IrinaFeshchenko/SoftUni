using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teamwork.Web.Models;
using static Teamwork.Web.WebConstants;

namespace Teamwork.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = this.HttpContext.User;

            if (user.IsInRole(AdministratorRole))
            {
                return RedirectToAction("Index", new { Area = "Admin" });
            }

            if (user.IsInRole(TeacherRole))
            {
                return RedirectToAction("Index", new { Area = "Teachers" });
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
