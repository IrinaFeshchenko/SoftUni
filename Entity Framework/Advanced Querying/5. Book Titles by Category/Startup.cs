using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Book_Titles_by_Category
{
    class Startup
    {
        static void Main()
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("Enter book categories:");
            var categories = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = ctx.Books.AsNoTracking().Where(b => (b.Categories.Select(c=>c.Name.ToLower()).Intersect(categories)).Count()>0);

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
