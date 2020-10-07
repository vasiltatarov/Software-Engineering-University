using System;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer : IComparable
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Badges
        {
            get
            {
                return this.badges;
            }
            set
            {
                this.badges = value;
            }
        }
        public List<Pokemon> Pokemons
        {
            get
            {
                return this.pokemons;
            }
            set
            {
                this.pokemons = value;
            }
        }

        public int CompareTo(object obj)
        {
            var current = (Trainer)obj;

            return this.Name.CompareTo(current.Name);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
