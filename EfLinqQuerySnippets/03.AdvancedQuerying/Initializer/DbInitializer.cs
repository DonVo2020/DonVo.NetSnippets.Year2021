using EfLinqQuerySnippets._03.AdvancedQuerying.Data;
using EfLinqQuerySnippets._03.AdvancedQuerying.Initializer.Generators;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using System;

namespace EfLinqQuerySnippets._03.AdvancedQuerying.Initializer
{
    public class DbInitializer
    {
        public static void ResetDatabase(BookShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("BookShop database created successfully.");

            Seed(context);
        }

        public static void Seed(BookShopContext context)
        {
            Book[] books = BookGenerator.CreateBooks();

            context.Books.AddRange(books);

            context.SaveChanges();

            Console.WriteLine("Sample data inserted successfully.");
        }
    }
}
