namespace CameraBazaar.App.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Diagnostics;
    using System.IO;

    public class MeasureTimeAttribute : IActionFilter
    {
        private Stopwatch stopWatch = new Stopwatch();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopWatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan elapsedTime = stopWatch.Elapsed;
            var dateTime = DateTime.UtcNow;
            var controller = context.Controller.GetType().Name;
            var action = context.RouteData.Values["action"];

            var logMessage = $"{dateTime} - {controller}.{action} - {elapsedTime}";

            using (var writer = new StreamWriter("action-times.txt", true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
