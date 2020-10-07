using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            var trainers = new List<Trainer>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Tournament")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var trainerName = args[0];
                var pokemonName = args[1];
                var pokemonElement = args[2];
                var pokemonHealth = int.Parse(args[3]);

                var trainer = new Trainer(trainerName);
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                var found = trainers.Find(x => x.Name == trainer.Name);

                if (found != null)
                {
                    found.Pokemons.Add(pokemon);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                string element = ProccesElement(command);

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            var pokemon = trainer.Pokemons[i];

                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                                i--;
                            }
                        }
                    }
                }
            }

            var result = trainers.OrderByDescending(x => x.Badges).ToList();

            foreach (var trainer in result)
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static string ProccesElement(string command)
        {
            var element = string.Empty;

            if (command == "Fire")
            {
                element = "Fire";
            }
            else if (command == "Water")
            {
                element = "Water";
            }
            else if (command == "Electricity")
            {
                element = "Electricity";
            }

            return element;
        }
    }
}
