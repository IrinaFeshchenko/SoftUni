
namespace Patterns.Commands
{
    using System;

    public class PrintByeCommand : Command
    {
        public PrintByeCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintByeCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine("bye command");
        }
    }
}
