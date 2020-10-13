using System;
using System.Diagnostics.CodeAnalysis;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            var personComparison = this.Name.CompareTo(other.Name);

            if (personComparison == 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return personComparison;
        }

        public override bool Equals(object obj)
        {
            var current = (Person)obj;

            return this.Name.Equals(current.Name) && this.Age.Equals(current.Age);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() - this.Age.GetHashCode();
        }
    }
}
