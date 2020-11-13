using P01Logger.Enumerations;
using P01Logger.Models.Contracts;

namespace P01Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public int AppendedMessages { get; private set; }
        public IFile File { get; private set; }

        public void Append(IError error)
        {
            var formattedFormat = this.File.Write(this.Layout, error);
             
            System.IO.File.AppendAllText(this.File.Path, formattedFormat);
            this.AppendedMessages++;
        }

        public override string ToString() 
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.AppendedMessages}, File size: {this.File.Size}";
        }
    }
}
