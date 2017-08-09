using System;

namespace _03BarracksWars.Core.Commands
{
    using _03BarracksWars.Contracts;
    using _03BarracksWars.Core.Commands;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
