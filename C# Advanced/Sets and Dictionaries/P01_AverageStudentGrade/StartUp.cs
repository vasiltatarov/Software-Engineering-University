using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_AverageStudentGrade
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();
                var name = args[0];
                var grade = decimal.Parse(args[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<decimal>());
                }

                dict[name].Add(grade);
            }

            foreach (var (name, grades) in dict)
            {
                Console.WriteLine($"{name} -> {PrintGrades(grades)} (avg: {grades.Average():F2})");
            }
        }

        private static string PrintGrades(List<decimal> grades)
        {
            var sb = new StringBuilder();

            foreach (var grade in grades)
            {
                sb.Append($"{grade:F2} ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
