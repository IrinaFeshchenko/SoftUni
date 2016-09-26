

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountNumbers
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary<int, int> result = new SortedDictionary<int, int>();

            foreach (var num in nums)
            {
                if (result.ContainsKey(num))
                {
                    result[num]++;
                }
                else
                {
                    result.Add(num,1);
                }
            }

            foreach (var num in result)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
