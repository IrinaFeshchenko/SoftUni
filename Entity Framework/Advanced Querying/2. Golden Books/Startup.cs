
namespace _2.Golden_Books
{
    using BookShopDB.Data;
    using System;
    using System.Linq;

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Golden Edition Books:");
            Console.WriteLine("----------------------");

            var context = new BookShopDBContext();

            var goldenBooksTitles = context.Books
                                .Where(b => b.EditionType == (int)EditionType.Gold && b.Copies < 5000)
                                .OrderBy(b => b.Id)
                                .Select(b => b.Title)
                                .ToList();

            foreach (var title in goldenBooksTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
 