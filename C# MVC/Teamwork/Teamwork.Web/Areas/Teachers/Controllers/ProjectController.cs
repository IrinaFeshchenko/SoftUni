using Microsoft.AspNetCore.Mvc;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    public class ProjectController : BaseTeachersController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
