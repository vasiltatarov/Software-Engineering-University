using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Engine
    {
        private List<Person> persons;
        private Team team;

        public Engine()
        {
            this.persons = new List<Person>();
            this.team = new Team("SoftUni");
        }

        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                try
                {
                    var person = new Person(cmdArgs[0],
                                            cmdArgs[1],
                                            int.Parse(cmdArgs[2]),
                                            decimal.Parse(cmdArgs[3]));

                    this.persons.Add(person);
                    this.team.AddPlayer(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.team);

            //var parcentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(parcentage));
            //persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
