namespace SimpleMvc.App
{
    using SimpleMvc.Framework;
    using WebServer;
    using SimpleMvc.Framework.Routers;

    public class Launcher
    {
        public static void Main()
        {
            MvcEngine.Run(new WebServer(1337, new ControllerRouter(), new ResourceRouter()));
        }
    }
}
