using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class BaseAdminController : Controller
    {
    }
}
