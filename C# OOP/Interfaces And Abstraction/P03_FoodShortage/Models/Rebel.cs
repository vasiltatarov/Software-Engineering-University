using P05_BorderControl.Interfaces;

namespace P05_BorderControl.Models
{
    public class Rebel : IPerson, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 5;

            return 5;
        }
    }
}
