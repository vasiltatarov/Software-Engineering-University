namespace ClassroomProject
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string subject;

        public Student(string firstName, string lastName, string subject)
        {
            this.FirstName = firstName;
            this.LastName= lastName;
            this.Subject = subject;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }

        public override string ToString()
        {
            return $"Student: First Name = {this.FirstName}, Last Name = {this.LastName}, Subject = {this.Subject}";
        }

        public override bool Equals(object obj)
        {
            var curr = (Student)obj;

            return this.FirstName == curr.FirstName && this.LastName == curr.LastName;
        }

        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName).GetHashCode();
        }
    }
}
