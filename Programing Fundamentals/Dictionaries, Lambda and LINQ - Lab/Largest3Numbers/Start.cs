

namespace Largest3Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var result = nums.OrderByDescending(x => x).Take(3);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
