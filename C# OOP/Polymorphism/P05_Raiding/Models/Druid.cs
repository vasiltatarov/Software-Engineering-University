namespace P05_Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
            this.Power = 80;
        }
        
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
    }
}
