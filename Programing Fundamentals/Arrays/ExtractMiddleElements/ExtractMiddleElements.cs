

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExtractMiddleElements
    {
        static void Main()
        {
            List<int> num = Console.ReadLine().Split().Select(int.Parse).ToList();

            int len = num.Count;
            if (len == 1)
            {
                Console.WriteLine($"{{ {num[0]} }}");
            }
            else if (len % 2 == 0)
            {
                Console.WriteLine($"{{ {num[len/2-1]}, {num[len/2]} }}");
            }
            else
            {
                Console.WriteLine($"{{ {num[len/2-1]}, {num[len/2]}, {num[len/2+1]} }}");
            }
        }
    }
}
