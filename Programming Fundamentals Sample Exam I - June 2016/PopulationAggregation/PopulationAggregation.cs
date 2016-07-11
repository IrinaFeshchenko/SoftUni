

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class PopulationAggregation
    {
        static void Main()
        {
            string unwantedChars = "@#$&0123456789";
            SortedDictionary<string, long> countryCities = new SortedDictionary<string, long>();
            Dictionary<string, long> cityPopulation = new Dictionary<string, long>();

            string line;
            while ((line = Console.ReadLine()) != "stop")
            {
                string country;
                string city;
                string[] commandArgs = line.Split('\\');

                if (char.IsUpper(line[0]))
                {
                    country = commandArgs[0];
                    city = commandArgs[1];
                }
                else
                {
                    country=commandArgs[1];
                    city=commandArgs[0];               
                }

                for (int i = 0; i < unwantedChars.Length; i++)
                {
                    country = country.Replace(unwantedChars[i].ToString(), string.Empty);
                    city = city.Replace(unwantedChars[i].ToString(), string.Empty);
                }

                if (!countryCities.ContainsKey(country.ToString()))
                {
                    countryCities[country.ToString()] = 0;
                }

                countryCities[country.ToString()]++;

                cityPopulation[city.ToString()] = long.Parse(commandArgs[2]);
            }

            foreach (var country in countryCities)
            {
                Console.WriteLine("{0} -> {1}",country.Key,country.Value);
            }

            var top3CitiesByPopulation = cityPopulation
                .OrderByDescending(x=>x.Value)
                .Take(3);

            foreach (var city in top3CitiesByPopulation)
            {
                Console.WriteLine("{0} -> {1}", city.Key, city.Value);
            }  
        }
    }
}