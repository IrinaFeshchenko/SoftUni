using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teamwork.Services.Teacher.Models;
using Teamwork.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Teamwork.Services.Teacher;
using Teamwork.Services.Admin;
using Teamwork.Data.Models;
using Teamwork.Web.Areas.Teachers.Models.Courses;

namespace Teamwork.Web.Areas.Teachers.Controllers
{
    public class CoursesController : BaseTeachersController
    {
        private readonly ITeacherCoursesService teacherCourseService;
        protected readonly RoleManager<IdentityRole> roleManager;
        protected readonly UserManager<User> userManager;
        protected readonly IAdminUserService adminUserService;

        public CoursesController(
            UserManager<User> userManager,
            IAdminUserService adminUserService,
            ITeacherCoursesService teacherCourseService,
            RoleManager<IdentityRole> roleManager)
        {
            this.teacherCourseService = teacherCourseService;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.adminUserService = adminUserService;
        }

        // GET Index
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

            var courses = await teacherCourseService.AllAsync(TeacherId(), searchTerm, page);
            var coursesListing = new TeacherCoursesListingViewModel
            {
                TeacherCourses = courses,
                CurrentPage = page,
                SearchTerm = searchTerm,
                TotalItems = await teacherCourseService.TotalAsync(TeacherId(), searchTerm)
            };

            return View(coursesListing);
        }

        // GET Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await teacherCourseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCourseCreateDto course)
        {
            var userId = userManager.GetUserId(User);
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(userId))
            {
                await teacherCourseService.CreateAsync(userId, course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await teacherCourseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherCourseDto course)
        {
            if (ModelState.IsValid)
            {
                var teacherId = userManager.GetUserId(User);
                await teacherCourseService.UpdateAsync(teacherId, course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await teacherCourseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await teacherCourseService.DeleteAsync(TeacherId(), id);
            return RedirectToAction(nameof(Index));
        }

        private string TeacherId()
        {
            return userManager.GetUserId(User);
        }
    }
}
