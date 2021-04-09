using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Microsoft.EntityFrameworkCore.Internal;
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
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
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
                    Duration = movieDto.Duration,
                    Director = movieDto.Director,
                    Rating = movieDto.Rating,
                };

                context.Movies.Add(movie);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre.ToString()} and rating {movie.Rating:F2}!");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var halls = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);
            var sb = new StringBuilder();

            foreach (var hallDto in halls)
            {
                if (!IsValid(hallDto) ||
                    hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        Hall = hall,
                    });
                }

                context.Halls.Add(hall);
                context.SaveChanges();

                var projection = "Normal";
                if (hall.Is4Dx && hall.Is3D)
                {
                    projection = "4Dx/3D";
                } 
                else if (hall.Is3D || hall.Is4Dx)
                {
                    projection = hall.Is4Dx ? "4Dx" : "3D";
                }

                sb.AppendLine($"Successfully imported {hall.Name}({projection}) with {hall.Seats.Count} seats!");
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

                var hall = context.Halls.FirstOrDefault(x => x.Id == projectionDto.HallId);
                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                if (hall == null || movie == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    Hall = hall,
                    Movie = movie,
                };

                context.Projections.Add(projection);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported projection {projection.Movie.Title} on {projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}!");
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
                if (!IsValid(customerDto))
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