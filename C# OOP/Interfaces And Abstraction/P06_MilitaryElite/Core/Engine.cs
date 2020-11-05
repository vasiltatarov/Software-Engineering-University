using System;
using System.Linq;
using System.Collections.Generic;
using P07MilitaryElite.Models;
using P07MilitaryElite.IO.Contracts;

namespace P07MilitaryElite
{
    public class Engine
    {
        private List<ISoldier> soldiers;
        private List<IPrivate> privates;
        private Iwriter writer;
        private IReader reader;

        public Engine(Iwriter consoleWriter, IReader consoleReader)
        {
            this.soldiers = new List<ISoldier>();
            this.privates = new List<IPrivate>();
            this.writer = consoleWriter;
            this.reader = consoleReader;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadLine();

                    if (command == "End")
                    {
                        break;
                    }

                    var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (args[0] == "Private")
                    {
                        var @private = new Private(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));
                        this.privates.Add(@private);
                        this.soldiers.Add(@private);
                    }
                    else if (args[0] == "LieutenantGeneral")
                    {
                        var lieutenant = new LieutenantGeneral(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));
                        var privateIds = args.Skip(5).ToArray();

                        foreach (var privateId in privateIds)
                        {
                            var find = this.privates.Find(x => x.Id == int.Parse(privateId));

                            if (find != null)
                            {
                                lieutenant.AddPrivate(find);
                            }
                        }

                        this.soldiers.Add(lieutenant);
                    }
                    else if (args[0] == "Engineer")
                    {
                        var repairs = args.Skip(6).ToArray();
                        var engineer = new Engineer(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), args[5]);

                        for (int i = 6; i < args.Length; i += 2)
                        {
                            try
                            {
                                engineer.AddRepair(new Repair(args[i], int.Parse(args[i + 1])));
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }

                        this.soldiers.Add(engineer);
                    }
                    else if (args[0] == "Commando")
                    {
                        var commando = new Commando(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), args[5]);

                        for (int i = 6; i < args.Length; i += 2)
                        {
                            try
                            {
                                commando.AddMission(new Mission(args[i], args[i + 1]));
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }

                        this.soldiers.Add(commando);
                    }
                    else if (args[0] == "Spy")
                    {
                        var spy = new Spy(int.Parse(args[1]), args[2], args[3], int.Parse(args[4]));
                        this.soldiers.Add(spy);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            PrintAllSoldiers();
        }

        private void PrintAllSoldiers()
        {
            foreach (var soldier in this.soldiers)
            {
                try
                {
                    this.writer.WriteLine(soldier.ToString());
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}