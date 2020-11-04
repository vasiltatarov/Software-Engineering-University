using P01_Vehicles.Models.Contracts;

namespace P01_Vehicles.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
