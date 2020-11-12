using Skeleton.Models.Contracts;

public class Hero
{
    public Hero(string name, IWeapon weapon)
    {
        this.Name = name;
        this.Weapon = weapon;
        this.Experience = 0;
    }

    public string Name { get; private set; }

    public int Experience { get; private set; }

    public IWeapon Weapon { get; private set; }

    public void Attack(ITarget target)
    {
        this.Weapon.Attack(target);

        if (target.IsDead())
        {
            this.Experience += target.GiveExperience();
        }
    }
}
