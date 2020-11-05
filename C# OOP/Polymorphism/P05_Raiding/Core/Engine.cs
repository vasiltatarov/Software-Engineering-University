using System;
using System.Collections.Generic;
using P05_Raiding.Models;

namespace P05_Raiding.Core
{
    public class Engine
    {
        private readonly List<BaseHero> heroes;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            while (this.heroes.Count < n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                BaseHero hero = null;

                if (heroType == "Druid")
                {
                    hero = new Druid(heroName);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                if (hero != null)
                {
                    this.heroes.Add(hero);
                }
            }

            var bossPower = int.Parse(Console.ReadLine());
            var raidPower = 0;

            foreach (var hero in this.heroes)
            {
                raidPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(raidPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
