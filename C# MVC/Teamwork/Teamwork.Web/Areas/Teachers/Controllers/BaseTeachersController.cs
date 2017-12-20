using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    [Area("Teachers")]
    [Authorize(Roles = TeacherRole + ", "+ AdministratorRole)]
    public abstract class BaseTeachersController : Controller
    {
    }
}
