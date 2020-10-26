namespace P03_StudentSystem
{
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; set; }

        public void Add(string name, int age, double grade)
        {
            if (!this.Students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.Students[name] = student;
            }
        }

        public string GetDetails(string name)
        {
            if (this.Students.ContainsKey(name))
            {
                var student = Students[name];

                return student.ToString();
            }

            return null;
        }
    }
}