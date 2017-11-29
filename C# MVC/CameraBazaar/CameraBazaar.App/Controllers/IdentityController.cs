namespace CameraBazaar.App.Controllers
{
    using System.Linq;
    using CameraBazaar.App.Infrastructure;
    using CameraBazaar.App.Models.Identity;
    using Microsoft.AspNetCore.Mvc;
    using CameraBazaar.Data;
    using Microsoft.AspNetCore.Identity;
    using CameraBazaar.Data.Models;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class IdentityController : Controller
    {
        private readonly CameraBazaarDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityController(CameraBazaarDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var users = this.db
                .Users
                .OrderBy(u => u.Email)
                .Select( u => new ListUserViewModel
                {
                     Id = u.Id,
                     Email = u.Email,
                     UserName = u.UserName,
                })
                .ToList();

            return View(users);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await this.userManager.GetRolesAsync(user);

            return View(new UserWithRolesViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = roles
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await this.userManager.CreateAsync(new Data.Models.User
            {
                Email = model.Email,
                UserName = model.Email,
            }, model.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = $"User with e-mail {model.Email} created!";
                return RedirectToAction(nameof(All));
            }
            else
            {
                AddModelErrors(result);
                return View(model);
            }
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new IdentityChangePasswordViewModel
            {
                Email = user.Email
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, IdentityChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            var result = await this.userManager.ResetPasswordAsync(user, token, model.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = $"Password changed for user {user.Email}";
                return RedirectToAction(nameof(All));
            }
            else
            {
                AddModelErrors(result);
                return View(model);
            }       
        }

        private void AddModelErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(new DeleteUserViewModel
            {
                Id = user.Id,
                Email = user.Email
            });
        }

        public async Task<IActionResult> Destroy(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await this.userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = $"User account for {user.Email} deleted!";
            }
            else
            {
                AddModelErrors(result);
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (user == null || !roleExists)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            TempData["SuccessMessage"] = $"User {user.UserName} aded to role {role}.";

            return RedirectToAction(nameof(All));
        }
    }
}
