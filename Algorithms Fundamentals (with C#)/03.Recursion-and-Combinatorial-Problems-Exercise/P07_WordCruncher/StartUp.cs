using System;
using System.Collections.Generic;

namespace P07_WordCruncher
{
    class StartUp
    {
        private static string[] words;
        private static string target;
        private static string current;
        private static Dictionary<int, List<string>> wordsByLen;
        private static HashSet<string> result = new HashSet<string>();
        private static List<string> selectedWords;
        private static Dictionary<string, int> occurences;

        static void Main()
        {
            words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsByLen = new Dictionary<int, List<string>>();
            occurences = new Dictionary<string, int>();
            selectedWords = new List<string>();

            foreach (var word in words)
            {
                if (!target.Contains(word))
                {
                    continue;
                }

                var length = word.Length;

                if (!wordsByLen.ContainsKey(length))
                {
                    wordsByLen.Add(length, new List<string>());
                }

                if (occurences.ContainsKey(word))
                {
                    occurences[word] += 1;
                }
                else
                {
                    occurences.Add(word, 1);
                }

                wordsByLen[length].Add(word);
            }

            current = string.Empty;
            GenSolutions(target.Length);    

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void GenSolutions(int len)
        {
            if (len == 0)
            {
                if (current == target)
                {
                    result.Add((string.Join(" ", selectedWords)));
                }

                return;
            }

            foreach (var (length, words) in wordsByLen)
            {
                if (length > len)
                {
                    continue;
                }

                foreach (var word in words)
                {
                    if (occurences[word] > 0)
                    {
                        current += word;

                        if (IsMatchingSoFar(target, current))
                        {
                            occurences[word] -= 1;
                            selectedWords.Add(word);
                            GenSolutions(len - word.Length);
                            occurences[word] += 1;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }

                        current = current.Remove(current.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool IsMatchingSoFar(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
