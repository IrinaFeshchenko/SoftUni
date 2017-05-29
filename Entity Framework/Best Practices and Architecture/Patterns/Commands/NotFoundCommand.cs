
namespace Patterns.Commands
{
    using System;

    public class NotFoundCommand : Command
    {
        public NotFoundCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new NotFoundCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine("Command not found");
        }
    }
}
