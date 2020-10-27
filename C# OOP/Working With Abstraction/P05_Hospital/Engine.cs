using System;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }

        public void Procces()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Output")
                {
                    break;
                }

                var args = command.Split();
                var departmentName = args[0];
                var firstName = args[1];
                var secondName = args[2];
                var patient = args[3];

                var doctor = new Doctor(firstName, secondName);
                var department = new Department(departmentName);

                this.hospital.AddDoctor(doctor);
                this.hospital.AddDepartment(department);

                this.hospital.AddPatientToDoctorList(patient, doctor.FullName);
                this.hospital.AddPatientInDepartment(patient, departmentName);
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                var args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(this.hospital.PrintPatientsInDepartment(args[0]));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var sorted = this.hospital.PrintPatientsInDepartmentRoom(args[0], room).Split(Environment.NewLine);

                    foreach (var patient in sorted.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var fullName = args[0] + " " + args[1];
                    var sorted = this.hospital.PrintPatientsFromDoctor(fullName).Split(Environment.NewLine);

                    foreach (var patient in sorted.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}
