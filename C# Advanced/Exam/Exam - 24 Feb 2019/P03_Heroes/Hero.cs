using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Hero)
            {
                var h = (Hero)obj;

                return this.Name == h.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Hero: {this.Name} – {this.Level}lvl")
                .AppendLine(this.Item.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
