using System;
using System.Diagnostics.CodeAnalysis;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town; 
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            var personComparison = this.Name.CompareTo(other.Name);

            if (personComparison == 0)
            {
                personComparison = this.Age.CompareTo(other.Age);

                if (personComparison == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
            }

            return personComparison;
        }
    }
}
