

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EqualSums
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int index = -1;
            for (int i = 0; i < nums.Count; i++)
            {
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += nums[j];
                }

                int rightSum = 0;
                for (int j = i + 1; j < nums.Count; j++)
                {
                    rightSum += nums[j];
                }

                if (leftSum == rightSum)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
