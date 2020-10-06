using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Func<string, int, bool> sumNameFunc = (name, x) =>
            {
                var sumOfCharacters = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sumOfCharacters += name[i];
                }

                if (sumOfCharacters >= x)
                {
                    return true;
                }

                return false;
            };

            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(x => sumNameFunc(x, n)).ToArray();

            Func<string[], Func<string, int, bool>, string> findFirstNameWithEqualOrLargerSum = (arr, func) =>
            {
                foreach (var name in arr)
                {
                    if (func.Invoke(name, n))
                    {
                        return name;
                    }
                }

                return null;
            };

            var result = findFirstNameWithEqualOrLargerSum(names, sumNameFunc);

            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}
