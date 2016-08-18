

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumOfElements
    {
        static void Main()
        {
            long[] nums = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();

            long sum = nums.Sum();
            long result = -1;
            long minDifference = long.MaxValue;
            for (long i = 0; i < nums.Length; i++)
            {
                long number = nums[i];
                long difference = Math.Abs(sum - number * 2);
                if (difference ==0)
                {
                    result = number;
                }
                else
                {
                    if (difference<minDifference)
                    {
                        minDifference = difference;
                    }
                }
            }

            if (result>=0)
            {
                Console.WriteLine("Yes, sum={0}",result);
            }
            else
            {
                Console.WriteLine("No, diff={0}",minDifference);
            }
        }
    }
}
