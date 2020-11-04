namespace P01_Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true)
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;
    }
}
