using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Admin;
using Teamwork.Services.Teacher;
using Teamwork.Services.Teacher.Models;
using Teamwork.Web.Areas.Teachers.Models.Students;
using Teamwork.Web.Infrastructure.Extensions;
using Teamwork.Web.Infrastructure.Filters;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    public class StudentsController : BaseTeachersController
    {
        private readonly ITeacherStudentService teacherStudentServeice;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public StudentsController(
            ITeacherStudentService teacherStudentServeice,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.teacherStudentServeice = teacherStudentServeice;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string searchTerm = "", int page = 1)
        {
            if (searchTerm == null)
            {
                searchTerm = string.Empty;
            }

            if (!Regex.IsMatch(searchTerm, @"^\s*[A-Za-z0-9.-_]*\s*$"))
            {
                searchTerm = string.Empty;
                TempData.AddErrorMessage("Invalid search characters provided.");
            }
            var teacherId = userManager.GetUserId(HttpContext.User);
            var students = await this.teacherStudentServeice.AllAsync(teacherId, searchTerm, page);

            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            this.HttpContext.Request.QueryString.Add("searchTerm", searchTerm);

            return View(new TeacherStudentsViewMode
            {
                TotalItems = await teacherStudentServeice.TotalAsync(searchTerm),
                students = students,
                SearchTerm = searchTerm,
                CurrentPage = page
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCourse(int courseId, string userId)
        {
            var result = await this.teacherStudentServeice.AddStudentToCourseAsync(courseId, userId);

            if (!result)
            {
                TempData.AddErrorMessage($"Error adding Student to the course");
            }

            TempData.AddSuccessMessage($"Student successfully added to the course");
            return RedirectToAction(nameof(Index));
        }
    }
}
