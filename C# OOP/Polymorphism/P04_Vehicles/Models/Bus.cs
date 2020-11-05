namespace P04_Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += GeneralConstants.Bus_FUEL_INCREASE_FROM_AIR_CONDITIONER;
        }

        public string DriveEmpty(double distance)
        {
            var isEnoughtFuel = this.FuelQuantity >= (this.FuelConsumption - GeneralConstants.Bus_FUEL_INCREASE_FROM_AIR_CONDITIONER) * distance;

            if (isEnoughtFuel)
            {
                this.FuelQuantity -= (this.FuelConsumption - GeneralConstants.Bus_FUEL_INCREASE_FROM_AIR_CONDITIONER) * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}
