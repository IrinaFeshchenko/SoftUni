
namespace _3.Books_by_Price
{
    using BookShopDB.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new BookShopDBContext();

            var books = context.Books
                                .Where(b => b.Price < 5m || b.Price > 40m)
                                .OrderBy(b => b.Id);

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }
    }
}
