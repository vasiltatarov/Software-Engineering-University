using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private HashSet<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new HashSet<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var found = this.data.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                this.data.Remove(found);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveWhere(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var found = this.data.FirstOrDefault(x => x.Name == name);

            if (found != null)
            {
                found.Available = false;
                return found;
            }

            return found;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = this.data.Where(x => x.Species == species).ToArray();

            for (int i = 0; i < rabbits.Length; i++)
            {
                rabbits[i].Available = false;
            }

            return rabbits;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
