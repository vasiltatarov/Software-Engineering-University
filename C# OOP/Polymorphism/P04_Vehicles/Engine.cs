using P04_Vehicles.Models;
using System;

namespace P04_Vehicles
{
    public class Engine
    {
        private Car car;
        private Truck truck;
        private Bus bus;

        public void Run()
        {
            ProccesCar(Console.ReadLine());
            ProccesTruck(Console.ReadLine());
            ProccesBus(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var args = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var command = args[0];
                    var type = args[1];
                    var amount = double.Parse(args[2]);

                    if (command == "Drive")
                    {
                        if (type == "Car")
                        {
                            Console.WriteLine(this.car.Drive(amount));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(this.truck.Drive(amount));
                        }
                        else if (type == "Bus")
                        {
                            Console.WriteLine(this.bus.Drive(amount));
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(this.bus.DriveEmpty(amount));
                    }
                    else if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            this.car.Refuel(amount);
                        }
                        else if (type == "Truck")
                        {
                            this.truck.Refuel(amount);
                        }
                        else if (type == "Bus")
                        {
                            this.bus.Refuel(amount);
                        }
                    }
                }
                catch (Exception ex )
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }

        private void ProccesBus(string input)
        {
            var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            this.bus = new Bus(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }

        private void ProccesTruck(string input)
        {
            var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            this.truck = new Truck(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }

        private void ProccesCar(string input)
        {
            var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            this.car = new Car(double.Parse(args[1]), double.Parse(args[2]), double.Parse(args[3]));
        }
    }
}
