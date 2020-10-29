using P04_PizzaCalories.Models;
using System;

namespace P04_PizzaCalories
{
    public class Engine
    {
        private Pizza pizza;

        public void Run() // maybe cannot have public getter on dough and topping
        {
            var pizzaArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var doughArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dough dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));
            this.pizza = new Pizza(pizzaArgs[1], dough);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Topping")
                {
                    Topping topping = new Topping(args[1], double.Parse(args[2]));
                    this.pizza.AddTopping(topping);
                }
            }

            Console.WriteLine($"{this.pizza.Name} - {this.pizza.TotalCalories():F2} Calories.");
        }
    }
}
