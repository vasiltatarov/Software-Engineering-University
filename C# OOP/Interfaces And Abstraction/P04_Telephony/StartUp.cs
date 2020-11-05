using P04_Telephony.IO;

namespace P04_Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var engine = new Engine(smartphone, stationaryPhone, writer, reader);
            engine.Run();
        }
    }
}
