namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using Infrastructure;
    using MyCoolWebServer.ByTheCakeApplication.Services;
    using MyCoolWebServer.ByTheCakeApplication.ViewModels.Account;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using ViewModels;

    public class AccountController : BaseController
    {
        private readonly IUserService users;

        private const string RegisterView = @"account\register";

        private const string LoginView = @"account\login";

        public AccountController()
        {
            this.users = new UserService();
        }

        public IHttpResponse Register()
        {
            this.SetDefaultViewData();
            return this.FileViewResponse(RegisterView);
        }

        public IHttpResponse Register(IHttpRequest req, RegisterUserViewModel model)
        {
            this.SetDefaultViewData();

            // Validate the model
            if (model.Usernrame.Length < 3 
                || model.Password.Length < 3
                || model.ConfirmPassword != model.Password)
            {
                this.ShowError("Invalid user details");

                return this.FileViewResponse(RegisterView);
            }

            var success = users.Create(model.Usernrame, model.Password);

            if (success)
            {
                this.LoginUser(req, model.Usernrame);
                return new RedirectResponse("/");
            }
            else
            {
                this.ShowError("This username is taken");
                return this.FileViewResponse(RegisterView);
            }
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            if (!req.Session.Contains(SessionStore.CurrentUserKey))
            {
                throw new InvalidOperationException("There is no logged in user.");
            }

            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);

            var profile = this.users.Profile(username);

            if (profile == null)
            {
                throw new InvalidOperationException($"The user {username} could not be found in the database");
            }

            this.ViewData["username"] = profile.Username;
            this.ViewData["registrationDate"] = profile.RegistrationDate.ToShortDateString();
            this.ViewData["totalOrders"] = profile.TotalOrders.ToString();

            return this.FileViewResponse(@"account\profile");
        }

        public IHttpResponse Login()
        {
            this.SetDefaultViewData();
            return this.FileViewResponse(LoginView);
        }

        public IHttpResponse Login(IHttpRequest req, LoginViewModel model)
        {
            this.SetDefaultViewData();

            if (string.IsNullOrWhiteSpace(model.Usernrame)
                || string.IsNullOrWhiteSpace(model.Password))
            {
                this.ShowError("You have empty fields");

                return this.FileViewResponse(LoginView);
            }

            var success = this.users.FindUser(model.Usernrame, model.Password);

            if (success)
            {
                this.LoginUser(req, model.Usernrame);

                return new RedirectResponse("/");
            }
            else
            {
                this.ShowError("Invalid user details");
                return this.FileViewResponse(LoginView);
            }
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        private void SetDefaultViewData()
        {
            this.ViewData["authDisplay"] = "none";
        }

        private void LoginUser(IHttpRequest req, string username)
        {
            req.Session.Add(SessionStore.CurrentUserKey, username);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }
    }
}
