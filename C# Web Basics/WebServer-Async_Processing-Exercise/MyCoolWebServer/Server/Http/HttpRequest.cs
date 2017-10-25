namespace MyCoolWebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using MyCoolWebServer.Server.Common;
    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Exceptions;
    using MyCoolWebServer.Server.Http.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestText)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

            this.FormData = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestText);
        }

        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameters(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        // Parse the string Request: Split to lines: get parameters from lines
        // first   Line: [Method] [URL?[Parameters]] [Protocol]
        // Header Lines: [Key:Value]
        // Last    Line: Empty
        private void ParseRequest(string requestText)
        {
            // Split to lines
            var requestLines = requestText.Split(Environment.NewLine);

            // If no lines throw exception
            if (!requestLines.Any())
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            // Parse and validate the first line
            var requestLine = requestLines.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            this.Method = this.ParseMethod(requestLine.First());
            this.Url = requestLine[1];
            this.Path = this.ParsePath(this.Url);
            this.ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines.Last());
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.Method == HttpRequestMethod.Get)
            {
                return;
            }

            this.ParseQuery(formDataLine, this.QueryParameters);
        }

        // Parse the url parameters: from the parts after '?' in the URL
        private void ParseParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var query = this.Url
                .Split('?', StringSplitOptions.RemoveEmptyEntries)
                .Last();

            this.ParseQuery(query, this.UrlParameters);
        }

        // Parse the headers: KVP Pairs, from the second line untill empty space
        private void ParseHeaders(string[] requestLines)
        {
            foreach (var line in requestLines.Skip(1))
            {
                if (line == string.Empty)
                {
                    break;
                }

                var headerParts = line.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                if (headerParts.Length != 2)
                {
                    BadRequestException.ThrowFromInvalidRequest();
                }
                var headerKey = headerParts[0];
                var headerValue = headerParts[1].Trim();

                this.Headers.Add(new HttpHeader(headerKey,headerValue));
            }

            if (!this.Headers.ContainsKey("Host"))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }
        }

        // Get the request method: 'Get' or 'Post',from the first part of the first line 
        private HttpRequestMethod ParseMethod(string method)
        {
            HttpRequestMethod parsedMethod;
            if (!Enum.TryParse(method, true, out parsedMethod))
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            return parsedMethod;
        }

        private string ParsePath(string url)
        {
            return url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseQuery(string query, Dictionary<string,string> dic)
        {
            if (!query.Contains('='))
            {
                return;
            }

            var queryPairs = query.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in queryPairs)
            {
                var queryKvp = pair.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (queryKvp.Length != 2)
                {
                    continue;
                }

                var key = WebUtility.UrlDecode(queryPairs[0]);
                var value = WebUtility.UrlDecode(queryPairs[1]);

                dic.Add(key, value);
            }
        }
        
        private void ParseCookie()
        {
            if (this.Headers.ContainsKey("Cookie"))
            {
                var allCookies = this.Headers.Get("Cookies");

                foreach (var cookie in allCookies)
                {
                    var parts = cookie.Value.Split(';', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

                    if (parts == null || !parts.Contains("="))
                    {
                        continue;
                    }

                    var kvp = parts.Split('=', StringSplitOptions.RemoveEmptyEntries);

                    if (kvp.Length == 2)
                    {
                        var key = kvp[0];
                        var value = kvp[1];
                    }
                }
            }
        }
    }
}
