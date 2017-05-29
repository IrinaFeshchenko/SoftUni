using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Remove_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            var tran = ctx.Database.BeginTransaction();

            var books = ctx.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            ctx.Books.RemoveRange(books);
            ctx.SaveChanges();
            Console.WriteLine($"{books.Count} books were deleted");
            tran.Rollback();
        }
    }
}
