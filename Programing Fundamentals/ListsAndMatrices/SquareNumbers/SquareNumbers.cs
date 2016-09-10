

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SquareNumbers
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {

                if (Math.Sqrt(nums[i]) == (int)Math.Sqrt(nums[i]))
                {
                    result.Add(nums[i]);
                }
            }

            result.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
