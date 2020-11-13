using P01Logger.Enumerations;
using P01Logger.Models.Contracts;
using System;
using System.Globalization;

namespace P01Logger.Models.IOManager
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)  
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public int AppendedMessages { get; private set; }

        public void Append(IError error)
        {
            var format = this.Layout.Format;

            var dateTime = error.DateTime;  
            var level = error.Level;
            var message = error.Message;

            var formattedMessage = string.Format(format, dateTime.ToString("M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture), level.ToString(), message);
            this.AppendedMessages++;

            Console.WriteLine(formattedMessage);
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString().ToUpper()}, Messages appended: {this.AppendedMessages}";
        }
    }
}
