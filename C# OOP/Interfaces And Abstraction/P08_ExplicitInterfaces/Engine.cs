using P08_ExplicitInterfaces.Contracts;
using System;

namespace P08_ExplicitInterfaces
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var person = new Citizen(args[0], args[1], int.Parse(args[2]));
                IPerson iResident = person;
                IResident iPerson = person;

                Console.WriteLine(iResident.GetName());
                Console.WriteLine(iPerson.GetName());
            }
        }
    }
}
