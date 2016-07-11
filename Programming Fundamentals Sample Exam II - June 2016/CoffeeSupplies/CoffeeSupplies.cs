

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CoffeeSupplies
    {
        private static Dictionary<string, int> cofeeQuantity = new Dictionary<string, int>();
        private static Dictionary<string, string> personCofee = new Dictionary<string, string>();
        static void Main()
        {
            string[] delimiter = Console.ReadLine().Split().ToArray();
            string info;
            while ((info = Console.ReadLine()) != "end of info")
            {
                if (info.Contains(delimiter[0]))
                {
                    string[] part = info.Split(new string[] { delimiter[0] }, StringSplitOptions.None).ToArray();
                    personCofee.Add(part[0], part[1]);

                    if (!cofeeQuantity.ContainsKey(part[1]))
                    {
                        cofeeQuantity[part[1]] = 0;
                    }
                }
                else if (info.Contains(delimiter[1]))
                {
                    string[] part = info.Split(new string[] { delimiter[1] }, StringSplitOptions.None).ToArray();
                    if (!cofeeQuantity.ContainsKey(part[0]))
                    {
                        cofeeQuantity[part[0]] = 0;
                    }
                    cofeeQuantity[part[0]] += int.Parse(part[1]);
                }
            }

            while ((info = Console.ReadLine()) != "end of week")
            {
                string[] part = info.Split().ToArray();
                string cofee = personCofee[part[0]];
                cofeeQuantity[cofee] = cofeeQuantity[cofee] - int.Parse(part[1]);
            }

            foreach (var item in cofeeQuantity)
            {
                if (item.Value <= 0)
                {
                    Console.WriteLine("Out of {0}", item.Key);
                }
            }

            Console.WriteLine("Coffee Left:");
            foreach (var item in cofeeQuantity.OrderByDescending(x => x.Value))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
                }
            }

            Console.WriteLine("For:");
            foreach (var item in personCofee.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (cofeeQuantity[item.Value] > 0)
                {
                    Console.WriteLine("{0} {1}", item.Key, item.Value);
                }
            }
        }
    }
}
