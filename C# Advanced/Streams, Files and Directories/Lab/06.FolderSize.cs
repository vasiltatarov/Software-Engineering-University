using System;
using System.IO;

namespace _6.FolderSize
{
    class Program
    {
        static void Main()
        {
            var path = @"../../../TestFolder"; // Select your folder!
            var files = Directory.GetFiles(path);
            var allLength = 0M;

            foreach (var item in files)
            {
                var currentFile = new FileInfo(item);
                allLength += currentFile.Length;
            }

            Console.WriteLine($"{allLength / 1024 / 1024} kb");
        }
    }
}
