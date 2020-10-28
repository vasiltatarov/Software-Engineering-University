using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private const string DEFAULT_ERROR = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(DEFAULT_ERROR);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(DEFAULT_ERROR);
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value != "Female" && value != "Male")
                {
                    throw new ArgumentException(DEFAULT_ERROR);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(this.GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
