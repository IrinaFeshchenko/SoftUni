

namespace ShortWordsSorted
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        static void Main()
        {
            char[] separators = ".,:;()[]\"'\\/!? ".ToCharArray();
            string[] input = Console.ReadLine().ToLower().Split(separators,StringSplitOptions.RemoveEmptyEntries);

            var result = input
                .Where(w => w.Length < 5)
                .OrderBy(x => x)
                .Distinct();

            Console.WriteLine(string.Join(", ",result));
        }
    }
}
