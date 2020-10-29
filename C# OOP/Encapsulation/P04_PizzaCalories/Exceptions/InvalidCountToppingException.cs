using System;

namespace P04_PizzaCalories.Exceptions
{
    public class InvalidCountToppingException : Exception
    {
        private const string DEFAULT_MSG = "Number of toppings should be in range [0..10].";

        public InvalidCountToppingException()
            : base(DEFAULT_MSG)
        {
        }

        public InvalidCountToppingException(string message) 
            : base(message)
        {
        }
    }
}
