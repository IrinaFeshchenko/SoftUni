

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AppendLists
    {
        static void Main()
        {
            List<string> line = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> result = new List<string>();
            line.Reverse();
            foreach (var chunk in line)
            {
                result.AddRange(chunk.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
