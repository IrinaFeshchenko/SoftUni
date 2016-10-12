

namespace BookLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public string MyProperty { get; set; }
    }

    public class Library
    {
        public Library()
        {
            this.Books = new List<Book>();
        }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Library library = ParseInput(n);

            var authors = library.Books.GroupBy(x => x.Author).OrderByDescending(x=>x.Select(y=>y.Price).Sum()).ThenBy(z=>z.Key);

            foreach (var book in authors)
            {
                Console.WriteLine($"{book.Key} -> {book.Select(x=>x.Price).Sum():f2}");
            }
        }

        private static Library ParseInput(int n)
        {
            Library library = new Library();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Book book = new Book();

                book.Title = args[0];
                book.Author = args[1];
                book.Publisher = args[2];
                book.ReleaseDate = DateTime.ParseExact(args[3], "d.M.yyyy", CultureInfo.InvariantCulture);
                book.ISBN = args[4];
                book.Price = decimal.Parse(args[5]);

                library.Books.Add(book);
            }
            return library;
        }
    }
}
