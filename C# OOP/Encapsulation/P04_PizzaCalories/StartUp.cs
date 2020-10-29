using System;

namespace P04_PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
