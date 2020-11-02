using System;

namespace P07MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid corps!";

        public InvalidCorpsException()
            : base(DEF_EXC_MSG)
        {
        }

        public InvalidCorpsException(string message)
            : base(message)
        {
        }
    }
}
