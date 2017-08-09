namespace _03BarracksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().First(t => t.IsClass && t.Namespace == "_03BarracksWars.Models.Units" && t.Name==unitType);
            return (IUnit)Activator.CreateInstance(type);
        }
    }
}
