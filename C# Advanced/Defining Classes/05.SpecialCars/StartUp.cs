using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while (true)
            {
                var tire = Console.ReadLine();

                if (tire == "No more tires")
                {
                    break;
                }

                var tireArgs = tire.Split(" ", StringSplitOptions.None);

                Tire[] currentTire = ProccesTire(tireArgs);

                tires.Add(currentTire);
            }

            while (true)
            {
                var engine = Console.ReadLine();

                if (engine == "Engines done")
                {
                    break;
                }

                var engineArgs = engine.Split(" ", StringSplitOptions.None);

                Engine currEngine = ProccesEngine(engineArgs);

                engines.Add(currEngine);
            }

            while (true)
            {
                var car = Console.ReadLine();

                if (car == "Show special")
                {
                    break;
                }

                var carArgs = car.Split(" ", StringSplitOptions.None);

                Car currCar = ProccesCar(carArgs, tires, engines);

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                var year = car.Year;
                var horsePower = car.Engine.HorsePower;
                var tiresPressure = car.Tires.Sum(x => x.Pressure);
                car.Drive(20);

                if (year >= 2017 && horsePower > 330 && tiresPressure >= 9 && tiresPressure <= 10)
                {
                    Console.WriteLine(car.SpecialCar());
                }
            }
        }

        private static Car ProccesCar(string[] carArgs, List<Tire[]> tires, List<Engine> engines)
        {
            var make = carArgs[0];
            var model = carArgs[1];
            var year = int.Parse(carArgs[2]);
            var fuelQuantity = double.Parse(carArgs[3]);
            var fuelConsumption = double.Parse(carArgs[4]);
            var engineIndex = int.Parse(carArgs[5]);
            var tiresIndex = int.Parse(carArgs[6]);

            var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

            return car;
        }

        private static Engine ProccesEngine(string[] engineArgs)
        {
            var horsePower = int.Parse(engineArgs[0]);
            var cubicCapacity = double.Parse(engineArgs[1]);

            var engine = new Engine(horsePower, cubicCapacity);

            return engine;
        }

        private static Tire[] ProccesTire(string[] tireArgs)
        {
            var firstTireYear = int.Parse(tireArgs[0]);
            var firstTirePressure = double.Parse(tireArgs[1]);

            var secondTireYear = int.Parse(tireArgs[2]);
            var secondTirePressure = double.Parse(tireArgs[3]);

            var thirdTireYear = int.Parse(tireArgs[4]);
            var thirdTirePressure = double.Parse(tireArgs[5]);

            var fourthTireYear = int.Parse(tireArgs[6]);
            var fourthTirePressure = double.Parse(tireArgs[7]);

            var tire = new Tire[]
            {
                new Tire(firstTireYear, firstTirePressure),
                new Tire(secondTireYear, secondTirePressure),
                new Tire(thirdTireYear, thirdTirePressure),
                new Tire(fourthTireYear, fourthTirePressure),
            };

            return tire;
        }
    }
}
