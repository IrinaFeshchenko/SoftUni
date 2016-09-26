

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MagicWand
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int w = 3 * n + 2;
            string d0, d1, d2, d3;

            d0 = new string('.', w/2);
            Console.WriteLine("{0}*{0}", d0);

            for (int i = 1; i < n/2+2; i++)
            {
                d0 = new string('.', w/2-i);
                d1 = new string('.', (2 * i)-1);
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
            }

            d0 = new string('*', n);
            d1 = new string('.', w-2*n);
            Console.WriteLine("{0}{1}{0}", d0,d1);

            for (int i = w / 2-1; i >w/3 ; i--)
            {
                d0 = new string('.', w / 2 - i);
                d1 = new string('.', (2 * i) - 1);
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
            }

            for (int i = 1; i <= (n / 2); i++)
            {
                d0 = new string('.', n/2-i);
                d1 = new string('.', n/2);
                d2 = new string('.', i-1);
                d3 = new string('.', n);
                Console.WriteLine("{0}*{1}*{2}*{3}*{2}*{1}*{0}", d0, d1,d2,d3);
            }

            d0 = new string('*', (n+1)/2);
            d1 = new string('.', n/2);
            d2 = new string('.', n);
            Console.WriteLine("{0}{1}*{2}*{1}{0}", d0, d1,d2);

            for (int i = 0; i < n ; i++)
            {
                d0 = new string('.', n);
                Console.WriteLine("{0}*{0}*{0}", d0);
            }

            d0 = new string('.', n);
            d1 = new string('*', n);
            Console.WriteLine("{0}*{1}*{0}", d0,d1);
        }
    }
}
