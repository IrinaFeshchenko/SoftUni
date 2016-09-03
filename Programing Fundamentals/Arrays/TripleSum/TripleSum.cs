

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TripleSum
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool exist = false;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums.Contains(nums[i] + nums[j]))
                    {
                        Console.WriteLine($"{nums[i]} + {nums[j]} == {nums[i] + nums[j]}");
                        exist = true;
                    }
                }
            }

            if (!exist)
            {
                Console.WriteLine("No");
            }
        }
    }
}
