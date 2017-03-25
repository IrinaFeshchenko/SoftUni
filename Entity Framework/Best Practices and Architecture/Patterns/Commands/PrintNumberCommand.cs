
using System;

namespace Patterns.Commands
{
    class PrintNumberCommand : Command
    {
        public PrintNumberCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintNumberCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine(data.MyNumber);
        }
    }
}
