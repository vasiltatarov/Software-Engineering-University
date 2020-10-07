using System;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int DifferenceBetweenTwoDates(string first, string second)
        {
            var firstDate = ProccesDateTime(first);
            var secondDate = ProccesDateTime(second);

            var diff = secondDate.Subtract(firstDate).Days;

            return Math.Abs(diff);
        }

        private static DateTime ProccesDateTime(string date)
        {
            var args = date.Split(" ");
            var year = int.Parse(args[0]);
            var month = int.Parse(args[1]);
            var day = int.Parse(args[2]);

            return new DateTime(year, month, day);
        }
    }
}
