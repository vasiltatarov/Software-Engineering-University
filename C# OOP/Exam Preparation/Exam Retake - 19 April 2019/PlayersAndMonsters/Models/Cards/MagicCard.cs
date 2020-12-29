namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int Damage = 5;
        private const int Health = 80;

        public MagicCard(string name) 
            : base(name, Damage, Health)
        {
        }
    }
}
