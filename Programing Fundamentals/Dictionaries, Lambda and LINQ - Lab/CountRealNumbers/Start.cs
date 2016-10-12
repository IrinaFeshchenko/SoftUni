
namespace CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            SortedDictionary<double, int> result = new SortedDictionary<double, int>();

            foreach (var num in nums)
            {
                if (result.ContainsKey(num))
                {
                    result[num]++;
                }
                else
                {
                    result.Add(num, 1);
                }
            }

            foreach (var num in result)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
