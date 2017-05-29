
namespace Patterns.Commands
{
    using System;

    class ExitCommand : Command
    {
        public ExitCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new ExitCommand(data);
        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
