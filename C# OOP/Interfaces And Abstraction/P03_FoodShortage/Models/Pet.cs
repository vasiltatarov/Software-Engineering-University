using P05_BorderControl.Interfaces;
using System;

namespace P05_BorderControl.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }
        public DateTime Birthday { get; private set; }
    }
}
