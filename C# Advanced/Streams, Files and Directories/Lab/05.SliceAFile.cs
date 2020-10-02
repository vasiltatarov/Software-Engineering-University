using System;
using System.IO;
using System.Linq;

namespace _5.SliceAFile
{
    class Program
    {
        static void Main()
        {
            using var reader = new FileStream(@"..\..\..\text.txt", FileMode.OpenOrCreate);
            var parts = 4;
            var length = (int)Math.Ceiling(reader.Length / (decimal)parts);
            var buffer = new byte[length];

            for (int i = 1; i <= parts; i++)
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead < buffer.Length)
                {
                    buffer = buffer.Take(bytesRead).ToArray();
                }

                using var currentPartStream = new FileStream($@"..\..\..\Part-{i}.txt", FileMode.OpenOrCreate);
                currentPartStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
