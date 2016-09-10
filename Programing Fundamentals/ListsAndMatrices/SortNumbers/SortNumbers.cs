

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortNumbers
    {
        static void Main()
        {
            List<decimal> nums = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            nums.Sort();
            Console.WriteLine(string.Join(" <= ",nums));
        }
    }
}
