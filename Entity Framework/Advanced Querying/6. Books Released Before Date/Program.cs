namespace _6.Books_Released_Before_Date
{
    using BookShopDB.Data;
    using System;
    using System.Globalization;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter release date");
            string input = Console.ReadLine();
            var releaseDate = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);

            var ctx = new BookShopDBContext();
            var books = ctx.Books.Where(b => b.ReleaseDate < releaseDate)
                                 .Select(b=>new {b.Title,b.EditionType,b.Price})
                                 .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {(EditionType)book.EditionType} - {book.Price}");
            }
        }
    }

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }
}
