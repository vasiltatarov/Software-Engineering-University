using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_LongestZigzagSubsequence
{
    /// <summary>
    /// A zigzag sequence is one that alternately increases and decreases. More formally,
    /// such a sequence has to comply with one of the two rules below:
    /// 1)	Every even element is smaller than its neighbors and every odd element is larger than its neighbors, or
    /// 2)	Every odd element is smaller than its neighbors and every even element is larger than its neighbors
    /// 1 3 2 is a zigzag sequence, but 1 2 3 is not.Any sequence of one or two elements is zig zag.
    /// Find the longest zigzag subsequence in a given sequence.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dp = new int[2, sequence.Length];
            dp[0, 0] = 1;
            dp[1, 0] = 1;

            var parent = new int[2, sequence.Length];
            parent[0, 0] = -1;
            parent[1, 0] = -1;

            var bestSize = 0;
            var lastColIdx = 0;
            var lastRowIdx = 0;

            for (int current = 0; current < sequence.Length; current++)
            {
                var currentNumber = sequence[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevNumber = sequence[prev];

                    if (currentNumber > prevNumber &&
                        dp[1, prev] + 1 >= dp[0, current])
                    {
                        dp[0, current] = dp[1, prev] + 1;
                        parent[0, current] = prev;
                    }

                    if (currentNumber < prevNumber &&
                        dp[0, prev] + 1 >= dp[1, current])
                    {
                        dp[1, current] = dp[0, prev] + 1;
                        parent[1, current] = prev;
                    }
                }

                if (dp[0, current] > bestSize)
                {
                    bestSize = dp[0, current];

                    lastRowIdx = 0;
                    lastColIdx = current;
                }

                if (dp[1, current] > bestSize)
                {
                    bestSize = dp[1, current];

                    lastRowIdx = 1;
                    lastColIdx = current;
                }
            }

            var zigZagSeq = new Stack<int>();

            while (lastColIdx != -1)
            {
                zigZagSeq.Push(sequence[lastColIdx]);
                lastColIdx = parent[lastRowIdx, lastColIdx];

                if (lastRowIdx == 0)
                {
                    lastRowIdx = 1;
                }
                else
                {
                    lastRowIdx = 0;
                }
            }

            Console.WriteLine(string.Join(" ", zigZagSeq));
        }
    }
}
