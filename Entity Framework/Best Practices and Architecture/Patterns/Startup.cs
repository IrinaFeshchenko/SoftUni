
namespace Patterns
{
    using Commands;
    using Services;
    using System;

    class Startup
    {
        static void Main()
        {
            //RunServices();

            var parser = new CommandParser();
            MyData data = new MyData()
            {
                MyNumber = 5,
                MyString = "Some data"
            };

            while (true)
            {
                RunCommands(parser,data);
            }
        }

        static void RunCommands(CommandParser parser, MyData data)
        {         
            Console.WriteLine("Entercommand (greet,bye,exit,increase,print,report):");
            var cmd = parser.Parse(Console.ReadLine(),data);

            cmd.Execute();
        }

        static void RegisterServices()
        {
            Locator.Instance.AddService("console", new ConsoleLogger());
            Locator.Instance.AddService("decorated", new DecoratedLogger());
        }

        static void RunServices()
        {
            string mystring = "Hello service locator!";
            RegisterServices();

            var logger = Locator.Instance.GetService("consolee");
            logger.Log(mystring);
        }
    }
}
