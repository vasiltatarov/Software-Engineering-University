using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var engineArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var engine = ProccesEngine(engineArgs);
                engines.Add(engine);
            }

            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var car = ProccesCar(carArgs, engines);
                cars.Add(car);
            }

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static Car ProccesCar(string[] carArgs, List<Engine> engines)
        {
            var model = carArgs[0];
            var engine = engines.Find(x => x.Model == carArgs[1]);
            var car = new Car(model, engine);

            if (carArgs.Length == 3)
            {
                var IsHaveWeight = int.TryParse(carArgs[2], out int weight);

                if (IsHaveWeight)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    car = new Car(model, engine, 0, carArgs[2]);
                }
            }
            else if (carArgs.Length == 4)
            {
                car = new Car(model, engine, int.Parse(carArgs[2]), carArgs[3]);
            }

            return car;
        }

        private static Engine ProccesEngine(string[] engineArgs)
        {
            var model = engineArgs[0];
            var power = int.Parse(engineArgs[1]);

            var engine = new Engine(model, power);

            if (engineArgs.Length == 3)
            {
                var IsHaveDisplacement = int.TryParse(engineArgs[2], out int displacement);

                if (IsHaveDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    engine = new Engine(model, power, 0, engineArgs[2]);
                }
            }
            else if (engineArgs.Length == 4)
            {
                engine = new Engine(model, power, int.Parse(engineArgs[2]), engineArgs[3]);
            }

            return engine;
        }
    }
}
