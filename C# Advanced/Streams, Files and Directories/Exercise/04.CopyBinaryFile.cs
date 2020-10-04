using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main()
        {
            const int DEF_SIZE = 4096;

            // Get path of your wanted file for copy, photo/music/videos or other!!!
            using var reader = new FileStream(@"..\..\..\copyMe.png", FileMode.Open);

            // Get path to your wanted place to copy!!!
            using var writer = new FileStream(@"..\..\..\copied.png", FileMode.Create);

            var buffer = new byte[DEF_SIZE];

            while (reader.CanRead)
            {
                var readBytes = reader.Read(buffer, 0, buffer.Length);

                if (readBytes == 0)
                {
                    break;
                }

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
