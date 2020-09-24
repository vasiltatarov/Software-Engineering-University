using System;
using System.Collections.Generic;

namespace P07_SoftUniParty
{
    public class StartUp
    {
        static void Main()
        {
            var vipGuests = new HashSet<string>();
            var regularGuests = new HashSet<string>();
            var isParty = false;

            while (true)
            {
                var guestNumber = Console.ReadLine();

                if (guestNumber == "END")
                {
                    break;
                }

                if (guestNumber == "PARTY")
                {
                    isParty = true;
                }

                if (isParty)
                {
                    if (vipGuests.Contains(guestNumber))
                    {
                        vipGuests.Remove(guestNumber);
                    }

                    if (regularGuests.Contains(guestNumber))
                    {
                        regularGuests.Remove(guestNumber);
                    }
                }
                else
                {
                    if (char.IsDigit(guestNumber[0]))
                    {
                        vipGuests.Add(guestNumber);
                    }
                    else
                    {
                        regularGuests.Add(guestNumber);
                    }
                }
            }

            PrintGuests(vipGuests, regularGuests);
        }

        private static void PrintGuests(HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            foreach (var vip in vipGuests)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regularGuests)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
