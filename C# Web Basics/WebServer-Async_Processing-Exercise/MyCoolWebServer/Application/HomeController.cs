namespace MyCoolWebServer.Application
{
    using MyCoolWebServer.Application.Views.Home;
    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;

    public class HomeController
    {
        // GET /
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.Ok, new IndexView());
        }
    }
}
