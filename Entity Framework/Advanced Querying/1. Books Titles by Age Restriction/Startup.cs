
namespace _1.Books_Titles_by_Age_Restriction
{
    using BookShopDB.Data;
    using System;
    using System.Linq;

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }

    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter age category:");
            string input  = Console.ReadLine().Trim();

            AgeRestriction ageRestriction = (AgeRestriction) Enum.Parse(typeof(AgeRestriction), input, true);

            var context = new BookShopDBContext();

            var bookTitles = context.Books
                                    .Where(b=>b.AgeRestriction == (int)ageRestriction)
                                    .Select(b=>b.Title)
                                    .ToList();

            foreach (var title in bookTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
