using P01Logger.Core;
using P01Logger.Factories;
using P01Logger.Models;
using P01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using P01Logger.IOProvider;

namespace P01Logger
{
    public class StartUp
    {
        static void Main()
        {
            var appendersCount = int.Parse(ConsoleReader.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppender(appendersCount, appenders);

            var logger = new Logger(appenders);

            var engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppender(int appendersCount, ICollection<IAppender> appenders)
        {
            var appenderFActory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                var appenderArgs = ConsoleReader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var appenderType = appenderArgs[0];
                var layoutType = appenderArgs[1];
                var level = "Info";

                if (appenderArgs.Length == 3)
                {
                    level = appenderArgs[2];
                }

                try
                {
                    var appender = appenderFActory.ProduceAppednder(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    ConsoleWriter.WriteLine(ex.Message);
                }
            }
        }
    }
}
