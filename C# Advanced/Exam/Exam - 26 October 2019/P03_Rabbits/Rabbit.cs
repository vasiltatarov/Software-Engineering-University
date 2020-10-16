namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool availbale;

        public Rabbit(string name, string species)
        {
            this.Name = name;
            this.Species = species;
            this.availbale = true;
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
        public string Species
        {
            get
            {
                return this.species;
            }
            set
            {
                this.species = value;
            }
        }
        public bool Available
        {
            get
            {
                return this.availbale;
            }
            set
            {
                this.availbale = value;
            }
        }

        public override bool Equals(object obj)
        {
            var curr = (Rabbit)obj;

            return this.Name.Equals(curr.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
