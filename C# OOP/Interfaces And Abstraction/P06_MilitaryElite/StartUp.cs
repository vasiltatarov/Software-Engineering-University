using P04_Telephony.IO;

namespace P07MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}
