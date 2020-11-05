using System;

namespace P06_WildFarm.Exceptions
{
    public class UneatableFoodException : Exception
    {
        public UneatableFoodException()
        {
            
        }

        public UneatableFoodException(string message)
            : base(message)
        {
                
        }
    }
}
