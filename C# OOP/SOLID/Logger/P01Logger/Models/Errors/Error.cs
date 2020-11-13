using P01Logger.Enumerations;
using P01Logger.Models.Contracts;
using System;

namespace P01Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }   

        public Level Level { get; private set; }

        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }
    }
}
