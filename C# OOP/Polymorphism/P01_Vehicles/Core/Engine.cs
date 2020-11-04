using System;
using P01_Vehicles.Factories;
using P01_Vehicles.IO.Contracts;
using P01_Vehicles.Models;
using P01_Vehicles.Models.Contracts;

namespace P01_Vehicles.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            var carData = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var car = ProccesVehicle(carData);

            var truckData = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truck = ProccesVehicle(truckData);

            var busData = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var bus = ProccesVehicle(busData);

            var n = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var command = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var type = command[0];
                    var vehicleType = command[1];
                    var amount = double.Parse(command[2]);
                    var hasDrive = false;

                    if (type == "Drive")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            hasDrive = car.Drive(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            hasDrive = truck.Drive(amount);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.StartAirConditioner();
                            hasDrive = bus.Drive(amount);
                        }
                    }
                    else if (type == "DriveEmpty")
                    {
                        if (vehicleType == nameof(Bus))
                        {
                            bus.StopAirConditioner();
                            hasDrive = bus.Drive(amount);
                        }
                    }
                    else if (type == "Refuel")
                    {
                        if (vehicleType == nameof(Car))
                        {
                            car.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Truck))
                        {
                            truck.Refuel(amount);
                        }
                        else if (vehicleType == nameof(Bus))
                        {
                            bus.Refuel(amount);
                        }
                    }

                    if (hasDrive)
                    {
                        this.writer.WriteLine($"{vehicleType} travelled {amount} km");
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                    continue;
                }
            }

            PrintVehicles(car, truck, bus);
        }

        private void PrintVehicles(IVehicle car, IVehicle truck, IVehicle bus)
        {
            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }

        private IVehicle ProccesVehicle(string[] args)
        {
            var type = args[0];
            var fuelQuantity = double.Parse(args[1]);
            var fuelConsumption = double.Parse(args[2]);
            var tankCapacity = double.Parse(args[3]);

            return this.vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);
        }
    }
}
