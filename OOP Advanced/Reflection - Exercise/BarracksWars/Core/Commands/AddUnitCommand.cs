using System;
namespace _03BarracksWars.Core.Commands
{
    using _03BarracksWars.Contracts;

    public class AddUnitCommand : Command
    {
        public AddUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
