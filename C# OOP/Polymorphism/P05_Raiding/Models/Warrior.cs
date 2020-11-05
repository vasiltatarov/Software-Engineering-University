namespace P05_Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
