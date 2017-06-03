namespace _10.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> population = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string[] args = Console.ReadLine()
                                       .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (args[0] == "report")
                {
                    break;
                }

                string city = args[0];
                string country = args[1];
                long people = long.Parse(args[2]);

                if (!population.ContainsKey(country))
                {
                    population.Add(country, new Dictionary<string, long>());
                }

                population[country].Add(city, people);
            }

            // order countries by total population
            var sortedCountries = population.OrderByDescending(x => x.Value.Select(y => y.Value).Sum());

            foreach (var country in sortedCountries)
            {
                long totalPopulation = country.Value.Select(x => x.Value).Sum();

                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                // order cities by population
                var orderedCities = country.Value.OrderByDescending(x => x.Value);

                foreach (var city in orderedCities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
