using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Total_Book_Copies
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();

            var authors = ctx.Books
                .GroupBy(b => new { b.Author.FirstName, b.Author.LastName })
                .Select(b => new
                    { name = b.Key,
                      total = b.Sum(c => c.Copies),
                     }
                )
                .OrderByDescending(b=>b.total);

            foreach (var a in authors)
            {
                Console.WriteLine($"{a.name.FirstName} {a.name.LastName} - {a.total}");
            }
        }
    }
}
