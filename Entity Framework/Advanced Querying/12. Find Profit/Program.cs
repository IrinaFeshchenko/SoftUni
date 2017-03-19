using BookShopDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Find_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BookShopDBContext();
                
            var categories = ctx.Categories
                .GroupBy(ca => ca.Name)
                .Select(b => new
                {
                    name = b.Key,
                    profit = b.Sum(c => c.Books.Sum(bb=>bb.Copies*bb.Price))
                })
                .OrderByDescending(b => b.profit)
                .ThenBy(c=>c.name);;

            foreach (var c in categories)
            {
                Console.WriteLine($"{c.name} - ${c.profit}");
            }
        }
    }
}
