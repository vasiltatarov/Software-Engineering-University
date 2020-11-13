using P01Logger.Core.Contracts;
using P01Logger.Factories;
using P01Logger.Models.Contracts;
using System;
using P01Logger.IOProvider;

namespace P01Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                var command = ConsoleReader.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var splittedCommand = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                var level = splittedCommand[0];
                var time = splittedCommand[1];
                var message = splittedCommand[2];

                try
                {
                    var error = this.errorFactory.ProduceError(time, message, level);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {
                    ConsoleWriter.WriteLine(ex.Message);
                }
            }

            ConsoleWriter.WriteLine(this.logger.ToString());
        }
    }
}
