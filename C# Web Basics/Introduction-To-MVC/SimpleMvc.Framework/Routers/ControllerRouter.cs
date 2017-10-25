namespace SimpleMvc.Framework.Routers
{
    using System.Collections.Generic;

    using WebServer.Contracts;
    using WebServer.Http.Contracts;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParameters = new Dictionary<string, string>(request.UrlParameters);
            this.postParameters = new Dictionary<string, string>(request.FormData);
            this.requestMethod = request.Method.ToString().ToUpper();
            this.prepareControllerAndActionNames(request);

            return null;
        }

        private void prepareControllerAndActionNames(IHttpRequest request)
        {
            var pathParts = request.Path.Split('/', '?');
        }
    }
}
