namespace MyCoolWebServer.Server.Handlers.Contracts
{
    using MyCoolWebServer.Server.Http.Contracts;

    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext context);
    }
}
