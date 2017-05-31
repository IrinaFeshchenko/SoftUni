namespace _12.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        const long requiredItemsCount = 250;
        public static void Main()
        {
            Dictionary<string, string> artefact = new Dictionary<string, string>();
            artefact.Add("shards", "Shadowmourne");
            artefact.Add("fragments", "Valanyr");
            artefact.Add("motes", "Dragonwrath");

            Dictionary<string, long> items = new Dictionary<string, long>();
            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            Dictionary<string, long> junkItems = new Dictionary<string, long>();
            string winner = string.Empty;

            while (winner == string.Empty)
            {
                string[] args = Console.ReadLine()
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < args.Length; i += 2)
                {
                    long itemCount = long.Parse(args[i]);
                    string itemName = args[i + 1].ToLower();

                    if (items.ContainsKey(itemName))
                    {
                        items[itemName] += itemCount;

                        if (items[itemName] >= requiredItemsCount)
                        {
                            winner = itemName;
                            items[itemName] -= requiredItemsCount;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(itemName))
                        {
                            junkItems.Add(itemName, 0);
                        }
                        junkItems[itemName] += itemCount;
                    }
                }

            }

            Console.WriteLine($"{artefact[winner]} obtained!");

            var sortedItems = items.OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            var sortedJunkItems = junkItems.OrderBy(x => x.Key);
            foreach (var item in sortedJunkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
