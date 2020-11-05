using System;

namespace P07MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string DEF_STATE_EXC = "Invalid state!";

        public InvalidStateException()
            : base(DEF_STATE_EXC)
        {
        }

        public InvalidStateException(string message)
            : base(message)
        {
        }
    }
}
