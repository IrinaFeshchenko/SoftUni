namespace MyCoolWebServer.Server.Http.Response
{
    using System.Text;
    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Http.Contracts;

    public abstract class HttpResponse: IHttpResponse
    {
        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }

        public HttpHeaderCollection Headers { get; protected set; }

        public HttpStatusCode StatusCode { get; protected set; }

        private string StatusMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            var response = new StringBuilder();
            var statusCodeNumber = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusMessage}");

            response.AppendLine(this.Headers.ToString());

            response.AppendLine();

            return response.ToString();
        }
    }
}
