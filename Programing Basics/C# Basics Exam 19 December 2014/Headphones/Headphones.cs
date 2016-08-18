

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Headphones
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string d0, d1, d2, d3;
            int d0Width, d1Width, d2Width, d3Width;

            d0 = new string('-', n/2);
            d1 = new string('*', n+2);
            Console.WriteLine("{0}{1}{0}", d0,d1);

            for (int i = 1; i < n ; i++)
            {
                d0 = new string('-', n / 2);
                d1 = new string('-', n );
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
            }

            d0Width = n/2;
            d1Width = 1;
            d2Width = n;
            while (d1Width<=n)
            {
                d0 = new string('-', d0Width);
                d1 = new string('*', d1Width);
                d2 = new string('-', d2Width);
                Console.WriteLine("{0}{1}{2}{1}{0}", d0, d1,d2);
                d0Width -= 1;
                d1Width += 2;
                d2Width -= 2;
            }

            d0Width = 1;
            d1Width = n-2;
            d2Width = 3;
            while (d1Width > 0)
            {
                d0 = new string('-', d0Width);
                d1 = new string('*', d1Width);
                d2 = new string('-', d2Width);
                Console.WriteLine("{0}{1}{2}{1}{0}", d0, d1, d2);
                d0Width += 1;
                d1Width -= 2;
                d2Width += 2;
            }
        }
    }
}
