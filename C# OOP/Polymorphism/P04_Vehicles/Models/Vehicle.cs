using System;

namespace P04_Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
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
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual string Drive(double distance)
        {
            var isEnoughtFuel = this.FuelQuantity >= this.FuelConsumption * distance;

            if (isEnoughtFuel)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(GeneralConstants.FUEL_AMOUNT_MUST_BE_POSITIVE_EXC);
            }

            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(GeneralConstants.INVALID_REFUEL_EXC, amount));
            }

            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
