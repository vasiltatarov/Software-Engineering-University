namespace P04_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += GeneralConstants.Car_FUEL_INCREASE_FROM_AIR_CONDITIONER;
        }
    }
}
