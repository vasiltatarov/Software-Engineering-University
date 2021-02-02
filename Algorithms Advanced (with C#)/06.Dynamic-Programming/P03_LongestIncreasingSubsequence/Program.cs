using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var len = new int[numbers.Length];

            var prev = new int[numbers.Length];
            var bestLen = 0;
            var lastIdx = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                prev[i] = -1;
                var currentNumber = numbers[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (prevNumber < currentNumber &&
                        len[j] + 1 >= currentBestSeq)
                    {
                        currentBestSeq = len[j] + 1;
                        prev[i] = j;
                    }
                }

                if (currentBestSeq > bestLen)
                {
                    bestLen = currentBestSeq;
                    lastIdx = i;
                }

                len[i] = currentBestSeq;
            }

            var bestSequence = ReconstructBestSequence(lastIdx, numbers, prev);

            Console.WriteLine(string.Join(" ", bestSequence));
        }

        private static Stack<int> ReconstructBestSequence(int lastIdx, int[] numbers, int[] prev)
        {
            var bestSequence = new Stack<int>();

            while (lastIdx != -1)
            {
                bestSequence.Push(numbers[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            return bestSequence;
        }
    }
}
