using System;

namespace P04_PizzaCalories.Exceptions
{
    public class GramsOutOfRangeException : Exception
    {
        private const string DEFAULT_MSG = "Dough weight should be in the range [1..200].";

        public GramsOutOfRangeException()
            : base(DEFAULT_MSG)
        {
        }

        public GramsOutOfRangeException(string message) 
            : base(message)
        {
        }
    }
}
