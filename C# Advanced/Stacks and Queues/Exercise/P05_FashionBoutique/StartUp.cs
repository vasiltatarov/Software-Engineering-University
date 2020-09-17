using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FashionBoutique
{
    public class StartUp
    {
        static void Main()
        {
            var clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var capacityOfRack = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(clothes);
            var boxes = 0;
            var clothesSum = 0;

            while (stack.Count > 0)
            {
                var currClothes = stack.Peek();
                clothesSum += currClothes;

                if (clothesSum == capacityOfRack)
                {
                    if (stack.Count > 0)
                    {
                        boxes++;
                    }

                    clothesSum = 0;
                    stack.Pop();
                }
                else if (clothesSum > capacityOfRack)
                {
                    boxes++;
                    clothesSum = 0;
                }
                else
                {
                    stack.Pop();
                }
            }

            if (clothesSum != 0)
            {
                boxes++;
            }

            Console.WriteLine(boxes);
        }
    }
}
