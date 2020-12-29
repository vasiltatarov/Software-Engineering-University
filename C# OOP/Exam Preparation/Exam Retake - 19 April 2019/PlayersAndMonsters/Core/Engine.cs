using System;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine   
    {
        private IWriter writer;
        private IReader reader;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                var line = reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                var args = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = args[0];

                string result = string.Empty;

                try
                {
                    result = ExecuteCommand(command, args);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                    continue;
                }

                this.writer.WriteLine(result);
            }
        }

        private string ExecuteCommand(string command, string[] args)
        {
            string result = string.Empty;

            if (command == "AddPlayer")
            {
                var type = args[1];
                var username = args[2];

                result = this.managerController.AddPlayer(type, username);
            }
            else if (command == "AddCard")
            {
                var type = args[1];
                var name = args[2];

                result = this.managerController.AddCard(type, name);
            }
            else if (command == "AddPlayerCard")
            {
                var username = args[1];
                var cardName = args[2];

                result = this.managerController.AddPlayerCard(username, cardName);
            }
            else if (command == "Fight")
            {
                var attackUser = args[1];
                var enemyUser = args[2];

                result = this.managerController.Fight(attackUser, enemyUser);
            }
            else if (command == "Report")
            {
                result = this.managerController.Report();
            }

            return result;
        }
    }
}
