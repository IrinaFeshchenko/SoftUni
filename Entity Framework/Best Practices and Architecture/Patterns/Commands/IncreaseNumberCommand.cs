
namespace Patterns.Commands
{
    using System;

    class IncreaseNumberCommand : Command
    {
        public IncreaseNumberCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new IncreaseNumberCommand(data);
        }

        public override void Execute()
        {
            this.data.MyNumber++;
        }
    }
}
