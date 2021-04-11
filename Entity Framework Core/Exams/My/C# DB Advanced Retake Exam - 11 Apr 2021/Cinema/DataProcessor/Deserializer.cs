using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movies = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var movieDto in movies)
            {
                if (!IsValid(movieDto) ||
                    context.Movies.Any(x => x.Title == movieDto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = movieDto.Genre.Value,
                    Duration = TimeSpan.ParseExact(movieDto.Duration, "c", CultureInfo.InvariantCulture),
                    Director = movieDto.Director,
                    Rating = movieDto.Rating,
                };

                context.Movies.Add(movie);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre.ToString()} and rating {movie.Rating:F2}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var dtos = (ImportProjectionDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var projectionDto in dtos)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                if (movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateTime;
                var isValidDate = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    DateTime = dateTime,
                    MovieId = projectionDto.MovieId,
                };

                context.Projections.Add(projection);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported projection {movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var dtos = (ImportCustomerDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var customerDto in dtos)
            {
                if (!IsValid(customerDto) || 
                    !customerDto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    var projection = context.Projections.FirstOrDefault(x => x.Id == ticketDto.ProjectionId);

                    if (!IsValid(ticketDto) || projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    customer.Tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        Projection = projection,
                    });
                }

                context.Customers.Add(customer);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
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