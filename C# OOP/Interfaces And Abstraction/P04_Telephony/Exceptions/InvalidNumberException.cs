using System;

namespace P04_Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string Default_Message = "Invalid number!";

        public InvalidNumberException()
            : base(Default_Message)
        {
        }

        public InvalidNumberException(string message)
            : base(Default_Message)
        {
        }
    }
}
