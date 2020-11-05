using System;

namespace P04_Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string Default_Message = "Invalid URL!";

        public InvalidURLException()
            : base(Default_Message)
        {
        }

        public InvalidURLException(string message)
            : base(Default_Message)
        {
        }
    }
}
