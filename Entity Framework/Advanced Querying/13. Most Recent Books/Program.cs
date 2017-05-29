using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Most_Recent_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();

            var categories = ctx.Categories
                .OrderByDescending(c=>c.Books.Count);

            foreach (var cat in categories)
            {
                Console.WriteLine($"--{cat.Name}: {cat.Books.Count}");

                var books = cat.Books
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3);

                foreach (var b in books)
                {
                    Console.WriteLine($"{b.Title} ({b.ReleaseDate.Year})");
                }
            }
        }
    }
}
