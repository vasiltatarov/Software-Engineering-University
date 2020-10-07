using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var diff = DateModifier.DifferenceBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine(diff);
        }
    }
}
