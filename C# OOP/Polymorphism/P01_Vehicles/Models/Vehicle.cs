using System;
using P01_Vehicles.Exceptions;
using P01_Vehicles.Models.Contracts;

namespace P01_Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HasAirConditioner = hasAirConditioner;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                if (value < 0 || value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; }

        public bool HasAirConditioner { get; }

        public abstract double AirConditionerFuelConsumption { get; }

        public bool Drive(double distance)
        {
            var spentFuel = distance * this.FuelConsumption;

            if (this.HasAirConditioner)
            {
                spentFuel += distance * this.AirConditionerFuelConsumption;
            }

            if (this.FuelQuantity < spentFuel)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughtFuelException,
                    this.GetType().Name));
            }

            this.FuelQuantity -= spentFuel;
            return true;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.FuelMustBePositiveException);
            }

            if ((this.FuelQuantity + amount) > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotFitFuelAmountInTankException, amount));
            }

            this.FuelQuantity += amount;
        }

        public void StopAirConditioner()
        {
            this.HasAirConditioner = false;
        }

        public void StartAirConditioner()
        {
            this.HasAirConditioner = true;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
