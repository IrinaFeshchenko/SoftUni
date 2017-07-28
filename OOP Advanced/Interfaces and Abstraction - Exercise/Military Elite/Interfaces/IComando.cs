using System.Collections.Generic;

namespace Military_Elite
{
    public interface IComando : ISpecialisedSoldier
    {
        IList<IMission> Missions { get; }

        void CompleteMission();
    }
}