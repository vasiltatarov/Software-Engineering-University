using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private HashSet<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new HashSet<Student>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }
        public int GetStudentsCount => this.Count;
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                if (!this.students.Contains(student))
                {
                    this.students.Add(student);
                    return $"Added student {student.FirstName} {student.LastName}";
                }
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student != null)
            {
                this.students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            var sb = new StringBuilder();
            var studentsWithThisSubjects = this.students.Where(x => x.Subject == subject).ToArray();

            if (studentsWithThisSubjects.Length == 0)
            {
                return "No students enrolled for the subject";
            }

            sb
                .AppendLine($"Subject: {subject}")
                .AppendLine("Students:");

            foreach (var student in studentsWithThisSubjects)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student != null)
            {
                return student;
            }
            else
            {
                return null;
            }
        }
    }
}
