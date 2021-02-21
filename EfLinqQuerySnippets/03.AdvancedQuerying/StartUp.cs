using EfLinqQuerySnippets._03.AdvancedQuerying.Data;
using EfLinqQuerySnippets._03.AdvancedQuerying.Initializer;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EfLinqQuerySnippets._03.AdvancedQuerying
{
    public class AdvancedQueryingStartup
    {
        public static void Run()
        {
            using (BookShopContext db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                ////01
                //Console.WriteLine("Enter one of these (teen/adult/minor)");
                //string input = Console.ReadLine();
                //string result = GetBooksByAgeRestriction(db, input);
                //Console.WriteLine(result);

                ////02
                //string result = GetGoldenBooks(db);
                //Console.WriteLine(result);

                ////03
                //string result = GetBooksByPrice(db);
                //Console.WriteLine(result);

                ////04
                //int inputYear = int.Parse(Console.ReadLine());
                //string result = GetBooksNotReleasedIn(db, inputYear);
                //Console.WriteLine(result);

                ////05
                //string categories = Console.ReadLine();
                //string result = GetBooksByCategory(db, categories);
                //Console.WriteLine(result);

                ////06
                //string date = Console.ReadLine();
                //string result = GetBooksReleasedBefore(db, date);
                //Console.WriteLine(result);

                ////07
                //string input = Console.ReadLine();
                //string result = GetAuthorNamesEndingIn(db, input);
                //Console.WriteLine(result);

                ////08
                //string input = Console.ReadLine();
                //string result = GetBookTitlesContaining(db, input);
                //Console.WriteLine(result);

                ////09
                //string input = Console.ReadLine();
                //string result = GetBooksByAuthor(db, input);
                //Console.WriteLine(result);

                ////10
                //int length = int.Parse(Console.ReadLine());
                //int result = CountBooks(db, length);
                //Console.WriteLine(result);

                ////11
                //string result = CountCopiesByAuthor(db);
                //Console.WriteLine(result);

                ////12
                //string result = GetTotalProfitByCategory(db);
                //Console.WriteLine(result);

                ////13
                //string result = GetMostRecentBooks(db);
                //Console.WriteLine(result);

                ////15
                //int result = RemoveBooks(db);
                //Console.WriteLine(result);

                //Console.WriteLine(result);

                //DbInitializer.ResetDatabase(db);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int enumCommand = -1;

            switch (command.ToLower())
            {
                case "minor": enumCommand = 0; break;
                case "teen": enumCommand = 1; break;
                case "adult": enumCommand = 2; break;
            }

            var books = context
                .Books
                .Where(b => (int)b.AgeRestriction == enumCommand)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    b.BookId,
                    b.Copies,
                    b.Title,
                    b.EditionType
                })
                .Where(b => b.Copies < 5000 && (int)b.EditionType == 2)
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    Categories = b.BookCategories.Select(bc => new
                    {
                        bc.Category.Name
                    }),
                })
                .Where(b => b.Categories.Any(c => categories.Contains(c.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime inputDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Date < inputDate.Date)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine($"{title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .Where(b => b.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    b.Title
                })
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();


            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(a => new
                {
                    Copies = a.Books.Sum(b => b.Copies),
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderByDescending(b => b.Copies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    BooksPrice = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.BooksPrice)
                .ThenBy(c => c.Name);

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.BooksPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                            .Select(cb => new
                            {
                                cb.Book.Title,
                                cb.Book.ReleaseDate
                            })
                            .OrderByDescending(cb => cb.ReleaseDate)
                            .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            //There's a better solution to this

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5m;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }
    }
}
