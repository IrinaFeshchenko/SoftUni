namespace _03BarracksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            // get class name that matches the command
            var type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.IsClass && t.Namespace == "_03BarracksWars.Core.Commands" && t.Name.ToLower().StartsWith(commandName));
            var command = (IExecutable)Activator.CreateInstance(type,data,repository,unitFactory);
            result = command.Execute();
            return result;
        }
    }
}
