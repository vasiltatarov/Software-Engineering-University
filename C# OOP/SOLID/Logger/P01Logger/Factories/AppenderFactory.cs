using P01Logger.Enumerations;
using P01Logger.Models;
using P01Logger.Models.Appenders;
using P01Logger.Models.Contracts;
using P01Logger.Models.Files;
using P01Logger.Models.IOManager;
using System;

namespace P01Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppednder(string appenderType, string layoutType, string levelType)
        {
            Level level;

            bool hasParse = Enum.TryParse<Level>(levelType, true, out level);

            if (!hasParse)
            {
                throw new ArgumentException("Invalid level type!"); 
            }

            var layout = this.layoutFactory.ProduceLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender") 
            {
                IFile file = new LogFile("../../../../", "logs.txt");

                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new Exception("Invalid appender type!");
            }

            return appender;
        }
    }
}
