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

            var xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]),
                new XmlRootAttribute("Books"));

            var booksDtos = (ImportBookDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var books = new List<Book>();

            foreach (var bookDto in booksDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                var isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out publishedOn);
                if (isDateValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book()
                {
                    Name = bookDto.Name,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    Genre = (Genre)bookDto.Genre,
                    PublishedOn = publishedOn,
                };

                books.Add(book);

                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            var authors = new List<Author>();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                var books = new List<Book>();

                foreach (var bookDto in authorDto.Books)
                {
                    if (bookDto.Id == null)
                    {
                        continue;
                    }

                    var book = context.Books.FirstOrDefault(x => x.Id == bookDto.Id.Value);
                    if (book == null)
                    {
                        continue;
                    }

                    books.Add(book);
                }

                if (books.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var authorsBooks = new List<AuthorBook>();

                foreach (var book in books)
                {
                    var authorBook = new AuthorBook()
                    {
                        Author = author,
                        Book = book,
                    };
                    authorsBooks.Add(authorBook);
                }

                author.AuthorsBooks = authorsBooks;
                authors.Add(author);

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, books.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

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