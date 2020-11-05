using P04_Telephony.Exceptions;
using P04_Telephony.Models;

namespace P04_Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                {
                    throw new InvalidNumberException();
                }
            }

            return $"Dialing... {number}";
        }
    }
}
