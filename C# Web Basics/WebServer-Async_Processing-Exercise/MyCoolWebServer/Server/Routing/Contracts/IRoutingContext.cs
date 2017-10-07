namespace MyCoolWebServer.Server.Routing.Contracts
{
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Handlers;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}
