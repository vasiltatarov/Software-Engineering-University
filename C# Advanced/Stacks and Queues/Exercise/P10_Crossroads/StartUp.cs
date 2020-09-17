using System;
using System.Collections.Generic;

namespace P10_Crossroads
{
    public class StartUp
    {
        static void Main()
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            var totalCarsPassed = 0;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                if (command == "green")
                {
                    var currDuration = greenLight;

                    while (currDuration > 0 && cars.Count > 0)
                    {
                        var currCar = cars.Dequeue();
                        currDuration -= currCar.Length;

                        if (currDuration < 0)
                        {
                            currDuration += freeWindow;

                            if (currDuration < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {currCar[currCar.Length - Math.Abs(currDuration)]}.");
                                return;
                            }

                            currDuration = 0;
                        }

                        totalCarsPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
