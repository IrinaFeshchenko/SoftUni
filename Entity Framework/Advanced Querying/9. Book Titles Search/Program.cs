using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Book_Titles_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("enter string:");
            string s = Console.ReadLine().ToLower();

            var books = ctx.Books
                .Where(b => b.Author.LastName.Substring(0, s.Length).ToLower() == s)
                .OrderBy(b => b.Id)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName });

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title} ({b.FirstName} {b.LastName})");
            }
        }
    }
}
