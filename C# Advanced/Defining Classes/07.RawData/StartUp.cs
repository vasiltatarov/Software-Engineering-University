using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main()
        {
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var car = ProccesCar(carArgs);
                cars.Add(car);
            }

            var cargoType = Console.ReadLine();
            var predicate = CargoType(cargoType);

            var result = cars.Where(x => predicate(x));

            PrintCars(result);
        }

        private static void PrintCars(IEnumerable<Car> result)
        {
            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static Predicate<Car> CargoType(string type)
        {
            Predicate<Car> predicate = null;

            if (type == "fragile")
            {
                predicate = new Predicate<Car>(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1));
            }
            else if (type == "flamable")
            {
                predicate = new Predicate<Car>(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250);
            }

            return predicate;
        }

        private static Car ProccesCar(string[] carArgs)
        {
            var model = carArgs[0];

            var engineSpeed = int.Parse(carArgs[1]);
            var enginePower = int.Parse(carArgs[2]);

            var cargoWeight = int.Parse(carArgs[3]);
            var cargoType = carArgs[4];

            var tire1Pressure = double.Parse(carArgs[5]);
            var tire1Age = int.Parse(carArgs[6]);

            var tire2Pressure = double.Parse(carArgs[7]);
            var tire2Age = int.Parse(carArgs[8]);

            var tire3Pressure = double.Parse(carArgs[9]);
            var tire3Age = int.Parse(carArgs[10]);

            var tire4Pressure = double.Parse(carArgs[11]);
            var tire4Age = int.Parse(carArgs[12]);

            var engine = new Engine(engineSpeed, enginePower);
            var cargo = new Cargo(cargoWeight, cargoType);
            var tires = new Tire[]
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age)
            };

            return new Car(model, engine, cargo, tires);
        }
    }
}
