
namespace _2.Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int n = nums[0];
            int m = nums[1];

            Dictionary<int, int> elements = new Dictionary<int, int>();

            for (int i = 0; i < n + m; i++)
            {
                int element = int.Parse(Console.ReadLine());

                if (!elements.ContainsKey(element))
                {
                    elements.Add(element, 0);
                }

                elements[element]++;
            }

            foreach (var e in elements)
            {
                if (e.Value>1)
                {
                    Console.Write(e.Key+" ");
                }
            }
        }
    }
}
