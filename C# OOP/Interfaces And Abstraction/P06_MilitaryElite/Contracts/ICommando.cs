using System.Collections.Generic;

namespace P07MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
