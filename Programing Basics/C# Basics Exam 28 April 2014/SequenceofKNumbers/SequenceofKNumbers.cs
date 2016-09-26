

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SequenceofKNumbers
    {
        static void Main()
        {
            long[] nums = Console.ReadLine().Split()
                        .Select(long.Parse)
                        .ToArray();
            int k = int.Parse(Console.ReadLine());

            List<long> res = new List<long>();
            long count = 0;

            for (long i = 0; i < nums.Length; i++)
            {
                if (res.Count > 0)
                {
                    if (res.Last() == nums[i])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                    res.Add(nums[i]);
                }
                else
                {
                    count = 1;
                    res.Add(nums[i]);
                }

                if (count == k)
                {
                    count = 0;
                    res.RemoveRange(res.Count - k, k);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
}
