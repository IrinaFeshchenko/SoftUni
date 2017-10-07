namespace MyCoolWebServer.Server.Http.Contracts
{
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        HttpHeaderCollection Headers { get; }
    }
}
