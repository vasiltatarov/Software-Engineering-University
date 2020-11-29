using System;
using Facade.Models;

namespace Facade
{
    public class StartUp
    {
        // Facade is a Structural Design Pattern
        public static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info
                .WithType("Sedan")
                .WithNumberOfDoors(4)
                .WithColor("Blue")
                .Built
                .InCity("Kardzhali")
                .AtAddress("Chakalarovo")
                .Build();

            Console.WriteLine(car);
        }
    }
}
