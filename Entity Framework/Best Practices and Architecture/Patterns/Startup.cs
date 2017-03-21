
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

            MyData data = new MyData()
            {
                MyNumber = 5,
                MyString = "Some data"
            };

            while (true)
            {
                RunCommands(data);
            }
        }

        static void RunCommands(MyData data)
        {


            var parser = new CommandParser();
            Console.WriteLine("Entercommand (greet,bye,exit,increase,print):");
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
