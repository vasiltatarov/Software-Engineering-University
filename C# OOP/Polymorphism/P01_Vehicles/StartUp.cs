using P01_Vehicles.Core;
using P01_Vehicles.Factories;
using P01_Vehicles.IO;

namespace P01_Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var vehicleFactory = new VehicleFactory();
            var engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
