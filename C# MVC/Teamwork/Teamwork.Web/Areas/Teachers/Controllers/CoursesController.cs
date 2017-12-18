using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teamwork.Services.Teacher.Models;
using Teamwork.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Teamwork.Services.Teacher;
using Teamwork.Services.Admin;
using Teamwork.Services.Teacher.Implementations;
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
            IAdminUserService AdminUserService,
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
            if (!Regex.IsMatch(searchTerm, @"^\s*[A-Za-z0-9.-_]*\s*$"))
            {
                searchTerm = string.Empty;
                TempData.AddErrorMessage("Invalid search characters provided.");
            }

            var userId = userManager.GetUserId(User);
            var items = await teacherCourseService.AllAsync(userId, searchTerm, page);
            var listing = new TeacherCoursesListingViewModel
            {
                TeacherCourses = items,
                CurrentPage = page,
                SearchTerm = searchTerm,
                TotalItems = await teacherCourseService.TotalAsync(searchTerm)
            };
            return View(listing);
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
            await teacherCourseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
