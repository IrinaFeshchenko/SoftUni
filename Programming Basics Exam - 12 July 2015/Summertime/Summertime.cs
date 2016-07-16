

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Summertime
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{0}", new string(' ', n / 2), new string('*', n + 1));
            for (int i = 0; i < (n/2); i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string(' ', n / 2), new string(' ', n - 1));
            }
            for (int i = 0; i < (n / 2); i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string(' ', (n / 2)-i), new string(' ', (n - 1)+(2*i)));
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("*{0}*", new string('.', (n-1)*2));
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("*{0}*", new string('@', (n - 1) * 2));
            }
            Console.WriteLine(new string('*', n* 2));
        }
    }
}
