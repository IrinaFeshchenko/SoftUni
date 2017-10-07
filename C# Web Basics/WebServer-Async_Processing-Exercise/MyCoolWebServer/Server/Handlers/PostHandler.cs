namespace MyCoolWebServer.Server.Handlers
{
    using System;
    using MyCoolWebServer.Server.Http.Contracts;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {
        }
    }
}
