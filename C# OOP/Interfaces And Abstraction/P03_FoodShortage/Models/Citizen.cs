using P05_BorderControl.Interfaces;
using System;

namespace P05_BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IPerson, IBuyer
    {
        public Citizen(string name, int age, string id, DateTime birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public DateTime Birthday { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 10;

            return 10;
        }
    }
}
