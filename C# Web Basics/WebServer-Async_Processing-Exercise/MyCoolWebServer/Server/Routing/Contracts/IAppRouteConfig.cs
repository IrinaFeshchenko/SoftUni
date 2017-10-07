namespace MyCoolWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Handlers;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes
        {
            get;
        }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}
