


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FoldAndSum
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int len = nums.Count;
            int k = len / 4;
            var left = nums.Take(k).Reverse();
            var right = nums.Skip(3 * k).Take(k).Reverse();
            var arr1 = left.Concat(right);
            var arr2 = nums.Skip(k).Take(2 * k).ToArray();
            var result = arr1.Select((x, y) => x + arr2[y]);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
