using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, List<string>>();

            var input = Console.ReadLine();
            var file = Directory.GetFiles(input);
            ReadFiles(dict, file);

            var allFiles = FilesAsString(dict);

            // This will make resulted file on your desktop!!!
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            File.WriteAllText(@$"{path}\report.txt", allFiles);
        }

        private static string FilesAsString(Dictionary<string, List<string>> dict)
        {
            dict = dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            var sb = new StringBuilder();

            foreach (var d in dict)
            {
                sb.AppendLine($"{d.Key}");

                foreach (var item in d.Value)
                {
                    sb.AppendLine(item);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void ReadFiles(Dictionary<string, List<string>> dict, string[] file)
        {
            foreach (var item in file)
            {
                var currentFile = new FileInfo(item);
                var extension = currentFile.Extension;
                var fileName = currentFile.Name;
                var fileMemory = currentFile.Length / 1024.00;

                if (!dict.ContainsKey(extension))
                {
                    dict.Add(extension, new List<string>());
                }

                dict[extension].Add($"--{fileName} - {fileMemory:F3}kb");
            }
        }
    }
}
