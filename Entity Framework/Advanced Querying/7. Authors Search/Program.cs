using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Authors_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
            Console.WriteLine("enter string:");
            string s = Console.ReadLine();

            var authors = ctx.Authors
                .Where(a=>a.FirstName.Substring
                (
                    a.FirstName.Length - s.Length,
                    s.Length
                ) == s)
                .Select(a=>new { a.FirstName ,a.LastName});

            foreach (var a in authors)
            {
                Console.WriteLine($"{a.FirstName} {a.LastName}");
            }
        }
    }
}
