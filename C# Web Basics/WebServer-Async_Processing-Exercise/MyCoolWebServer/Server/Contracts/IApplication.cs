namespace MyCoolWebServer.Server.Contracts
{
    using MyCoolWebServer.Server.Routing.Contracts;

    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}
