using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Teamwork.Data.Models;
using Teamwork.Services.Admin;
using Teamwork.Services.Teacher;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    [Area("Teachers")]
    [Authorize(Roles = TeacherRole + ", "+ AdministratorRole)]
    public abstract class BaseTeachersController : Controller
    {
    }
}
