using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            var test = new EqualityScale<int>(5, 5);
            Console.WriteLine(test.AreEqual());

            var other = new EqualityScale<int>(5, 10);
            Console.WriteLine(other.AreEqual());
        }
    }
}
