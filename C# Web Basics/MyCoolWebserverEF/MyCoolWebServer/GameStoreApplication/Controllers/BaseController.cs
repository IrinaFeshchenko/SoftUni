namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using GameStoreApplication.Services;
    using GameStoreApplication.Services.Contracts;
    using Infrastructure;
    using MyCoolWebServer.GameStoreApplication.Common;
    using Server.Http;
    using Server.Http.Contracts;

    public class BaseController : Controller
    {
        protected const string HomePath = "/";
        protected readonly IHttpRequest Request;
        private readonly IUserService users;

        public BaseController(IHttpRequest req)
        {
            this.Request = req;
            this.users = new UserService();
            this.Authentication = new Authentication(false, false);
            this.ApplyAuthentication();
        }

        protected Authentication Authentication { get; private set; }

        protected override string ApplicationDirectory => "GameStoreApplication";

        private void ApplyAuthentication()
        {
            var anonymousDisplay = "flex";
            var authDisplay = "none";
            var adminDisplay = "none";

            var authenticatedUserEmail = Request.Session.Get<string>(SessionStore.CurrentUserKey);

            if (authenticatedUserEmail != null)
            {
                anonymousDisplay = "none";
                authDisplay = "flex";

                var isAdmin = this.users.IsAdmin(authenticatedUserEmail);

                if (isAdmin)
                {
                    adminDisplay = "flex";
                }

                this.Authentication = new Authentication(true, isAdmin);
            }

            this.ViewData["anonymousDisplay"] = anonymousDisplay;
            this.ViewData["authDisplay"] = authDisplay;
            this.ViewData["adminDisplay"] = adminDisplay;
        }
    }
}
