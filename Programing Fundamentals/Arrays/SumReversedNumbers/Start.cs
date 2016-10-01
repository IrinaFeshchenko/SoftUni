

namespace SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> nums = Console.ReadLine().Split().ToList();

            var sum = nums.Select(x => int.Parse(string.Join("",x.Reverse()))).Sum();

            Console.WriteLine(sum);
        }
    }
}
