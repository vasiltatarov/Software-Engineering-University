using System;

namespace P04_PizzaCalories.Exceptions
{
    public class InvalidBakingTypeException : Exception
    {
        public InvalidBakingTypeException(string message) 
            : base(message)
        {
        }
    }
}
