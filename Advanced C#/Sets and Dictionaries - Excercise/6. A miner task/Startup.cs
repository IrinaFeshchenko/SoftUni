namespace _6.A_miner_task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main()
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string input = string.Empty;

            while ((input = Console.ReadLine())!="stop")
            {
                string resourceName = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resourceName))
                {
                    resources.Add(resourceName,quantity);
                }
                else
                {
                    resources[resourceName] += quantity;
                }
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
