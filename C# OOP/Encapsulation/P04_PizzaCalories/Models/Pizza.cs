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
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
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
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new InvalidOperationException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int NumberOfToppings => this.toppings.Count;

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings >= 10)
            {
                throw new InvalidCountToppingException();
            }

            this.toppings.Add(topping);
        }

        public double TotalCalories()
            => this.Dough.GetCalories() + this.toppings.Select(x => x.GetCalories()).Sum();
    }
}
