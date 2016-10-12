

namespace AdvertisementMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        public static void Main()
        {
            string[] phrases = new[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int rndPhrase = rnd.Next(0, phrases.Length);
                int rndEvents = rnd.Next(0, events.Length);
                int rndAuthors = rnd.Next(0, authors.Length);
                int rndCities = rnd.Next(0, cities.Length);

                string phrase = phrases[rndPhrase];
                string _event = events[rndEvents];
                string author = authors[rndAuthors];
                string city = cities[rndCities];

                Console.WriteLine($"{phrase} {_event} {author} - {city}");
            }
        }
    }
}
