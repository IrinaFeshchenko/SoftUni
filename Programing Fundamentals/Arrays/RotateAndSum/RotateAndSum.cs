

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RotateAndSum
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int k = int.Parse(Console.ReadLine());
            int len = nums.Count;
            int[] arrSum = new int[len];
            
            for (int i = 1; i <= k; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    int shiftedIndex = (len + (j - (i % len)))%len;
                    int currentValue = nums[shiftedIndex];
                    arrSum[j] += currentValue;
                }
            }

            Console.WriteLine(string.Join(" ", arrSum));
        }
    }
}
