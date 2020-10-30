using System;
using System.Collections.Generic;
using System.Globalization;
using P05_BorderControl.Interfaces;
using P05_BorderControl.Models;

namespace P05_BorderControl
{
    public class Engine
    {
        private List<IBuyer> entities;
        private HashSet<string> names;
        private int foodQuantity;

        public Engine()
        {
            this.entities = new List<IBuyer>();
            this.names = new HashSet<string>();
            this.foodQuantity = 0;
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IBuyer entity = null;

                if (args.Length == 4)
                {
                    var parseDate = DateTime.ParseExact(args[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    entity = new Citizen(args[0], int.Parse(args[1]), args[2], parseDate);
                }
                else if (args.Length == 3)
                {
                    entity = new Rebel(args[0], int.Parse(args[1]), args[2]);
                }

                if (entity != null && !(this.names.Contains(args[0])))
                {
                    this.entities.Add(entity);
                    this.names.Add(args[0]);
                }
            }

            while (true)
            {
                var Name = Console.ReadLine();

                if (Name == "End")
                {
                    break;
                }

                var entity = this.entities.Find(x => x.Name == Name);

                if (entity != null)
                {
                    this.foodQuantity += entity.BuyFood();
                }
            }

            Console.WriteLine(this.foodQuantity);
        }
    }
}
