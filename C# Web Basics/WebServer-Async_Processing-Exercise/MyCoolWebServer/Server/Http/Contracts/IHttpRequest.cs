namespace MyCoolWebServer.Server.Http.Contracts
{
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Enums;

    public interface IHttpRequest
    {
        Dictionary<string, string> FormData { get; }

        HttpHeaderCollection Headers { get; }

        string Path { get; }

        Dictionary<string, string> QueryParameters { get; }

        HttpRequestMethod Method {get; }

        string Url { get; }

        Dictionary<string, string> UrlParameters { get; }

        void AddUrlParameters(string key, string value);
    }
}
