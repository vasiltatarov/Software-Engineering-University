using P04_Telephony.Exceptions;
using P04_Telephony.Models;

namespace P04_Telephony
{
    public class Smartphone : Phone, IBrawsable
    {
        public string Browsing(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    throw new InvalidURLException();
                }
            }

            return $"Browsing: {url}!";
        }

        public override string Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                {
                    throw new InvalidNumberException();
                }
            }

            return $"Calling... {number}";
        }
    }
}
