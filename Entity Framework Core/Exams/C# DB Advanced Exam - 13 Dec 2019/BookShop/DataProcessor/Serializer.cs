using System.Collections.Generic;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ExportDto;

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                        .OrderByDescending(b => b.Book.Price)
                        .Select(b => new
                        {
                            BookName = b.Book.Name,
                            BookPrice = $"{b.Book.Price:F2}",
                        })
                        .ToList(),
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count)
                .ThenBy(x => x.AuthorName);

            var json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .Select(x => new ExportBookDto
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), new XmlRootAttribute("Books"));
            xmlSerializer.Serialize(new StringWriter(sb), books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}