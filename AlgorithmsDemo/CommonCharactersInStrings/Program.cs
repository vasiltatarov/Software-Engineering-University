using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCharactersInStrings
{
    /// <summary>
    /// да се напише функция, която получава като параметър 2 стринга.
    /// Като резултат да върне друг стринг, съдържащ само символите, които се срещат едновременно и в двата входни стринга:
    /// </summary>
    class Program
    {
        public static int MAX_CHAR = 26;

        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            PrintCommon(s1, s2);

            //PrintCommonSimple(s1, s2);
        }

        public static void PrintCommon(string s1, string s2)
        {

            int[] a1 = new int[MAX_CHAR];
            int[] a2 = new int[MAX_CHAR];

            int length1 = s1.Length;
            int length2 = s2.Length;

            for (int i = 0; i < length1; i++)
                a1[s1[i] - 'a'] += 1;

            for (int i = 0; i < length2; i++)
                a2[s2[i] - 'a'] += 1;

            for (int i = 0; i < MAX_CHAR; i++)
            {
                if (a1[i] != 0 && a2[i] != 0)
                {
                    for (int j = 0; j < Math.Min(a1[i], a2[i]); j++)
                        Console.Write(((char)(i + 'a')));
                }
            }
        }

        public static void PrintCommonSimple(string s1, string s2)
        {
            var set = new HashSet<char>();

            for (int i = 0; i < s1.Length; i++)
            {
                if (s2.Contains(s1[i]))
                {
                    set.Add(s1[i]);
                }
            }

            Console.WriteLine(string.Join("", set));
        }
    }
}
