using System;

namespace P04_PizzaCalories.Exceptions
{
    public class InvalidFlourTypeException : Exception
    {
        private const string DEFAULT_MSG = "Invalid type of dough.";

        public InvalidFlourTypeException()
            : base(DEFAULT_MSG)
        {
        }

        public InvalidFlourTypeException(string message) 
            : base(message)
        {
        }
    }
}
