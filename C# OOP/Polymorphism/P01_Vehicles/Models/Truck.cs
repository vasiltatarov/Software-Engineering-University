using System;
using P01_Vehicles.Exceptions;

namespace P01_Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 1.6;
        private const double RefuelPercentage = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.FuelMustBePositiveException);
            }

            if ((this.FuelQuantity + amount) > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotFitFuelAmountInTankException, amount));
            }

            base.Refuel(amount * RefuelPercentage);
        }
    }
}
