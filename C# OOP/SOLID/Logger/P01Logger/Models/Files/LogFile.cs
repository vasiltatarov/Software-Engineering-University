using System;
using System.Globalization;
using System.IO;
using System.Linq;
using P01Logger.Models.Contracts;
using P01Logger.Models.IOManagement;

namespace P01Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManagers IOManagers;

        public LogFile(string folderName, string fileName)
        {
            this.IOManagers = new IOManagers(folderName, fileName);
            this.IOManagers.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManagers.CurrentFilePath;

        public long Size => this.GetFileSize();


        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;

            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            var formattedMessage = string.Format(format, dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture), message, level.ToString().ToUpper()) + Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            var text = File.ReadAllText(this.Path);

            long size = text.Where(x => char.IsLetter(x)).Sum(x => x);

            return size;
        }
    }
}
