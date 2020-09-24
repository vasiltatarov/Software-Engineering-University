using System;
using System.Collections.Generic;

namespace P06_ParkingLot
{
    public class StartUp
    {
        static void Main()
        {
            var parking = new HashSet<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var direction = args[0];
                var carNumber = args[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    if (parking.Contains(carNumber))
                    {
                        parking.Remove(carNumber);
                    }
                }
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var carNumber in parking)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}
