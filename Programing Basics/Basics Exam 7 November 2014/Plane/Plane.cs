

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Plane
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string d0, d1, d2, d3;
            int d0Width, d1Width, d2Width, d3Width;

            d0Width = 3*n/2;
            d1Width = 1;
            d0 = new string('.', d0Width);
            d1 = new string('*', d1Width);
            Console.WriteLine("{0}{1}{0}", d0, d1);

            d0Width = 3*n/2 - 1;
            d1Width = 1;
            while (d0Width >= n-2)
            {
                d0 = new string('.', d0Width);
                d1 = new string('.', d1Width);
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
                d0Width -= 1;
                d1Width += 2;
            }

            d0Width = n-4;
            d1Width = 3*n-2*(n-3);
            while (d0Width >= 1)
            {
                d0 = new string('.', d0Width);
                d1 = new string('.', d1Width);
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
                d0Width -= 2;
                d1Width += 4;
            }

            d0Width = n - 2;
            d1Width = n;
            d0 = new string('.', d0Width);
            d1 = new string('.', d1Width);
            Console.WriteLine("*{0}*{1}*{0}*", d0, d1);

            d0Width = n - 4;
            d1Width = 1;
            d2Width = n;
            while (d0Width >= 1)
            {
                d0 = new string('.', d0Width);
                d1 = new string('.', d1Width);
                d2 = new string('.', d2Width);
                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", d0, d1, d2);
                d0Width -= 2;
                d1Width += 2;
            }

            d0Width = n - 1;
            d1Width = n;
            while (d0Width >= 1)
            {
                d0 = new string('.', d0Width);
                d1 = new string('.', d1Width);
                Console.WriteLine("{0}*{1}*{0}", d0, d1);
                d0Width -= 1;
                d1Width += 2;
            }

            d0Width = 3 * n;
            d0 = new string('*', d0Width);
            Console.WriteLine("{0}", d0);
        }
    }
}
