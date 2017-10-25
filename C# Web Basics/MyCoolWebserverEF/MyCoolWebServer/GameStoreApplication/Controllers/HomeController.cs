namespace MyCoolWebServer.GameStoreApplication.Controllers
{
    using System;

    using MyCoolWebServer.Server.Http.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest req)
            : base(req)
        {
        }

        public IHttpResponse Index()
        {
            return this.FileViewResponse(@"home/index");
        }

    }
}
