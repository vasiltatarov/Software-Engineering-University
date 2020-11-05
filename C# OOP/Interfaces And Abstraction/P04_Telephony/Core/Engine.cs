using System;
using P04_Telephony.Exceptions;
using P04_Telephony.IO;
using P04_Telephony.IO.Contracts;

namespace P04_Telephony
{
    public class Engine
    {
        private Smartphone smartphone;
        private StationaryPhone stationaryPhone;
        private Iwriter writer;
        private IReader reader;

        public Engine(Smartphone smartphone, StationaryPhone stationaryPhone, Iwriter consoleWriter, IReader consoleReader)
        {
            this.smartphone = smartphone;
            this.stationaryPhone = stationaryPhone;
            this.writer = consoleWriter;
            this.reader = consoleReader;
        }

        public void Run()
        {
            var numbers = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sites = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CallingNumbers(numbers);
            BrowsingSites(sites);
        }

        private void BrowsingSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    this.writer.WriteLine(this.smartphone.Browsing(site));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        private void CallingNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        this.writer.WriteLine(this.smartphone.Call(number));
                    }
                    else if (number.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
