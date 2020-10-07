using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {

            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carArgs[0];
                var fuelAmount = double.Parse(carArgs[1]);
                var fuelConsumption = double.Parse(carArgs[2]);

                var car = new Car(model, fuelAmount, fuelConsumption);

                if (cars.Find(x => x.Model == model) == null)
                {
                    cars.Add(car);
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "Drive")
                {
                    var model = args[1];
                    var amountKm = int.Parse(args[2]);

                    var foundCar = cars.Find(c => c.Model == model);

                    if (foundCar != null)
                    {
                        foundCar.Drive(amountKm);
                    }
                }
            }

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
