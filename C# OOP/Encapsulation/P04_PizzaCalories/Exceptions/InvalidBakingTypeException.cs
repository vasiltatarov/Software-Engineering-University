using System;

namespace P04_PizzaCalories.Exceptions
{
    public class InvalidBakingTypeException : Exception
    {
        public const string DEFAULT_MSG = "Cannot place {0} on top of your pizza.";

        public InvalidBakingTypeException()
            : base(DEFAULT_MSG)
        {
        }

        public InvalidBakingTypeException(string message) 
            : base(message)
        {
        }
    }
}
