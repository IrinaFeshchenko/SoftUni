namespace MyCoolWebServer.GameStoreApplication
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using MyCoolWebServer.GameStoreApplication.Controllers;
    using MyCoolWebServer.GameStoreApplication.Data;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Account;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class GameStoreApp : IApplication
    {
        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();
            }
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/account/register");
            appRouteConfig.AnonymousPaths.Add("/account/login");
            appRouteConfig.AnonymousPaths.Add("/");

            appRouteConfig
                .Get(
                "/",
                req => new HomeController(req).Index());

            appRouteConfig
                .Get(
                "/account/register",
                req => new AccountController(req).Register());

            appRouteConfig
                .Post(
                "/account/register",
                req => new AccountController(req).Register(
                    new RegisterViewModel
                    {
                            Email = req.FormData["email"],
                            FullName = req.FormData["full-name"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                    }));

            appRouteConfig
                .Get(
                "/account/login",
                req => new AccountController(req).Login());

            appRouteConfig
                .Post(
                "/account/login",
                req => new AccountController(req).Login(
                    new LoginViewModel
                    {
                            Email = req.FormData["email"],
                            Password = req.FormData["password"],
                    }));

            appRouteConfig
                .Get(
                "/account/logout",
                req => new AccountController(req).Logout());

            appRouteConfig
                .Get(
                "/admin/games/add",
                req => new AdminController(req).Add());

            appRouteConfig
                .Post(
                "/admin/games/add",
                req => new AdminController(req).Add(new AdminAddGameViewModel
                                        {
                                            Title = req.FormData["title"],
                                            Description = req.FormData["description"],
                                            Image = req.FormData["thumbnail"],
                                            Price = decimal.Parse(req.FormData["price"]),
                                            ReleaseDate = DateTime.ParseExact(req.FormData["release-date"], "yyyy-MM-dd", null),
                                            Size = double.Parse(req.FormData["size"]),
                                            VideoId = req.FormData["video-id"],
                                        }));

            appRouteConfig
                .Get(
                    "/admin/games/list",
                    req => new AdminController(req).List());
        }
    }
}
