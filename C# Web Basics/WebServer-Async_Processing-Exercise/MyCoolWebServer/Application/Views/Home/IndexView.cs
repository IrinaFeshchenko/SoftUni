namespace MyCoolWebServer.Application.Views.Home
{
    using MyCoolWebServer.Server.Contracts;

    public class IndexView : IView
    {
        public string View() => "<h1>Wellcome!</h1>";
    }
}
