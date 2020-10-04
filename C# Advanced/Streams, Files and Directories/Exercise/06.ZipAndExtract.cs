using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main()
        {
            //ZipFile.CreateFromDirectory(@"D:\Snippets", @"D:\MyArchive.zip");
            //ZipFile.ExtractToDirectory(@"D:\MyArchive.zip", @"D:\SoftUni");

            ZipFile.CreateFromDirectory(@"C:\Users\USER\source\repos\Streams, Files, and Directories\06.ZipAndExtract\Test",
                @"C:\Users\USER\source\repos\Streams, Files, and Directories\06.ZipAndExtract/MyArchive.zip");
            ZipFile.ExtractToDirectory(@"C:\Users\USER\source\repos\Streams, Files, and Directories\06.ZipAndExtract/MyArchive.zip",
                @"C:\Users\USER\source\repos\Streams, Files, and Directories");
        }
    }
}
