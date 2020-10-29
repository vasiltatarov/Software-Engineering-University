using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_ShoppingSpree
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;

        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            var personsArgs = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            ProccesPersons(personsArgs);

            var productsArgs = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            ProccesProducts(productsArgs);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var person = this.persons.Find(x => x.Name == args[0]);
                var product = this.products.Find(x => x.Name == args[1]);

                if (person == null || product == null)
                {
                    continue;
                }

                Console.WriteLine(person.BuyProduct(product));
            }

            PrintPersonsAndItsProducts();
        }

        private void PrintPersonsAndItsProducts()
        {
            foreach (var person in this.persons)
            {
                Console.WriteLine(person);
            }
        }

        private void ProccesProducts(string[] productsArgs)
        {
            for (int i = 0; i < productsArgs.Length; i += 2)
            {
                var name = productsArgs[i];
                var cost = decimal.Parse(productsArgs[i + 1]);

                this.products.Add(new Product(name, cost));
            }
        }

        private void ProccesPersons(string[] personsArgs)
        {
            for (int i = 0; i < personsArgs.Length; i += 2)
            {
                var name = personsArgs[i];
                var money = decimal.Parse(personsArgs[i + 1]);

                this.persons.Add(new Person(name, money));
            }
        }
    }
}
