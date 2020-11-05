namespace P04_Telephony.Models
{
    public abstract class Phone : ICallable
    {
        public abstract string Call(string number);
    }
}
