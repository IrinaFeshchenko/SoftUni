namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System;
    using System.Linq;
    using MyCoolWebServer.GameStoreApplication.Services.Contracts;
    using MyCoolWebServer.GameStoreApplication.ViewModels.Admin;
    using MyCoolWebServer.Server.Http.Contracts;

    public class AdminController : BaseController
    {
        private const string AddGameView = @"admin\add-game";
        private const string ListGamesView = @"admin\list-games";
        private readonly IGameService games;

        public AdminController(IHttpRequest req)
            : base(req)
        {
            this.games = new GameService();
        }

        public IHttpResponse Add()
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            return this.FileViewResponse(AddGameView);
        }

        public IHttpResponse Add(AdminAddGameViewModel model)
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            if (!this.ValidateModel(model))
            {
                return this.Add();
            }

            this.games.Create(model.Title, 
                              model.Description,
                              model.Image,
                              model.Price,
                              model.ReleaseDate.Value,
                              model.Size,
                              model.VideoId);

            return this.List();
        }

        public IHttpResponse List()
        {
            if (!this.Authentication.IsAdmin)
            {
                return this.RedirectResponse(HomePath);
            }

            var gamesList = this.games
                .All()
                .Select(g => $@"<tr><td>{g.Id}</td><td>{g.Name}</td><td>{g.Size:F2} GB</td><td>{g.Price:F2} &euro;</td><td><a class=""btn btn-warning"" href=""/admin/games/edit/{g.Id}"">Edit</a><a class=""btn btn-danger"" href=""/admin/games/delete/{g.Id}"">Delete</a</td></tr>");

            var gamesListAsHtml = string.Join(Environment.NewLine, gamesList);

            this.ViewData["gamesList"] = gamesListAsHtml;

            return this.FileViewResponse(ListGamesView);
        }
    }
}
