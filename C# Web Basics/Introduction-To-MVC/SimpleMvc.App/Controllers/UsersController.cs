namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.Models.Users;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
             return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!this.IsValidModel(model))
            {
                return View();
            }

            return Redirect("/home/index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            using (var context = new NotesDbContext())
            {
                var foundUser = context.Users.FirstOrDefault(u => u.Username == model.Username);

                if (foundUser == null)
                {
                    return Redirect("/users/login");
                }

                context.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return Redirect("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return Redirect("/users/login");
            }

            Dictionary<int, string> users = new Dictionary<int, string>();

            using (var context = new NotesDbContext())
            {
                users = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.ViewModel["users"] = users.Any() ? string.Join(string.Empty, users
                .Select(u => $@"<li><a href=""/users/profile?id={u.Key}"">{u.Value}</a></li>")) : string.Empty;

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();
            return Redirect("/home/index");
        }
    }
}
