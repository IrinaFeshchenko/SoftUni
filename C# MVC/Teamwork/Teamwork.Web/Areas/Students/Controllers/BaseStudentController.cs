using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Teamwork.Web.Areas.Students.Controllers
{
    [Area("Students")]
    [Authorize]
    public abstract class BaseStudentController : Controller
    {
    }
}