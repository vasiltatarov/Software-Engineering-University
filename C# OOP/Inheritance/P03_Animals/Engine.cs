using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                var type = Console.ReadLine();

                if (type == "Beast!")
                {
                    break;
                }

                var args = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Animal animal;

                try
                {
                    animal = GetAnimal(type, args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.animals.Add(animal);
            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal(string type, string[] args)
        {
            Animal animal = null;
            var name = args[0];
            var age = int.Parse(args[1]);
            string gender = null;

            if (args.Length == 3)
            {
                gender = args[2];
            }

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }

            return animal;
        }
    }
}
