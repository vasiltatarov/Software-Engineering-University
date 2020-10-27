using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Hospital
    {
        private List<Department> departments;
        private List<Doctor> doctors;

        public Hospital()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!this.doctors.Any(x => x.FullName == doctor.FullName))
            {
                this.doctors.Add(doctor);
            }
        }

        public void AddDepartment(Department department)
        {
            if (!this.departments.Any(x => x.Name == department.Name))
            {
                this.departments.Add(department);
            }
        }

        public void AddPatientToDoctorList(string patient, string fullName)
        {
            var doctor = this.doctors.Find(x => x.FullName == fullName);

            if (doctor != null)
            {
                doctor.AddPatient(patient);
            }
        }

        public void AddPatientInDepartment(string patient, string departmentName)
        {
            var department = this.departments.Find(x => x.Name == departmentName);

            if (department != null && department.CountPatient < 60)
            {
                department.AddPatient(patient);
            }
        }

        public string PrintPatientsInDepartment(string name)
        {
            var department = this.departments.Find(x => x.Name == name);

            if (department == null)
            {
                return "Department is empty!";
            }

            var sb = new StringBuilder();

            for (int i = 0; i < department.Rooms.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (department.Rooms[i].Beds[j] == null)
                    {
                        return sb.ToString().TrimEnd();
                    }
                    else
                    {
                        sb.AppendLine(department.Rooms[i].Beds[j]);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string PrintPatientsInDepartmentRoom(string name, int room)
        {
            var department = this.departments.Find(x => x.Name == name);

            if (department == null || room <= 0 || room > 20)
            {
                return "Department is empty!";
            }

            var sb = new StringBuilder();

            for (int i = 0; i < department.Rooms.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (department.Rooms[i].Beds[j] == null)
                    {
                        return sb.ToString().TrimEnd();
                    }
                    else
                    {
                        sb.AppendLine(department.Rooms[i].Beds[j]);
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string PrintPatientsFromDoctor(string name)
        {
            var doctor = this.doctors.Find(x => x.FullName == name);

            if (doctor == null)
            {
                return "Department is empty!";
            }

            var sb = new StringBuilder();

            foreach (var patient in doctor.Patients)
            {
                sb.AppendLine(patient);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
