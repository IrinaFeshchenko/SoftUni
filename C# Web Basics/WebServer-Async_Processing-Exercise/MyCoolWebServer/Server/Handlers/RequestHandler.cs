namespace MyCoolWebServer.Server.Handlers
{
    using System;
    using MyCoolWebServer.Server.Common;
    using MyCoolWebServer.Server.Handlers.Contracts;
    using MyCoolWebServer.Server.Http.Contracts;

    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
        {
            CoreValidator.ThrowIfNull(handlingFunc, nameof(handlingFunc));
            this.handlingFunc = handlingFunc;
        }

        public IHttpResponse Handle(IHttpContext context)
        {
            var response = this.handlingFunc(context.Request);

            response.Headers.Add(new Http.HttpHeader("Content-Type", "text/html"));

            return response;
        }
    }
}
