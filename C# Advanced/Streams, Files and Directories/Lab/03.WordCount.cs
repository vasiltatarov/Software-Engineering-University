using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, int>();
            var wordsReader = new StreamReader(@"..\..\..\words.txt"); // Create file with words separate by space!
            var words = wordsReader.ReadToEnd().Split();
            FilledDictionary(dict, words);

            var textReader = new StreamReader(@"..\..\..\text.txt"); // Create text for searched words! 
            var text = textReader.ReadToEnd().Split(new char[] { ' ', '.', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
            FindRepeatableWords(dict, text);

            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using var writer = new StreamWriter(@"..\..\..\Output.txt");
            WriteOutput(dict, writer);
        }

        private static void WriteOutput(Dictionary<string, int> dict, StreamWriter writer)
        {
            foreach (var item in dict)
            {
                writer.WriteLine($"{item.Key} - {item.Value}");
            }
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

        private static void FilledDictionary(Dictionary<string, int> dict, string[] words)
        {
            foreach (var word in words)
            {
                var currentWord = word.ToLower();

                if (!dict.ContainsKey(currentWord))
                {
                    dict.Add(currentWord, 0);
                }
            }
        }
    }
}
