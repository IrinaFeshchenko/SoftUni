

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Butterfly
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 2; i++)
            {
                if (i%2==0)
                {
                    Console.WriteLine("{0}\\ /{1}", new string('*', n-2), new string('*', n - 2));
                }
                else
                {
                    Console.WriteLine("{0}\\ /{1}", new string('-', n - 2), new string('-', n - 2));
                }
            }

            Console.WriteLine("{0}@{1}",new string(' ',n-1), new string(' ', n-1));

            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0}/ \\{1}", new string('*', n - 2), new string('*', n - 2));
                }
                else
                {
                    Console.WriteLine("{0}/ \\{1}", new string('-', n - 2), new string('-', n - 2));
                }
            }
        }
    }
}
