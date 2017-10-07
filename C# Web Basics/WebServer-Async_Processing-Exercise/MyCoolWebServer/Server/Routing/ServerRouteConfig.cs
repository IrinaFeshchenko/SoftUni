namespace MyCoolWebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            var availableMethods = Enum
                .GetValues(typeof(HttpRequestMethod))
                .Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeRouteConfig(appRouteConfig);
        }

        private void InitializeRouteConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                var requestMethod = registeredRoute.Key;
                var routeWithHandlers = registeredRoute.Value;

                foreach (var routeWithHandler in routeWithHandlers)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;

                    var parameters = new List<string>();

                    var parsedRouteRegex = this.ParseRoute(route, parameters);

                    var routingContext = new RoutingContext(handler, parameters);

                    this.routes[requestMethod].Add(parsedRouteRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string route, List<string> parameters)
        {
            var result = new StringBuilder();
            result.Append("^");

            if (route == "/")
            {
                result.Append("/$");
                return result.ToString();
            }

            var tokens = route.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            this.ParseTokens(tokens, parameters, result);

            return result.ToString();
        }

        private void ParseTokens(string[] tokens, List<string> parameters, StringBuilder result)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var end = (i == tokens.Length - 1) ? "$" : "/";
                var curentToken = tokens[i];
                if (!curentToken.StartsWith('{') && curentToken.EndsWith('}'))
                {
                    result.Append($"{curentToken}{end}");
                    continue;
                }

                var parameterRegex = new Regex("<\\w+>");
                var parameterMatch = parameterRegex.Match(curentToken);

                if (!parameterMatch.Success)
                {
                    throw new InvalidOperationException("Invalid route parameter");
                }

                var match = parameterMatch.Value;
                var parameter = match.Substring(1, match.Length - 2);

                parameters.Add(parameter);

                var tokenWithoutBrackets = curentToken.Substring(1, curentToken.Length -2);
                result.Append($"{tokenWithoutBrackets}{end}");
            }
        }

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;
    }
}
