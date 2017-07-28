using System.Collections.Generic;

namespace Military_Elite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IList<IRepair> Parts { get; }
    }
}