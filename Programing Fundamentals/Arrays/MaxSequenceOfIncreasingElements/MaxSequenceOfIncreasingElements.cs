

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxSequenceOfIncreasingElements
    {
        static void Main()
        {
            List<long> nums = Console.ReadLine().Split().Select(long.Parse).ToList();

            int maxStart = 0;
            int maxLen = 1;
            int start = 0;
            int len = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    len++;
                }
                else
                {
                    start = i;
                    len = 1;
                }

                if (len > maxLen)
                {
                    maxStart = start;
                    maxLen = len;
                }
            }

            Console.WriteLine(string.Join(" ",nums.Skip(maxStart).Take(maxLen)));
        }
    }
}
