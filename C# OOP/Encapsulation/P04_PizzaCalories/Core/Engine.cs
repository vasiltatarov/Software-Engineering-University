using P04_PizzaCalories.Models;
using System;
using P04_PizzaCalories.IO;
using P04_PizzaCalories.IO.Contracts;

namespace P04_PizzaCalories
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            var pizzaArgs = this.reader.ReadLine().Split(" ");
            var doughArgs = this.reader.ReadLine().Split(" ");

            var pizza = new Pizza(pizzaArgs[1]);
            Dough dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));
            pizza.Dough = dough;

            while (true)
            {
                var command = this.reader.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split(" ");

                if (args[0] == "Topping")
                {
                    Topping topping = new Topping(args[1], double.Parse(args[2]));
                    pizza.AddTopping(topping);
                }
            }

            this.writer.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
        }
    }
}
