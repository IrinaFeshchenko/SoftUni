namespace School_Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var categories = new Dictionary<string, SortedSet<string>>();
            var results = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var parts = input.Split();
                var name = parts[0];
                var category = parts[1];
                var points = int.Parse(parts[2]);

                if (!categories.ContainsKey(name))
                {
                    categories.Add(name, new SortedSet<string>());
                }

                categories[name].Add(category);

                if (!results.ContainsKey(name))
                {
                    results.Add(name, 0);
                }

                results[name] += points;
            }

            var orderedResult = results.OrderByDescending(p => p.Value).ThenBy(p => p.Key);

            foreach (var player in orderedResult)
            {
                var orderedCategories = categories[player.Key].OrderBy(c => c);

                string listCategories = string.Join(", ", orderedCategories);
                Console.WriteLine($"{player.Key}: {player.Value} [{listCategories}]");
            }
        }
    }
}