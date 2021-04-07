using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDto
                {
                    ProjectName = x.Name,
                    TasksCount = x.Tasks.Count,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks
                        .ToArray()
                        .Select(t => new ExportTaskDto
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString(),
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));
            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                        .ToArray()
                        .Where(et => et.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Length)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}