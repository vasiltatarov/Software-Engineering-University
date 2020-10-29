using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
            this.rating = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public bool RemovePlayer(string name)
        {
            var player = this.players.Find(x => x.Name == name);

            if (player != null)
            {
                this.players.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int Rating()
            => (int)Math.Round(this.players.Select(x => x.Rating()).Sum());

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating()}";
        }
    }
}
