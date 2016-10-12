namespace BookLibraryModification
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
        public string Isbn { get; set; }
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
            var n = int.Parse(Console.ReadLine());

            var library = ParseInput(n);

            var books = library.Books.OrderBy(x=>x.ReleaseDate).ThenBy(z => z.Title);

            var date = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in books)
            {
                if (book.ReleaseDate > date)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}");
                }
            }
        }

        private static Library ParseInput(int n)
        {
            var library = new Library();

            for (var i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var book = new Book();

                book.Title = args[0];
                book.Author = args[1];
                book.Publisher = args[2];
                book.ReleaseDate = DateTime.ParseExact(args[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                book.Isbn = args[4];
                book.Price = decimal.Parse(args[5]);

                library.Books.Add(book);
            }

            return library;
        }
    }
}
