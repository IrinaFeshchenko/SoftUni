

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumAdjacentEqualNumbers
    {
        static void Main()
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == nums[i-1])
                {
                    nums[i-1] = (nums[i] * 2);
                    nums.RemoveAt(i);
                    i = Math.Max(i - 2, 0);
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
