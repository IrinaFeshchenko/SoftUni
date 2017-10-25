namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using MyCoolWebServer.GameStoreApplication.Services;
    using MyCoolWebServer.GameStoreApplication.Services.Contracts;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.Server.Http;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;

    public class AccountController : BaseController
    {
        private const string RegisterView = @"account\register";
        private const string LoginView = @"account\login";

        private readonly IUserService users;

        public AccountController(IHttpRequest req)
           : base(req)
        {
            this.users = new UserService();
        }

        // Register Get
        public IHttpResponse Register()
        {
            return this.FileViewResponse(RegisterView);
        }

        // Register Post
        public IHttpResponse Register(RegisterViewModel model)
        {
            // Validate model
            if (!this.ValidateModel(model))
            {
                return this.Register();
            }

            // Create record
            var success = this.users.Create(model.Email, model.FullName, model.Password);
            if (!success)
            {
                this.ShowError("E-mail is taken.");
                return this.Register();
            }

            // Create Session - Log in User
            LoginUser(model.Email);
            return this.RedirectResponse("/");
        }

        // Login Get
        public IHttpResponse Login()
        {
            return this.FileViewResponse(LoginView);
        }

        // Login Post
        public IHttpResponse Login(LoginViewModel model)
        {
            // Validate model
            if (!this.ValidateModel(model))
            {
                return this.Login();
            }

            // Validate User
            bool success = this.users.Find(model.Email, model.Password);
            if (!success)
            {
                this.ShowError("Invalid login details.");
                return this.Login();
            }

            // Log in User
            LoginUser(model.Email);
            return RedirectResponse("/");
        }



        private void LoginUser(string email)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, email);
        }

        public IHttpResponse Logout()
        {
            this.Request.Session.Clear();
            return this.RedirectResponse("/");
        }
    }
}
