namespace MyCoolWebServer.Server.Handlers
{
    using System;
    using System.Text.RegularExpressions;

    using MyCoolWebServer.Server.Handlers.Contracts;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Http.Response;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class HttpHandler : IRequestHandler
    {
        private IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig routeConfig)
        {
            this.serverRouteConfig = routeConfig;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var requestMethod = context.Request.Method;
            var requestPath = context.Request.Path;
            var registeredRoutes = this.serverRouteConfig.Routes[requestMethod];

            foreach (var registeredRoute in registeredRoutes)
            {
                var routePattern = registeredRoute.Key;
                var routingContext = registeredRoute.Value;

                var routeRegex = new Regex(routePattern);
                var match = routeRegex.Match(requestPath);

                if (!match.Success)
                {
                    continue;
                }

                var parameters = routingContext.Parameters;
                foreach (var parameter in parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;
                    context.Request.AddUrlParameters(parameter, parameterValue);
                }

                return routingContext.Handler.Handle(context);
            }

            return new NotFoundResponse();
        }
    }
}
