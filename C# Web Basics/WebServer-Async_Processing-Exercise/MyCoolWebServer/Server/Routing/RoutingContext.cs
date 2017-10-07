namespace MyCoolWebServer.Server.Routing
{
    using System.Collections.Generic;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            this.Parameters = parameters;
            this.Handler = handler;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set; }
    }
}
