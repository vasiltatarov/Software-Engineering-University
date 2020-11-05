using System;
using System.Collections.Generic;
using P06_WildFarm.Exceptions;
using P06_WildFarm.IO;
using P06_WildFarm.IO.Contracts;
using P06_WildFarm.Models;
using P06_WildFarm.Models.Animals;
using P06_WildFarm.Models.Foods;

namespace P06_WildFarm.Core
{
    public class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<Animal> animals;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                var command = this.reader.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var animalArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var foodArgs = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var animal = ProccesAnimal(animalArgs);
                var food = ProccesFood(foodArgs);

                this.animals.Add(animal);

                try
                {
                    this.writer.WriteLine(animal.ProduceSound());
                    animal.Feed(food);
                }
                catch (UneatableFoodException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }

            foreach (var animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }

        private Food ProccesFood(string[] args)
        {
            var name = args[0];
            var quantity = int.Parse(args[1]);
            Food food = null;

            if (name == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (name == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (name == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (name == "Fruit")
            {
                food = new Fruit(quantity);
            }

            return food;
        }

        private Animal ProccesAnimal(string[] args)
        {
            var type = args[0];
            var name = args[1];
            var weight = double.Parse(args[2]);
            Animal animal = null;

            if (type == "Cat")
            {
                animal = new Cat(name, weight, args[3], args[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, args[3], args[4]);
            }
            else if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(args[3]));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(args[3]));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, args[3]);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, args[3]);
            }

            return animal;
        }
    }
}
