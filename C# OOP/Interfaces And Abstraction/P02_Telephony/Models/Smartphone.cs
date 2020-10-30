namespace P04_Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Browsing(string URL)
            => $"Browsing: {URL}!";

        public string Calling(string number)
            => $"Calling... {number}";
    }
}
