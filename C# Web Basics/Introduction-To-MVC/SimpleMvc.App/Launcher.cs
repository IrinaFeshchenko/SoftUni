namespace SimpleMvc.App
{
    using SimpleMvcFramework;
    using WebServer;
    using SimpleMvcFramework.Routers;

    public class Launcher
    {
        public static void Main()
        {
            MvcEngine.Run(new WebServer(1337, new ControllerRouter()));
        }
    }
}
