using System;
using P04_PizzaCalories.IO;

namespace P04_PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            try
            {
                var engine = new Engine(writer, reader);
                engine.Run();
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }
    }
}
