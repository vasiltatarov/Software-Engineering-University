using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_SchoolTeams
{
    public class StartUp
    {
        private static int CountGirlsInGroup = 3;
        private static int CountBoysInGroup = 2;

        public static void Main()
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsCombination = new string[CountGirlsInGroup];
            var boysCombination = new string[CountBoysInGroup];

            var girlsGroups = new List<List<string>>();
            var boysGroups = new List<List<string>>();

            Combination(0, 0, girlsCombination, girls, girlsGroups);
            Combination(0, 0, boysCombination, boys, boysGroups);

            CombineGroups(girlsGroups, boysGroups);
        }

        private static void CombineGroups(List<List<string>> girlsGroups, List<List<string>> boysGroups)
        {
            foreach (var girlsGroup in girlsGroups)
            {
                var currentGirlsComb = girlsGroup;

                foreach (var boysGroup in boysGroups)
                {
                    Console.WriteLine($"{string.Join(", ", currentGirlsComb)}, {string.Join(", ", boysGroup)}");
                }
            }
        }

        private static void Combination(int index,
            int startIndex,
            string[] girlsCombination,
            string[] names,
            List<List<string>> result)
        {
            if (index >= girlsCombination.Length)
            {
                result.Add(girlsCombination.ToList());
                return;
            }

            for (int i = startIndex; i < names.Length; i++)
            {
                girlsCombination[index] = names[i];
                Combination(index + 1, i + 1, girlsCombination, names, result);
            }
        }
    }
}
