using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Increase_Book_Copies
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            var tran = ctx.Database.BeginTransaction();

            var date = DateTime.ParseExact("06 Jun 2013", "d MMM yyyy", CultureInfo.InvariantCulture);
            var books = ctx.Books
                .Where(b=>b.ReleaseDate > date)
                .ToList();

            int addedBookCopies = 0;
            foreach (var b in books)
            {
                b.Copies += 44;
                addedBookCopies += 44;
            }
            Console.WriteLine(addedBookCopies);
            tran.Rollback();
        }
    }
}
