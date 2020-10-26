using System;
using System.Linq;

namespace P02_PointInRectangle
{
    public class StartUp
    {
        static void Main()
        {
            var rectangleCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            var rectangle = MakeRectangle(rectangleCoords);

            for (int i = 0; i < n; i++)
            {
                var pointCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var point = new Point(pointCoords[0], pointCoords[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static Rectangle MakeRectangle(int[] rectangleCoords)
        {
            var topLeftX = rectangleCoords[0];
            var topLeftY = rectangleCoords[1];
            var bottomRightX = rectangleCoords[2];
            var bottomRightY = rectangleCoords[3];

            var topLeftCorner = new Point(topLeftX, topLeftY);
            var bottomRightCorner = new Point(bottomRightX, bottomRightY);

            return new Rectangle(topLeftCorner, bottomRightCorner);
        }
    }
}
