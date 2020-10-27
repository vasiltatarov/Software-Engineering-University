using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Patients = new List<string>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName => this.FirstName + " " + this.SecondName; 
        public List<string> Patients { get; set; }

        public void AddPatient(string name)
        {
            this.Patients.Add(name);
        }
    }
}
