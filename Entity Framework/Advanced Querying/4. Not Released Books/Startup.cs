namespace _4.Not_Released_Books
{
    using BookShopDB.Data;
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new BookShopDBContext();

            Console.WriteLine("Enter a book release year that will be excluded:");
            int year = int.Parse(Console.ReadLine());

            var books = context.Books
                               .Where(b => b.ReleaseDate.Year != year)
                               .OrderBy(b => b.Id);

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
