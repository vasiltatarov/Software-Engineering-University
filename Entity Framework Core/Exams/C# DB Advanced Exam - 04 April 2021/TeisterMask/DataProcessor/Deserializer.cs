using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Data;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xml = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            var dtos = (ImportProjectDto[])xml.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            foreach (var projectDto in dtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = string.IsNullOrWhiteSpace(projectDto.DueDate) ?
                        (DateTime?)null :
                        DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDto.ExecutionType < 0 || taskDto.ExecutionType > 3)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskDto.LabelType < 0 || taskDto.LabelType > 4)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    });
                }

                context.Projects.Add(project);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var json = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var employeeDto in json)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };
                var uniqueTasks = employeeDto.Tasks.Distinct().ToArray();

                foreach (var taskId in uniqueTasks)
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == taskId);
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task = task,
                    });
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }
            
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}