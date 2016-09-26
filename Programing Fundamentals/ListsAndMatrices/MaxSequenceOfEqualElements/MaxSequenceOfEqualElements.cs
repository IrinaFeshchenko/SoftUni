

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var r1 = nums.GroupBy(x => x).Select(y=> new {key = y.Key, count = y.Count()}).ToList();
            var r2 = r1.OrderByDescending(group => group.count).FirstOrDefault();

           for (int i = 0; i < r2.count; i++)
           {
               Console.Write($"{r2.key} ");
           }             
        }
    }
}
