

namespace Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            long[] num = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var result = num.Where(x => x > num.Average()).OrderByDescending(x => x).Take(5);

            if (result.Count() == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
