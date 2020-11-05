using System;

namespace P04_Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += GeneralConstants.Truck_FUEL_INCREASE_FROM_AIR_CONDITIONER;
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(GeneralConstants.FUEL_AMOUNT_MUST_BE_POSITIVE_EXC);
            }

            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(GeneralConstants.INVALID_REFUEL_EXC, amount));
            }

            this.FuelQuantity += amount * 0.95;
        }
    }
}
