using System;

namespace P03_ShoppingSpree
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
