namespace P05_Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
