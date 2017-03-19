using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Count_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("enter number:");
            int n = int.Parse( Console.ReadLine());

            var books = ctx.Books
                .Where(b => b.Title.Length>n)
                .Count();

            Console.WriteLine(books);
        }
    }
}
