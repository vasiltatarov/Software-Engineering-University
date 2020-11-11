using System;
using CommandPattern.Core.Contracts;
using CommandPattern.IOProvider;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            while (true)
            {
                var input = reader.ReadLine();

                try
                {
                    var result = this._commandInterpreter.Read(input);
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
