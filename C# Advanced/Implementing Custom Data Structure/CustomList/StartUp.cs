using System;

namespace CustomList
{
    public class StartUp
    {
        public static void Main()
        {
            var myList = new MyList<int>(5);

            myList.Add(7);
            myList.Add(13);
            Console.WriteLine(myList.Count); //2

            myList.RemoveAt(0);

            Console.WriteLine(myList.Count); //1

            myList.Add(15);
            myList.Add(99);
            myList.Add(113);

            Console.WriteLine(myList.Contains(113)); //True
            Console.WriteLine(myList.Contains(999)); //False
            Console.WriteLine(myList.Count); //4

            myList.Insert(2, 77);
            myList.Insert(0, 19);

            Console.WriteLine(myList.Count); //6

            myList.Swap(0, 3);

            foreach (var num in myList)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(myList[0]);
            myList[0] = 100;
        }
    }
}
