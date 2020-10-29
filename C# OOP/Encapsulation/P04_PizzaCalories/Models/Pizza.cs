using P04_PizzaCalories.Exceptions;
using P04_PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new InvalidOperationException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (this.toppings.Count >= 10)
            {
                throw new InvalidCountToppingException();
            }
        }

        public double TotalCalories()
            => this.Dough.GetCalories() + this.toppings.Select(x => x.GetCalories()).Sum();
    }
}
