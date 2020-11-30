using System;
using TemplatePattern.Models;

namespace TemplatePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bread twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();

            Bread sourdough = new TwelveGrain();
            sourdough.Make();
            Console.WriteLine();

            Bread wholeWheat = new TwelveGrain();
            wholeWheat.Make();
        }
    }
}
