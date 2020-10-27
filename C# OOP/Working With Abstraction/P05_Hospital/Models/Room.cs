namespace P04_Hospital.Models
{
    public class Room
    {
        public Room()
        {
            this.Beds = new string[3];
        }

        public string[] Beds { get; set; }
    }
}
