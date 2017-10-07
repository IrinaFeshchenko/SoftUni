namespace MyCoolWebServer.Server.Handlers
{
    using System;

    using MyCoolWebServer.Server.Http.Contracts;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {
        }
    }
}
