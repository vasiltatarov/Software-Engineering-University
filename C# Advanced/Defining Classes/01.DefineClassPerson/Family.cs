using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private SortedSet<Person> members;

        public Family()
        {
            this.members = new SortedSet<Person>();
        }

        public IReadOnlyCollection<Person> Members
        {
            get
            {
                return this.members;
            }
        }

        public void AddMember(Person member)
        {
            if (member.Age <= 30)
            {
                return;
            }

            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(p => p.Age).First();
        }

        public List<Person> OrderedMembers()
        {
            return this.members.Where(x => x.Age > 30).ToList();
        }
    }
}
