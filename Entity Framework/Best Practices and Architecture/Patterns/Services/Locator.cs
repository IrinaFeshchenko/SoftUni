
namespace Patterns.Services
{
    using System.Collections.Generic;
    using System.Configuration;

    public class Locator
    {
        private static Locator instance;
        private Dictionary<string, Logger> services;

        private Locator()
        {
            services = new Dictionary<string, Logger>();
        }

        public static Locator Instance
        {
            get
            {
                if (instance == null) instance = new Locator();
                return instance;
            }
        }


        public void AddService(string name, Logger logger)
        {
            this.services.Add(name, logger);
        }

        public Logger GetService(string name)
        {
            var loggerType = ConfigurationManager.AppSettings["logger"];
            return this.services[loggerType];
        }
    }
}
