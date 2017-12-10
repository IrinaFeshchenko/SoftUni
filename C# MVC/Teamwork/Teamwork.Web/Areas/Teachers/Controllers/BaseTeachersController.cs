using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Teamwork.Web.WebConstants;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    [Area("Teachers")]
    [Authorize(Roles = TeacherRole)]
    public class BaseTeachersController : Controller
    {
    }
}
