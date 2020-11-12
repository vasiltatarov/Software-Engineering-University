namespace Skeleton.Models.Contracts
{
    public interface IWeapon
    {
        int DurabilityPoints { get; }

        int AttackPoints { get; }

        void Attack(ITarget target);
    }
}
