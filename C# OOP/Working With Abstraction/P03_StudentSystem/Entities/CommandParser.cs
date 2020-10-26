using System.Linq;

namespace P03_StudentSystem
{
    public class CommandParser
    {
        public string Name { get; set; }
        public string[] Arguments { get; set; }

        public static CommandParser ParseCommand(string text)
        {
            var args = text.Split();

            if (args.Length < 1)
            {
                return null;
            }

            return new CommandParser
            {
                Name = args[0],
                Arguments = args.Skip(1).ToArray()
            };
        }
    }
}
