using System;

namespace P04_Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private StationaryPhone stationaryPhone;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public void Run()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                var isInvalid = false;

                for (int i = 0; i < number.Length; i++)
                {
                    if (char.IsLetter(number[i]))
                    {
                        isInvalid = true;
                    }
                }

                if (isInvalid)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (number.Length == 10)
                {
                    Console.WriteLine(this.smartphone.Calling(number));
                } 
                else if (number.Length == 7)
                {
                    Console.WriteLine(this.stationaryPhone.Calling(number));
                }
            }

            foreach (var site in sites)
            {
                var isValid = true;

                for (int i = 0; i < site.Length; i++)
                {
                    if (char.IsDigit(site[i]))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(this.smartphone.Browsing(site));
                }
            }
        }
    }
}
