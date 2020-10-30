namespace P04_Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Calling(string number)
            => $"Dialing... {number}";
    }
}
