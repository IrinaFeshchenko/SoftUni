namespace MyCoolWebServer.Server.Http
{
    using System;
    using System.Collections.Generic;

    using MyCoolWebServer.Server.Common;

    public class HttpCookie
    {
        private readonly IDictionary<string, IEnumerable<HttpHeader>> headers;

        public HttpCookie()
        {
            this.headers = new Dictionary<string, IEnumerable<HttpHeader>>();
        }

        public HttpCookie(string key, string value, int expires = 3)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = 3)
            : this(key, value, expires)
        {
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; private set; } = true;

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";
        }
    }
}
