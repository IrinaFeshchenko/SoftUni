namespace MyCoolWebServer.Server.Http.Response
{
    using System.Text;

    using MyCoolWebServer.Server.Common;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Http.Contracts;

    public abstract class HttpResponse: IHttpResponse
    {
        private readonly IView view;


        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }

        protected HttpResponse(string redirectUrl)
            : this()
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));
            this.StatusCode = HttpStatusCode.Found;
            this.Headers.Add(new HttpHeader("Location", redirectUrl));
        }

        protected HttpResponse(HttpStatusCode statusCode, IView view)
            : this()
        {
            this.view = view;
            this.StatusCode = statusCode;
        }


        public HttpHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        private string StatusMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            var response = new StringBuilder();
            var statusCodeNumber = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusMessage}");

            response.AppendLine(this.Headers.ToString());

            response.AppendLine();

            if (statusCodeNumber < 300 || statusCodeNumber > 399)
            {
                response.AppendLine(this.view.View());
            }

            return response.ToString();
        }
    }
}
