

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CondenseArrayToNumber
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (nums.Count > 1)
            {
                List<int> condensed = new List<int>();
                for (int i = 0; i < nums.Count - 1; i++)
                {             
                    condensed.Add(nums[i] + nums[i + 1]);
                }
                nums = condensed;
            }

            Console.WriteLine(nums[0]);
        }
    }
}
