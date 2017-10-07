namespace MyCoolWebServer.Server.Http.Response
{
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Enums;
    using MyCoolWebServer.Server.Exceptions;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);

            this.view = view;
            this.StatusCode = statusCode;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)this.StatusCode;

            if (299 < statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("response Status code must be < 300 and > 399");
            }
        }
    }
}
