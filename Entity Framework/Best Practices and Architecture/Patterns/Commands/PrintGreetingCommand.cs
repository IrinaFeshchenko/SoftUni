
namespace Patterns.Commands
{
    using System;

    public class PrintGreetingCommand : Command
    {
        public PrintGreetingCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintGreetingCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine("print greetings command");
        }
    }
}
