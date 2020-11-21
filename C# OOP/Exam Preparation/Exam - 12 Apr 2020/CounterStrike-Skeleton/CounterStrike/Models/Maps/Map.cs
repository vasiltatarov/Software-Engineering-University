using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(x => x is Terrorist);
            var counterTerrorists = players.Where(x => x is CounterTerrorist);

            while (true)
            {
                if (terrorists.Any(x => x.IsAlive) == false)
                {
                    return "Counter Terrorist wins!";
                }

                if (counterTerrorists.Any(x => x.IsAlive) == false)
                {
                    return "Terrorist wins!";
                }

                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {
                                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                    }
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                            }
                        }
                    }
                }
            }
        }
    }
}
