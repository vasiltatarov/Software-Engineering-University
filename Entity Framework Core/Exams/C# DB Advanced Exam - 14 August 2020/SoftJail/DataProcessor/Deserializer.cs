using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string InvalidMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departments = new List<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto) || departmentDto.Cells.Length == 0)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var department = new Department()
                {
                    Name = departmentDto.Name,
                };

                var cells = new List<Cell>();

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        cells = new List<Cell>();
                        break;
                    }

                    var cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        Department = department,
                        HasWindow = cellDto.HasWindow,
                    };

                    cells.Add(cell);
                }

                if (cells.Count == 0)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                department.Cells = cells;
                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    ReleaseDate = prisonerDto.ReleaseDate == null
                        ? (DateTime?)null
                        : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                var mails = new List<Mail>();

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(InvalidMessage);
                        mails = new List<Mail>();
                        break;
                    }

                    var mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                        Prisoner = prisoner,
                    };

                    mails.Add(mail);
                }

                if (mails.Count == 0)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                prisoner.Mails = mails;

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerPrisonerDto[]),
                new XmlRootAttribute("Officers"));

            var officersPrisonersDtos = (ImportOfficerPrisonerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var officers = new List<Officer>();

            foreach (var officerDto in officersPrisonersDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                Position position;
                var positionExist = Enum.TryParse(officerDto.Position, out position);

                Weapon weapon;
                var weaponExist = Enum.TryParse(officerDto.Weapon, out weapon);

                if (positionExist == false || weaponExist == false)
                {
                    sb.AppendLine(InvalidMessage);
                    continue;
                }

                var officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    DepartmentId = officerDto.DepartmentId,
                };

                var officersPrisoners = new List<OfficerPrisoner>();

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var prisoner = context.Prisoners.Find(prisonerDto.Id);

                    var officerPrisoner = new OfficerPrisoner()
                    {
                        Prisoner = prisoner,
                        Officer = officer,
                    };

                    officersPrisoners.Add(officerPrisoner);
                }

                officer.OfficerPrisoners = officersPrisoners;

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officersPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}