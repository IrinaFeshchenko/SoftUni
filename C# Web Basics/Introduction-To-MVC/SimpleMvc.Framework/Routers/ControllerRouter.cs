namespace SimpleMvcFramework.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using SimpleMvcFramework.Attributes.Methods;
    using SimpleMvcFramework.Contracts;
    using SimpleMvcFramework.Helpers;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Exceptions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private string controllerName;
        private object controllerInstance;
        private string actionName;
        private object[] methodParameters;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParameters = new Dictionary<string, string>(request.UrlParameters);
            this.postParameters = new Dictionary<string, string>(request.FormData);
            this.requestMethod = request.Method.ToString().ToUpper();
            this.prepareControllerAndActionNames(request);
            var methodInfo = this.GetActionForExecution();
            if (methodInfo == null)
            {
                return new NotFoundResponse();
            }

            this.PrepareMethodParameters(methodInfo);

            var actionResult = (IInvocable)methodInfo.Invoke(
                this.GetControllerInstance(), 
                this.methodParameters);

            var content = actionResult.Invoke();

            return new ContentResponse(HttpStatusCode.Ok, content);
        }

        private void PrepareMethodParameters(MethodInfo methodInfo)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();

            this.methodParameters = new object[parameters.Count()];

            int index = 0;
            foreach (var paramether in parameters)
            {
                if (paramether.ParameterType.IsPrimitive ||
                    paramether.ParameterType == typeof(string))
                {
                    object value = this.getParameters[paramether.Name];
                    this.methodParameters[index] = Convert.ChangeType(value, paramether.ParameterType);

                    index++;
                }
                else
                {
                    Type modelType = paramether.ParameterType;
                    object bindingModel = Activator.CreateInstance(modelType);

                    var modelProperites = modelType.GetProperties();

                    foreach (var modelProperty in modelProperites)
                    {
                        modelProperty.SetValue(
                            bindingModel,
                            Convert.ChangeType(this.postParameters[modelProperty.Name], modelProperty.PropertyType));
                    }

                    this.methodParameters[index] = Convert.ChangeType(bindingModel, modelType);

                    index++;
                }
            }
        }

        private MethodInfo GetActionForExecution()
        {
            foreach (var method in this.GetSuitableMethods())
            {
                var httpMethodsAttributes = method
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribure)
                    .Cast<HttpMethodAttribure>();

                if (!httpMethodsAttributes.Any() && this.requestMethod == "GET")
                {
                    return method;
                }

                foreach (var httpMethodAttribute in httpMethodsAttributes)
                {
                    if (httpMethodAttribute.IsValid(this.requestMethod))
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetControllerInstance();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private object GetControllerInstance()
        {
            if (this.controllerInstance != null)
            {
                return this.controllerInstance;
            }

            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.Controllersfolder,
                this.controllerName);

            var controllerType = Type.GetType(controllerFullQualifiedName);

            if (controllerType == null)
            {
                return null;
            }

            this.controllerInstance = Activator.CreateInstance(controllerType);

            return controllerInstance;
        }

        private void prepareControllerAndActionNames(IHttpRequest request)
        {
            var pathParts = request.Path.Split(
                new[] { '/', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            this.controllerName = $"{pathParts[0].Capitalize()}{MvcContext.Get.ControllersSuffix}";
            this.actionName = $"{pathParts[1].Capitalize()}";
        }
    }
}
