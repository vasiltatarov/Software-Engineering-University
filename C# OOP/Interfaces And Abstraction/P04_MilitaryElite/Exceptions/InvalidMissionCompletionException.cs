using System;

namespace P07MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_MISSION_EXC = "Mission already completed!";

        public InvalidMissionCompletionException()
            : base(DEF_MISSION_EXC)
        {
        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {

        }
    }
}
