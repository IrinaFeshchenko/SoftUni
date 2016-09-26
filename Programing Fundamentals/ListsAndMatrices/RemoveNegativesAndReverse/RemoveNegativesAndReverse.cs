

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveNegativesAndReverse
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            nums.RemoveAll(x => x < 0);
            nums.Reverse();
            Console.WriteLine(nums.Count > 0 ? string.Join(" ", nums) : "empty");
        }
    }
}
