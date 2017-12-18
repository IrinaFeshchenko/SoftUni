using Microsoft.AspNetCore.Mvc;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    public class ProjectsController : BaseTeachersController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
