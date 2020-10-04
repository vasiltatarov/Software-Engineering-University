using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, int>();

            var words = File.ReadAllLines(@"..\..\..\words.txt");
            ReadWords(words, dict);

            var text = File.ReadAllText(@"..\..\..\text.txt")
                .Split(new char[] { '-', ',', '.', '!', '?', '\'', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            FindRepeatableWords(dict, text);

            string result = RepeatableWordsAsString(dict);
            File.WriteAllText(@"..\..\..\actualResult.txt", result);

            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var orderedResult = RepeatableWordsAsString(dict);

            File.WriteAllText(@"..\..\..\expectedResult.txt", orderedResult);
        }

        private static string RepeatableWordsAsString(Dictionary<string, int> dict)
        {
            var sb = new StringBuilder();

            foreach (var (word, times) in dict)
            {
                sb.AppendLine($"{word} - {times}");
            }

            return sb.ToString().TrimEnd();
        }
        private static void FindRepeatableWords(Dictionary<string, int> dict, string[] text)
        {
            foreach (var word in text)
            {
                var currentWord = word.ToLower();

                if (dict.ContainsKey(currentWord))
                {
                    dict[currentWord]++;
                }
            }
        }

        private static void ReadWords(string[] words, Dictionary<string, int> dict)
        {
            foreach (var word in words)
            {
                var currWord = word.ToLower();

                if (!dict.ContainsKey(currWord))
                {
                    dict.Add(currWord, 0);
                }
            }
        }
    }
}
