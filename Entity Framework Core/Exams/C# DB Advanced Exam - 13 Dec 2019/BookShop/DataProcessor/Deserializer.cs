using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));
            var dtos = (ImportBookDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var importBookDto in dtos)
            {
                if (!IsValid(importBookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (importBookDto.Genre <= 0 || importBookDto.Genre > 3)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = importBookDto.Name,
                    Pages = importBookDto.Pages,
                    Price = importBookDto.Price,
                    Genre = (Genre)importBookDto.Genre,
                    PublishedOn = DateTime.ParseExact(importBookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                };

                context.Books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:F2}.");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var json = (ImportAuthorDto[])JsonConvert.DeserializeObject(jsonString, typeof(ImportAuthorDto[]));

            foreach (var importAuthorDto in json)
            {
                if (!IsValid(importAuthorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Authors.Any(x => x.Email == importAuthorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = importAuthorDto.FirstName,
                    LastName = importAuthorDto.LastName,
                    Email = importAuthorDto.Email,
                    Phone = importAuthorDto.Phone,
                };

                foreach (var bookDto in importAuthorDto.Books)
                {
                    var book = context.Books.FirstOrDefault(x => x.Id == bookDto.Id);

                    if (bookDto == null || book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Authors.Add(author);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
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