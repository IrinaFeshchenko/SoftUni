using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Teacher;
using Teamwork.Web.Areas.Teachers.Models.Students;
using Teamwork.Web.Infrastructure.Extensions;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    public class StudentsController : BaseTeachersController
    {
        private readonly ITeacherStudentsService teacherStudentServeice;
        ITeacherCoursesService teacherCourseService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public StudentsController(
            ITeacherStudentsService teacherStudentServeice,
            ITeacherCoursesService teacherCourseService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.teacherStudentServeice = teacherStudentServeice;
            this.teacherCourseService = teacherCourseService;
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

            var teacherCourses = teacherCourseService
                .AllAsync(TeacherId(), "", 1).Result
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()
                })
                .ToList();

            this.HttpContext.Request.QueryString.Add("searchTerm", searchTerm);

            return View(new TeacherStudentsViewModel
            {
                Courses = teacherCourses,
                TotalItems = await teacherStudentServeice.TotalAsync(searchTerm),
                Students = students,
                SearchTerm = searchTerm,
                CurrentPage = page
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCourse(string studentId, string courseId)
        {
            int id = -1;
            int.TryParse(courseId, out id);

            var result = await this.teacherStudentServeice.AddStudentToCourseAsync(studentId, id);

            if (!result)
            {
                TempData.AddErrorMessage($"Error adding Student to the course");
            }
            else
            {
                TempData.AddSuccessMessage($"Student successfully added to the course");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCourse(string studentId, string courseId)
        {
            int id = -1;
            int.TryParse(courseId, out id);

            var result = await this.teacherStudentServeice.RemoveStudentFromCourseAsync(studentId, id);

            if (!result)
            {
                TempData.AddErrorMessage($"Error removing Student from the course");
            }
            else
            {
                TempData.AddSuccessMessage($"Student successfully removed from the course");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private string TeacherId()
        {
            return userManager.GetUserId(User);
        }
    }
}
