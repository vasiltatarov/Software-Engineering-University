using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Default_Postfix = "Command";

        public string Read(string args)
        {
            var tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var commandName = tokens[0] + Default_Postfix;
            var commandArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            var result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
