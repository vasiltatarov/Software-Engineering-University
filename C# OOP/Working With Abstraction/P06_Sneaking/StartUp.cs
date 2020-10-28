using System;

namespace P06_Sneaking
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sneaking = new Sneaking(n);
            sneaking.Procces();
        }
    }
}
