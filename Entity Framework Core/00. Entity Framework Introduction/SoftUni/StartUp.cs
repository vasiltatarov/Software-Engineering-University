using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    /// <summary>
    /// dotnet tool install --global dotnet-ef
    /// Scaffold-DbContext -Connection "Server=.;Database=SoftUni;Integrated Security=true;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    /// <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.3" />
    /// </summary>
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            // Problem 3.Employees Full Information
            //var employees = GetEmployeesFullInformation(context);
            //Console.WriteLine(employees);

            //Problem 4.Employees with Salary Over 50 000
            //var employeesWithSalaries = GetEmployeesWithSalaryOver50000(context);
            //Console.WriteLine(employeesWithSalaries);

            //Problem 5.Employees from Research and Development
            //var employeesFromDepartment = GetEmployeesFromResearchAndDevelopment(context);
            //Console.WriteLine(employeesFromDepartment);

            // Problem 6.Adding a New Address and Updating Employee
            //var addresses = AddNewAddressToEmployee(context);
            //Console.WriteLine(addresses);

            // Problem 7.Employees and Projects
            //var employees = GetEmployeesInPeriod(context);
            //Console.WriteLine(employees);

            // Problem 8.Addresses by Town
            //var addresses = GetAddressesByTown(context);
            //Console.WriteLine(addresses);

            // Problem 9.Employee 147
            //var employee = GetEmployee147(context);
            //Console.WriteLine(employee);

            // Problem 9.Employee 147
            //var employee = GetEmployee147(context);
            //Console.WriteLine(employee);


            // Problem 10.Departments with More Than 5 Employees
            //var departments = GetDepartmentsWithMoreThan5Employees(context);
            //Console.WriteLine(departments);

            // Problem 11.Find Latest 10 Projects
            //var projects = GetLatestProjects(context);
            //Console.WriteLine(projects);

            // Problem 12.Increase Salaries
            //var increaseSalaries = IncreaseSalaries(context);
            //Console.WriteLine(increaseSalaries);

            // Problem 13.Find Employees by First Name Starting with "Sa"
            //var employeesStartingWith = GetEmployeesByFirstNameStartingWithSa(context);
            //Console.WriteLine(employeesStartingWith);

            // Problem 14.Delete Project by Id
            //var projects = DeleteProjectById(context);
            //Console.WriteLine(projects);

            // Problem 15.Remove Town
            var removedTowns = RemoveTown(context);
            Console.WriteLine(removedTowns);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            if (town == null)
            {
                throw new InvalidOperationException();
            }

            var addressesIds = town.Addresses
                .Select(x => x.AddressId)
                .ToList();

            // First set EmployeeId to null from employees who have those town Id
            var employeesOnThisAddress = context.Employees
                .Where(x => x.AddressId.HasValue && addressesIds.Contains(x.AddressId.Value))
                .ToList();

            foreach (var employee in employeesOnThisAddress)
            {
                employee.AddressId = null;
            }

            // Second delete all addresses who have those town Id
            foreach (var addressesId in addressesIds)
            {
                var address = context.Addresses.Find(addressesId);

                context.Addresses.Remove(address);
            }

            // And then delete town who have name Seattle
            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addressesIds.Count} addresses in Seattle were deleted";
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectWithId2 = context.Projects.Find(2);

            if (projectWithId2 == null)
            {
                throw new InvalidOperationException();
            }

            // Delete from employees projects
            var employeesProjects = context.EmployeesProjects
                .Where(x => x.Project.ProjectId == 2)
                .ToList();

            foreach (var employeesProject in employeesProjects)
            {
                context.EmployeesProjects.Remove(employeesProject);
            }

            // Delete from projects
            context.Projects.Remove(projectWithId2);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => new
                {
                    x.Name,
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            
            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var increasedEmployees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToList();

            foreach (var increasedEmployee in increasedEmployees)
            {
                increasedEmployee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                })
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb
                    .AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmployeesCount = d.Employees
                        .Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle,
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList(),
                })
                .OrderBy(d => d.DepartmentName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.EmployeesCount)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}r");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(name => name)
                        .ToList(),
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            if (employee == null)
            {
                throw new InvalidOperationException();
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var projectName in employee.Projects)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count,
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            Name = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue
                                ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                : "not finished"
                        })
                        .ToList(),
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            var employeeWithLastNameNakov = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            if (employeeWithLastNameNakov == null)
            {
                throw new InvalidOperationException();
            }

            employeeWithLastNameNakov.Address = newAddress;

            context.SaveChanges();

            var employees = context.Employees
                .Select(x => new
                {
                    Id = x.AddressId,
                    AddressText = x.Address.AddressText,
                })
                .OrderByDescending(x => x.Id)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var address in employees)
            {
                sb.AppendLine(address.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    FirsName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary,
                    DepartmentName = x.Department.Name,
                })
                .Where(x => x.DepartmentName == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirsName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirsName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    Id = x.EmployeeId,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary,
                })
                .OrderBy(x => x.Id)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
