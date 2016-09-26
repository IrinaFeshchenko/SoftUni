

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Dumbbell
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string d0, d1, d2, d3;

            d0 = new string('.', n/2);
            d1 = new string('&', n/2+1);
            d2 = new string('.', n);
            Console.WriteLine("{0}{1}{2}{1}{0}", d0, d1, d2);

            for (int i = 0; i < n/2-1; i++)
            {
                d0 = new string('.', n / 2-i-1);
                d1 = new string('*', n / 2+i);
                d2 = new string('.', n);
                Console.WriteLine("{0}&{1}&{2}&{1}&{0}", d0, d1, d2);
            }

            d0 = new string('*', n - 2);
            d1 = new string('=', n );
            Console.WriteLine("&{0}&{1}&{0}&", d0, d1, d2);

            for (int i = n / 2-2; i >=0; i--)
            {
                d0 = new string('.', n / 2 - i - 1);
                d1 = new string('*', n / 2 + i);
                d2 = new string('.', n);
                Console.WriteLine("{0}&{1}&{2}&{1}&{0}", d0, d1, d2);
            }

            d0 = new string('.', n / 2);
            d1 = new string('&', n / 2 + 1);
            d2 = new string('.', n);
            Console.WriteLine("{0}{1}{2}{1}{0}", d0, d1, d2);
        }
    }
}
