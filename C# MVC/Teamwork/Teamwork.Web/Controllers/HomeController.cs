using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teamwork.Web.Models;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = this.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (user.IsInRole(AdministratorRole))
            {
                return RedirectToAction("Index", "Users", new { Area = "Admin" });
            }

            if (user.IsInRole(TeacherRole))
            {
                return RedirectToAction("Index", "Courses", new { Area = "Teachers" });
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
