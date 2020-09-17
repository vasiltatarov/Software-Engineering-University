using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_KeyRevolver
{
    public class StartUp
    {
        static void Main()
        {
            var priceOfBullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var locksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var intelligenceValue = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsInput);
            var locks = new Queue<int>(locksInput);
            var currBulletInBarrel = sizeOfGunBarrel;
            var bulletsPrice = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                var currBullet = bullets.Pop();
                var currLock = locks.Peek();
                currBulletInBarrel--;
                bulletsPrice++;

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currBulletInBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currBulletInBarrel = sizeOfGunBarrel;
                }
            }

            bulletsPrice *= priceOfBullet;

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - bulletsPrice}");
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
