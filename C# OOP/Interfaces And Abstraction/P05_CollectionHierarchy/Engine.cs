using P07_CollectionHierarchy.Models;
using System;
using System.Text;

namespace P07_CollectionHierarchy
{
    public class Engine
    {
        public Engine()
        {
            this.AddCollection = new AddCollection();
            this.AddRemoveCollection = new AddRemoveCollection();
            this.MyList = new MyList();
        }

        public AddCollection AddCollection { get; set; }
        public AddRemoveCollection AddRemoveCollection { get; set; }
        public MyList MyList { get; set; }

        public void Run()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(PrintResult(input, n));
        }

        private string PrintResult(string[] input, int n)
        {
            var sb = new StringBuilder();

            foreach (var item in input)
            {
                sb.Append($"{this.AddCollection.Add(item)} ");
            }
            sb.AppendLine();

            foreach (var item in input)
            {
                sb.Append($"{this.AddRemoveCollection.Add(item)} ");
            }
            sb.AppendLine();

            foreach (var item in input)
            {
                sb.Append($"{this.MyList.Add(item)} ");
            }
            sb.AppendLine();

            for (int i = 0; i < n; i++)
            {
                sb.Append($"{this.AddRemoveCollection.Remove()} ");
            }
            sb.AppendLine();

            for (int i = 0; i < n; i++)
            {
                sb.Append($"{this.MyList.Remove()} ");
            }
            sb.AppendLine();

            return sb.ToString().TrimEnd();
        }
    }
}
