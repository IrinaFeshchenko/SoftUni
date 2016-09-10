

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MostFrequentNumber
    {
        static void Main()
        {
            Dictionary<int, int> numsCounts = new Dictionary<int, int>();

            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (!numsCounts.ContainsKey(nums[i]))
                {
                    numsCounts.Add(nums[i],1);
                }
                else
                {
                    numsCounts[nums[i]]++;
                }        
            }

            var maxValue = numsCounts.Values.Max();
            var maxKey = numsCounts.FirstOrDefault(x => x.Value == maxValue).Key;

            Console.WriteLine(maxKey);
        }
    }
}
