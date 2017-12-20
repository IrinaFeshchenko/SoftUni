using Microsoft.AspNetCore.Mvc;
using Teamwork.Web.Areas.Students.Controllers;

namespace Teamwork.Web.Areas.Students.Views.Users
{
    public class StudentController : BaseStudentController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
