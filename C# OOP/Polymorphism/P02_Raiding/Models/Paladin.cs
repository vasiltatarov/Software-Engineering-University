namespace P05_Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
