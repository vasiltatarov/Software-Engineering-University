using P07MilitaryElite.Enumerations;

namespace P07MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
