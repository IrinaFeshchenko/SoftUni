namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using MyCoolWebServer.Infrastructure;

    public abstract class BaseController : Controller
    {
        protected override string ApplicationDirectory => "ByTheCakeApplication";
    }
}
