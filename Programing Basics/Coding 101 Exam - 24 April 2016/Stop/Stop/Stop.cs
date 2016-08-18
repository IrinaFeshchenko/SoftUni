

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Stop
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{0}", new string('.', n + 1), new string('_', n * 2 + 1));
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}//{1}\\\\{0}", new string('.', n - i), new string('_', (n * 2 - 1) + 2 * i));
            }
            Console.WriteLine("//{0}STOP!{0}\\\\", new string('_', 2 * n - 3));
            for (int i = n; i >0 ; i--)
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string('.', n - i), new string('_', (n * 2 - 1) + 2 * i));
            }
        }
    }
}
