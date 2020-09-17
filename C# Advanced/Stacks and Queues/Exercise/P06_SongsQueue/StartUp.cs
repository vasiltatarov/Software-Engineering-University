using System;
using System.Collections.Generic;

namespace P06_SongsQueue
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                var command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    var song = command.Substring(4, command.Length - 4);

                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
