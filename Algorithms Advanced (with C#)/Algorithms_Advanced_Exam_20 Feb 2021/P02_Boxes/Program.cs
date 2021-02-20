using System;
using System.Collections.Generic;

namespace P02_Boxes
{
    public class Box
    {
        public int Width { get; set; }

        public int Depth { get; set; }

        public int Height { get; set; }
    }

    class Program
    {
        private static List<Box> items;

        static void Main()
        {
            var boxesCount = int.Parse(Console.ReadLine());

            items = ReadItems(boxesCount);

            var len = new int[items.Count];

            var prev = new int[items.Count];
            var bestLen = 0;
            var lastIdx = 0;

            for (int i = 0; i < items.Count; i++)
            {
                prev[i] = -1;
                var currentBox = items[i];
                var currentBestSeq = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevBox = items[j];

                    if (prevBox.Width < currentBox.Width && prevBox.Depth < currentBox.Depth && prevBox.Height < currentBox.Height &&
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

            var bestSequence = ReconstructBestSequence(lastIdx, items, prev);

            foreach (var box in bestSequence)
            {
                Console.WriteLine($"{box.Width} {box.Depth} {box.Height}");
            }
        }

        private static Stack<Box> ReconstructBestSequence(int lastIdx, List<Box> boxes, int[] prev)
        {
            var bestSequence = new Stack<Box>();

            while (lastIdx != -1)
            {
                bestSequence.Push(boxes[lastIdx]);
                lastIdx = prev[lastIdx];
            }

            return bestSequence;
        }

        private static List<Box> ReadItems(int boxesCount)
        {
            var result = new List<Box>();

            for (int i = 0; i < boxesCount; i++)
            {
                var data = Console.ReadLine().Split();

                var width = int.Parse(data[0]);
                var depth = int.Parse(data[1]);
                var height = int.Parse(data[2]);

                result.Add(new Box()
                {
                    Width = width,
                    Depth = depth,
                    Height = height,
                });
            }

            return result;
        }
    }
}
