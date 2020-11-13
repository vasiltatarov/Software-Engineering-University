using P01Logger.Models.Contracts;
using System.IO;

namespace P01Logger.Models.IOManagement
{
    public class IOManagers : IIOManager
    {
        private string currentPath;
        private string folderName;
        private string fileName;

        private IOManagers()
        {
            this.currentPath = this.GetCurrentDirectoryes();
        }

        public IOManagers(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectoryes()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            return currentDirectory;
        }
    }
}
