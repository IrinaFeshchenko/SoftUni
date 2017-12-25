using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teamwork.Data.Models;
using Teamwork.Services.Admin;
using Teamwork.Web.Areas.Admin.Models.Users;
using Teamwork.Web.Infrastructure.Extensions;
using Teamwork.Web.Infrastructure.Filters;
using static Teamwork.Common.GlobalConstants;

namespace Teamwork.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService usersService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            IAdminUserService usersService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.usersService = usersService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string searchTerm = "", int page = 1)
        {          
            if (searchTerm == null)
            {
                searchTerm = string.Empty;
            }

            if (!Regex.IsMatch(searchTerm, @"^\s*[A-Za-z0-9.-_@]*\s*$"))
            {
                searchTerm = string.Empty;
                TempData.AddErrorMessage("Invalid search characters provided.");
            }

            var users = await this.usersService.AllAsync(searchTerm, page);
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            this.HttpContext.Request.QueryString.Add("searchTerm", searchTerm);

            return View(new UserListingsViewModel
            {
                TotalUsers = await usersService.TotalAsync(searchTerm),
                Users = users,
                Roles = roles,
                SearchTerm = searchTerm,
                CurrentPage = page
            });
        }

        [HttpPost]
        [ValidateModelState]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "User or role does not exists.");
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid model state.");
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            // If the profile does not exists create new teacher profile
            if (model.Role == TeacherRole && !usersService.TeacherProfileExists(model.UserId))
            {
                await usersService.CreateTeacherProfile(model.UserId);
            }

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateModelState]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.RemoveFromRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully removed from the {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }
    }
}
