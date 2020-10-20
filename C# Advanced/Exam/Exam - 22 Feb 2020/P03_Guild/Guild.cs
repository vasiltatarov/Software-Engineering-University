using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private HashSet<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new HashSet<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var found = this.roster.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                this.roster.Remove(found);
                return true;
            }

            return false;   
        }

        public void PromotePlayer(string name)
        { 
            var found = this.roster.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                found.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var found = this.roster.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                found.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var list = this.roster.Where(x => x.Class == @class).ToArray();

            foreach (var player in list)
            {
                this.roster.Remove(player);
            }

            return list;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
