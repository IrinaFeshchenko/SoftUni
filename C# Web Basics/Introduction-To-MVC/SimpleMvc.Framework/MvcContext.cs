namespace SimpleMvc.Framework
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext()
        {
        }

        public static MvcContext Get => instance ?? (instance = new MvcContext());

        public string AssemblyName { get; set; }

        public string Controllersfolder { get; set; } = "Controllers";

        public string ControllersSuffix { get; set; } = "Controller";

        public string Viewsfolder { get; set; } = "Views";

        public string ModelsFolder { get; set; } = "Models";
    }
}
