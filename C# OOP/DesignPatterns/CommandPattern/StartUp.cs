using System;
using CommandPattern.Models;
using CommandPattern.Models.Commands;

namespace CommandPattern
{
    public class StartUp
    {
        // Command is a Behavioral Design Pattern 
        public static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
