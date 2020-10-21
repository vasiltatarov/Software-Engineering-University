using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private HashSet<Hero> data;

        public HeroRepository()
        {
            this.data = new HashSet<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public bool Remove(string name)
        {
            var found = this.data.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                this.data.Remove(found);
                return true;
            }

            return false;
        }

        public Hero GetHeroWithHighestStrength()
            => this.data.OrderByDescending(x => x.Item.Strength).First();

        public Hero GetHeroWithHighestAbility()
            => this.data.OrderByDescending(x => x.Item.Ability).First();

        public Hero GetHeroWithHighestIntelligence()
            => this.data.OrderByDescending(x => x.Item.Intelligence).First();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
