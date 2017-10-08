namespace MyCoolWebServer
{
    using MyCoolWebServer.Application;
    using MyCoolWebServer.Server;
    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing;

    public class Laucher : IRunnable
    {
        public static void Main()
        {
            new Laucher().Run();
        }

        public void Run()
        {
            var mainApplication = new MainApplication();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);
            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
