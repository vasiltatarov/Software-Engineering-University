using P04_Hospital.Models;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new Room[20];
            this.InitializeBeds();
            this.CountPatient = 0;
        }

        public string Name { get; set; }
        public Room[] Rooms { get; set; }
        public int CountPatient { get; set; }

        public void AddPatient(string name)
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.Rooms[i].Beds[j] == null)
                    {
                        this.Rooms[i].Beds[j] = name;
                        this.CountPatient++;
                        return;
                    }
                }
            }
        }

        private void InitializeBeds()
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                this.Rooms[i] = new Room();
            }
        }
    }
}
