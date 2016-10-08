

namespace SrubskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Start
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, decimal>> venues = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                Regex rg = new Regex(@"(?<singer>(\w+ )+)@(?<venue>(\w+ )+)(?<ticketPrice>\d+ )(?<ticketCount>\d+)");
                Match match = rg.Match(input);

                if (match.Value == string.Empty)
                {
                    continue;
                }

                string venue = match.Groups["venue"].Value.Trim();
                string singer = match.Groups["singer"].Value.Trim();
                string ticketPrice = match.Groups["ticketPrice"].Value.Trim();
                string ticketCount = match.Groups["ticketCount"].Value.Trim();
                decimal profit = decimal.Parse(ticketCount) * decimal.Parse(ticketPrice);

                if (!venues.ContainsKey(venue))
                {
                    venues.Add(venue, new Dictionary<string, decimal>());
                }

                if (!venues[venue].ContainsKey(singer))
                {
                    venues[venue].Add(singer,0);
                }

                venues[venue][singer] += profit;
            }

            foreach (var venue in venues)
            {
                Console.WriteLine($"{venue.Key}");

                var sortedSingers = venue.Value.OrderByDescending(x => x.Value);

                foreach (var item in sortedSingers)
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
