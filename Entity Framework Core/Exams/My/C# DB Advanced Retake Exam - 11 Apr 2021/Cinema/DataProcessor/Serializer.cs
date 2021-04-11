using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var data = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Any()))
                .ToArray()
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections
                    .Sum(p => p.Tickets
                        .Sum(t => t.Price)))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = x.Projections
                        .SelectMany(p => p.Tickets)
                        .Select(t => new
                        {
                            FirstName = t.Customer.FirstName,
                            LastName = t.Customer.LastName,
                            Balance = t.Customer.Balance.ToString("F2"),
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray(),
                })
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var data = context.Customers
                .Where(x => x.Age >= age)
                .ToArray()
                .Select(x => new ExportCustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = decimal.Parse(x.Tickets.Sum(t => t.Price).ToString("F2")),
                    SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                        .ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture),
                })
                .OrderByDescending(x => x.SpentMoney)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var xml = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));
            xml.Serialize(new StringWriter(sb), data, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}