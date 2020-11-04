namespace P01_Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        bool HasAirConditioner { get; }

        double AirConditionerFuelConsumption { get; }

        bool Drive(double distance);

        void Refuel(double amount);

        void StopAirConditioner();

        void StartAirConditioner();
    }
}
