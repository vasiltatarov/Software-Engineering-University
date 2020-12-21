﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_DividingPresents
{
    class Program
    {
        static void Main()
        {
            var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sums = CalcSums(presents);
            var totalScore = presents.Sum();
            var bobScore = GetBobScore(sums, totalScore);

            var alanScore = totalScore - bobScore;
            var diff = bobScore - alanScore;
            var alanPresents = GetPresents(sums, alanScore);

            Console.WriteLine($"Difference: {diff}");
            Console.WriteLine($"Alan:{alanScore} Bob:{bobScore}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetPresents(Dictionary<int, int> sums, int target)
        {
            var presents = new List<int>();

            while (target != 0)
            {
                var present = sums[target];
                presents.Add(present);

                target -= present;
            }

            return presents;
        }

        private static int GetBobScore(Dictionary<int, int> sums, int totalScore)
        {
            var bobScore = (int)Math.Ceiling(totalScore / 2.0);

            while (!sums.ContainsKey(bobScore))
            {
                bobScore++;
            }

            return bobScore;
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };

            foreach (var number in numbers)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, number);
                    }
                }
            }

            return result;
        }
    }
}
