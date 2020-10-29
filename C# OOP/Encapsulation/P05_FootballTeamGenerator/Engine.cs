using System;
using System.Collections.Generic;

namespace P05_FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    var args = command.Split(new char[] { ';', }, StringSplitOptions.RemoveEmptyEntries);

                    if (args[0] == "Team")
                    {
                        this.teams.Add(new Team(args[1]));
                    }
                    else if (args[0] == "Add")
                    {
                        var team = this.teams.Find(x => x.Name == args[1]);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            continue;
                        }

                        var stats = new Stats(int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]));
                        var player = new Player(args[2], stats);
                        team.AddPlayer(player);
                    }
                    else if (args[0] == "Remove")
                    {
                        var team = this.teams.Find(x => x.Name == args[1]);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            continue;
                        }

                        if (!team.RemovePlayer(args[2]))
                        {
                            Console.WriteLine($"Player {args[2]} is not in {team.Name} team.");
                        }
                    }
                    else if (args[0] == "Rating")
                    {
                        var team = this.teams.Find(x => x.Name == args[1]);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {args[1]} does not exist.");
                            continue;
                        }

                        Console.WriteLine(team);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
