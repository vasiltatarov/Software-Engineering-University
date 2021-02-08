using System;
using System.Collections.Generic;

namespace P03_LongestStringChain
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine().Split();

            var len = new int[words.Length];
            var parent = new int[words.Length];

            var longestStringChain = 0;
            var lastIdx = 0;

            for (int current = 0; current < words.Length; current++)
            {
                len[current] = 1;
                parent[current] = -1;

                var currentWord = words[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevWord = words[prev];

                    if (currentWord.Length > prevWord.Length &&
                        len[prev] + 1 >= len[current])
                    {
                        len[current] = len[prev] + 1;
                        parent[current] = prev;
                    }
                }

                if (len[current] > longestStringChain)
                {
                    lastIdx = current;
                    longestStringChain = len[current];
                }
            }

            var stack = new Stack<string>();

            while (lastIdx != -1)
            {
                stack.Push(words[lastIdx]);
                lastIdx = parent[lastIdx];
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
