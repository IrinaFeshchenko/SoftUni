namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using System.IO;
    using Models;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopSystem.Data.BookShopContext context)
        {
            SeedAuthors(context);
            SeedBooks(context);
            SeedCategories(context);
        }

        private void SeedCategories(BookShopContext context)
        {
            int booksCount = context.Books.Local.Count;
            string[] categories = File.ReadAllLines("../../Import/categories.csv");

            int i = 1;
            foreach (var c in categories.Skip(1))
            {
                string[] categoryName = c.Split(',')
                        .Select(a => a.Replace("\"", string.Empty))
                        .ToArray();

                var category = new Category() { Name = categoryName[0] };

                int bookIndex = (i++ * 30) % booksCount;

                for (int j = 0; j < bookIndex; j++)
                {
                    Book book = context.Books.Local[j];
                    category.Books.Add(book);
                }

                context.Categories.AddOrUpdate(a => new { a.Name }, category);
            }
        }

        private void SeedBooks(BookShopContext context)
        {
            int authorsCount = context.Autors.Local.Count;
            string[] books = File.ReadAllLines("../../Import/books.csv");

            int i = 1;
            foreach (var b in books.Skip(1))
            {
                int authorIndex = i++ % authorsCount;
                var author = context.Autors.Local[authorIndex];

                string[] args = b.Split(',')
                                 .Select(a => a.Replace("\"", string.Empty))
                                 .ToArray();

                var book = new Book()
                {
                    Author = author,
                    AuthorId = author.Id,
                    EditionType = (EditionType)int.Parse(args[0]),
                    ReleaseDate = DateTime.ParseExact(args[1],"d/M/yyyy", CultureInfo.InvariantCulture),
                    Copies = int.Parse(args[2]),
                    Price = decimal.Parse(args[3]),
                    AgeRestriction = (AgeRestriction)int.Parse(args[4]),
                    Title = args[5]
                };

                context.Books.AddOrUpdate(a => new { a.Title, a.AuthorId }, book);
            }
        }

        private void SeedAuthors(BookShopContext context)
        {
            string[] authors = File.ReadAllLines("../../Import/authors.csv");

            foreach (var name in authors.Skip(1))
            {
                string[] fullName = name.Split(',')
                                        .Select(a => a.Replace("\"", string.Empty))
                                        .ToArray();

                var author = new Author()
                {
                    FirstName = fullName[0],
                    LastName = fullName[1]
                };

                context.Autors.AddOrUpdate(a => new { a.FirstName, a.LastName }, author);
            }
        }
    }
}
