namespace SimpleMvcFramework.Controllers
{
    using System.Runtime.CompilerServices;
    using SimpleMvcFramework.Contracts;
    using SimpleMvcFramework.Contracts.Generic;
    using SimpleMvcFramework.Helpers;
    using SimpleMvcFramework.ViewEngine;
    using SimpleMvcFramework.ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string fullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = ControllerHelpers.GetFullQualifiedName(controller, action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string fullQualifiedName = ControllerHelpers.GetFullQualifiedName(controllerName, caller);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            string fullQualifiedName = ControllerHelpers.GetFullQualifiedName(controller, action);

            return new ActionResult<TModel>(fullQualifiedName, model);
        }
    }
}
