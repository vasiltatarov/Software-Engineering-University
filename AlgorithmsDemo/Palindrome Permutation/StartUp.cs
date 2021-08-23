using System;

namespace PalindromePermutation
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            bool isPalindromePermutation = IsPalindromePermutation(input);

            Console.WriteLine($"Is are '{input}' palindrome permutation? = {isPalindromePermutation} ..");
        }

        public static bool IsPalindromePermutation(string str)
        {
            var charCount = new int[128];

            for (int i = 0; i < str.Length; i++)
            {
                charCount[str[i]]++;
            }

            var count = 0;

            for (int i = 0; i < charCount.Length; i++)
            {
                count += charCount[i] % 2;
            }

            return count <= 1;
        }
    }
}
