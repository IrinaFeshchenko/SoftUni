namespace MyCoolWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Enums;

    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}
