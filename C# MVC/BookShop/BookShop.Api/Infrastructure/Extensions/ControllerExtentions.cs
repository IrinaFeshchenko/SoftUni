using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Infrastructure.Extensions
{
    public static class ControllerExtentions
    {
        public static IActionResult OkOrNotFound(this Controller controller, object model)
        {
            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.Ok(model);
        }
    }
}
