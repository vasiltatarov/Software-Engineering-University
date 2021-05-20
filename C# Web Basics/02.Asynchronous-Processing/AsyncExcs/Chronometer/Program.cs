using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            IChronometer watch = new Chronometer();

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write('.');
            //        Thread.Sleep(100);
            //    }
            //});

            Task.Run(() =>
            {
                while (true)
                {
                    var input = Console.ReadLine();

                    if (input.ToLower() == "start")
                    {
                        watch.Start();
                    }
                    else if (input.ToLower() == "stop")
                    {
                        watch.Stop();
                    }
                    else if (input.ToLower() == "lap")
                    {
                        var time = watch.Lap();
                        Console.WriteLine(time);
                    }
                    else if (input.ToLower() == "laps")
                    {
                        var laps = watch.Laps;

                        if (laps.Count == 0)
                        {
                            Console.WriteLine("Laps: no laps");
                            continue;
                        }

                        Console.WriteLine("Laps:");
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i]}");
                        }
                    }
                    else if (input.ToLower() == "time")
                    {
                        Console.WriteLine(watch.GetTime);
                    }
                    else if (input.ToLower() == "reset")
                    {
                        watch.Reset();
                    }
                    else if (input.ToLower() == "exit")
                    {
                        return;
                    }
                }
            }).Wait();
        }
    }
}
