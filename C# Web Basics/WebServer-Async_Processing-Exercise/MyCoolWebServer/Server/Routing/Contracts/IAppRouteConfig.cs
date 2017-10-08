namespace MyCoolWebServer.Server.Routing.Contracts
{
    using System;
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Http.Contracts;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes
        {
            get;
        }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, RequestHandler httpHandler);
    }
}
