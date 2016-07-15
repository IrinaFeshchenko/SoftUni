

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Sunlight
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int length = 3 * n;

            Console.WriteLine("{0}*{0}", new string('.', length / 2));

            for (int i = 1; i < n; i++)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', i), new string('.', length / 2 - 1 - i));
            }

            for (int i = 0; i < n/2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));
            }

            Console.WriteLine("{0}", new string('*', length));

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));
            }

            for (int i = n-1; i >= 1; i--)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', i), new string('.', length / 2 - 1 - i));
            }

            Console.WriteLine("{0}*{0}", new string('.', length / 2));
        }
    }
}
