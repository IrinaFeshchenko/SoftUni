namespace _08.Map_Districts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<string> populationCount = Console.ReadLine()
                                           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

            long minimum = long.Parse(Console.ReadLine());


            var towns = populationCount.Select(x => new { town = x.Split(':')[0], population = long.Parse(x.Split(':')[1]) })
                                        .GroupBy(x => x.town)
                                        .Where(x => x.Select(p => p.population).Sum() > minimum)
                                        .OrderByDescending(x => x.Select(p => p.population).Sum());

            foreach (var town in towns)
            {
                Console.WriteLine($"{town.Key}: {string.Join(" ",town.Select(x=>x.population).OrderByDescending(x=>x).Take(5))}");
            }
        }
    }
}
