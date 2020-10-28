using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new RandomList();

            list.Add("vakso");
            list.Add("sali");
            list.Add("dona");
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
