using BookShopDB.Data;
using System;
using System.Linq;

namespace _8.Books_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("enter string:");
            string s = Console.ReadLine().ToLower();

            var books = ctx.Books
                .AsNoTracking()
                .Where(b=>b.Title.ToLower().Contains(s))
                .Select(b=>b.Title);

            foreach (var t in books)
            {
                Console.WriteLine(t);
            }
        }
    }
}
