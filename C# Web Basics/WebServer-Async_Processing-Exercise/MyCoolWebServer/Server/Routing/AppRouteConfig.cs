namespace MyCoolWebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> routes;

        public void Get(string route, Func<IHttpRequest,IHttpResponse> handler)
        {
            this.AddRoute(route, new GetHandler(handler));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, new PostHandler(handler));
        }

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, RequestHandler>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler handler)
        {
            var handlerName = handler.GetType().Name.ToLower();

            if (handlerName.Contains("get"))
            {
                this.routes[HttpRequestMethod.Get].Add(route, handler);
            }
            else if (handlerName.Contains("post"))
            {
                this.routes[HttpRequestMethod.Post].Add(route, handler);
            }
            else
            {
                throw new InvalidOperationException("Invalid handler.");
            }
        }
    }
}
