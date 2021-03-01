using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            // 2.Age Restriction
            //var input = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result);

            // 3. Golden Books
            //var goldenBooks = GetGoldenBooks(db);
            //Console.WriteLine(goldenBooks);

            //4. Books by Price
            //var booksByPrice = GetBooksByPrice(db);
            //Console.WriteLine(booksByPrice);

            //5. Not Released In
            //var year = int.Parse(Console.ReadLine());
            //var booksReleasedIn = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(booksReleasedIn);

            //6. Book Titles by Category
            //var input = Console.ReadLine();
            //var result = GetBooksByCategory(db, input);
            //Console.WriteLine(result);

            //7. Released Before Date
            //var date = Console.ReadLine();
            //var result = GetBooksReleasedBefore(db, date);
            //Console.WriteLine(result);

            //8. Author Search
            //var input = Console.ReadLine();
            //var result = GetAuthorNamesEndingIn(db, input);
            //Console.WriteLine(result);

            //9. Book Search
            //var input = Console.ReadLine();
            //var result = GetBookTitlesContaining(db, input);
            //Console.WriteLine(result);

            //10. Book Search by Author
            //var input = Console.ReadLine();
            //var result = GetBooksByAuthor(db, input);
            //Console.WriteLine(result);

            //11. Count Books
            //var length = int.Parse(Console.ReadLine());
            //var countBooks = CountBooks(db, length);
            //Console.WriteLine(countBooks);

            //12. Total Book Copies
            //var result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            //13. Profit by Category
            var result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);

            //14. Most Recent Books
            //var result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            //15. Increase Prices
            //IncreasePrices(db);

            //16. Remove Books
            //var removedBooks = RemoveBooks(db);
            //Console.WriteLine(removedBooks);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksForRemoving = context.Books
                .Where(x => x.Copies < 4200);

            var removedCount = booksForRemoving.Count();

            context.RemoveRange(booksForRemoving);
            context.SaveChanges();

            return removedCount;
        }


        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Titles = x.CategoryBooks
                        .Select(b => new
                        {
                            b.Book.Title,
                            b.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in mostRecentBooks)
            {
                sb.AppendLine($"--{book.Name}");

                foreach (var title in book.Titles)
                {
                    sb.AppendLine($"{title.Title} ({title.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfits = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profits = x.CategoryBooks
                        .Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(x => x.Profits)
                .ThenBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categoryProfits)
            {
                sb.AppendLine($"{category.Name} ${category.Profits:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Books
                .Select(x => new
                {
                    Id = x.AuthorId,
                    Name = x.Author.FirstName + " " + x.Author.LastName,
                    Copies = x.Copies,
                })
                .ToList();

            var groupedByAuthor = books
                .GroupBy(x => x.Name)
                .Select(x => new
                {
                    x.Key,
                    Copies = x.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in groupedByAuthor)
            {
                sb.AppendLine($"{author.Key} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books
                .Count(x => x.Title.Length > lengthCheck);

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new
                {
                    x.Title,
                })
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input.ToLower()))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                })
                .OrderBy(x => x.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var name in authors)
            {
                sb.AppendLine(name.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var datetime = DateTime.ParseExact(date, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value < datetime)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate,
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksCategories = context.BooksCategories
                .Where(x => categories.Contains(x.Category.Name.ToLower()))
                .Select(x => new
                {
                    x.Book.Title,
                })
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksCategories)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksReleasedIn = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksReleasedIn)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Price,
                    x.Title,
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksLessThan5000Copies = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in booksLessThan5000Copies)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context.Books
                .Select(x => new
                {
                    x.Title,
                    x.AgeRestriction,
                })
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var bookTitle in bookTitles)
            {
                if (command.ToLower() == bookTitle.AgeRestriction.ToString().ToLower())
                {
                    sb.AppendLine(bookTitle.Title);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
