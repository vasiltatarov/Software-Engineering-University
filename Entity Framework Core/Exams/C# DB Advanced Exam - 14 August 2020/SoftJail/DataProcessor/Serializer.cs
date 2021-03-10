using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .ToList()//
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers
                        .Select(ps => new
                        {
                            OfficerName = ps.Officer.FullName,
                            Department = ps.Officer.Department.Name,
                        })
                        .OrderBy(ps => ps.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(o => o.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",");

            var prisonerDtos = context.Prisoners
                .Where(x => names.Contains(x.FullName))
                .Select(x => new ExportPrisonerDto()
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails
                        .Select(m => new ExportMailDto()
                        {
                            Description = ReverseDescription(m.Description),
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), prisonerDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string ReverseDescription(string description)
        {
            var sb = new StringBuilder();

            for (int i = description.Length - 1; i >= 0; i--)
            {
                sb.Append(description[i]);
            }

            return sb.ToString().TrimEnd();
        }
    }
}