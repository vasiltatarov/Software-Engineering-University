using System;
using System.Linq;

namespace _07.Tuple
{
    public class StartUp
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            Threeuple<string, string, string> firstTuple = ProccesFirstTuple(firstLine);

            var secondLine = Console.ReadLine().Split();
            Threeuple<string, int, bool> secondTuple = ProccesSecondTuple(secondLine);

            var thirdLine = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdTuple = ProccesThirdTuple(thirdLine);

            PrintTuples(firstTuple, secondTuple, thirdTuple);
        }

        private static void PrintTuples(Threeuple<string, string, string> firstTuple,
            Threeuple<string, int, bool> secondTuple, Threeuple<string, double, string> thirdTuple)
        {
            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }

        private static Threeuple<string, double, string> ProccesThirdTuple(string[] thirdLine)
        {
            var name = thirdLine[0];
            var @double = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];
            var thirdTuple = new Threeuple<string, double, string>(name, @double, bankName);
            return thirdTuple;
        }

        private static Threeuple<string, int, bool> ProccesSecondTuple(string[] secondLine)
        {
            var name = secondLine[0];
            var amountOfBeer = int.Parse(secondLine[1]);
            var drunk = secondLine[2];
            var isDrunk = false;

            if (drunk == "drunk")
            {
                isDrunk = true;
            }

            var secondTuple = new Threeuple<string, int, bool>(name, amountOfBeer, isDrunk);
            return secondTuple;
        }

        private static Threeuple<string, string, string> ProccesFirstTuple(string[] firstLine)
        {
            var fullName = $"{firstLine[0]} {firstLine[1]}";
            var address = firstLine[2];
            var town = firstLine.Skip(3).ToArray();
            var firstTuple = new Threeuple<string, string, string>(fullName, address, string.Join(" ", town));
            return firstTuple;
        }
    }
}
