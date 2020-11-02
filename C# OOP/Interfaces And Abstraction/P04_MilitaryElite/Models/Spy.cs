using P07MilitaryElite.Contracts;
using System.Text;

namespace P07MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int spyCodeNumber) 
            : base(id, firstName, lastName)
        {
            this.SpyCodeNumber = spyCodeNumber;
        }

        public int SpyCodeNumber { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
                .AppendLine($"Code Number: {this.SpyCodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
