

namespace OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        static void Main()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            string[] args = Console.ReadLine().ToLower().Split();

            var result = args.GroupBy(x => x)
                .Select(g => new { key = g.Key, count = g.Count() })
                .Where(y => y.count % 2 != 0)
                .Select(x=>x.key);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
