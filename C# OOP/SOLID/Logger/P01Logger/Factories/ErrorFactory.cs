using P01Logger.Enumerations;
using P01Logger.Models.Contracts;
using P01Logger.Models.Errors;
using System;
using System.Globalization;

namespace P01Logger.Factories
{
    public class ErrorFactory
    {
        private const string DATE_FORMAT = "M/dd/yyyy h:mm:ss tt";

        public IError ProduceError(string dateSTr, string messageStr, string levelStr)
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateSTr, DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid Date format!", ex);
            }

            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelStr, true, out level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level type!");
            }

            var error = new Error(dateTime, messageStr, level);

            return error;
        }
    }
}
