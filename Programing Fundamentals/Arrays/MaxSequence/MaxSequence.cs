

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxSequence
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxStart = 0;
            int maxLen = 1;
            int start = 0;
            int len = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == nums[i-1])
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
                    maxLen = len;
                    maxStart = start;
                }
            }

            Console.WriteLine(string.Join(" ", nums.Skip(maxStart).Take(maxLen)));
        }
    }
}
