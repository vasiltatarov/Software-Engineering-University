using System;
using System.IO;
using System.Text;

namespace Full_Directory_Traversal
{
    public class StartUp
    {
        static void Main()
        {
            var path = Console.ReadLine();  //Example:  "D:\GitHubRepos\Software-Engineering-University\C# Advanced"
            var directories = Directory.GetDirectories(path);

            var allFilesAndDirectories = new StringBuilder();

            TraverseDirectories(directories, 2, allFilesAndDirectories);

            Console.WriteLine(allFilesAndDirectories.ToString().TrimEnd());
        }

        private static void TraverseDirectories(string[] directories, int indent, StringBuilder allFilesAndDirectories)
        {
            foreach (var directory in directories)
            {
                var currentDirectory = Directory.GetDirectories(directory);

                var dir = new FileInfo(directory);
                allFilesAndDirectories.AppendLine($"Dir:{new string('-', indent)}{dir.Name}");

                var files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    allFilesAndDirectories.AppendLine($"File:{new string('-', indent)}{fileInfo.Name}");
                }

                allFilesAndDirectories.AppendLine();

                TraverseDirectories(currentDirectory, indent + 2, allFilesAndDirectories);
            }
        }
    }
}
