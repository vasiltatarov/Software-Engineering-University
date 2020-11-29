using System;

namespace Singleton
{
    public class StartUp
    {
        // Singleton is a Creational Design Pattern
        public static void Main()
        {
            var singleton = SingletonDataContainer.Instance;
            Console.WriteLine(singleton.GetPopulation("Sofia"));

            var singleton1 = SingletonDataContainer.Instance;
            Console.WriteLine(singleton1.GetPopulation("Chakalarovo"));
        }
    }
}
