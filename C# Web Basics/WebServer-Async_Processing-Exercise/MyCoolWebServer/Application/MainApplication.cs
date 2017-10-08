namespace MyCoolWebServer.Application
{
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());

            appRouteConfig.Get("/users/{(?<name>[a-z]+)}", req => new HomeController().Index());
        }
    }
}
