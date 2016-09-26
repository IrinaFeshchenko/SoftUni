

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class five
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string d0, d1, d2, d3;
            int d0Width, d1Width, d2Width, d3Width;

            d0Width = 3*n;
            d1Width = 2;
            d2Width = (2 * n) - 2;
            d0 = new string('-', d0Width);
            d1 = new string('*', d1Width);
            d2 = new string('-', d2Width );
            Console.WriteLine("{0}{1}{2}", d0, d1,d2);

            d0Width = 3 * n;
            d1Width = 1;
            d2Width = 1;
            d3Width = 2 * n - 3;
            for (int i = 0; i < n-1; i++)
            {
                d0 = new string('-', d0Width);
                d1 = new string('*', d1Width);
                d2 = new string('-', d2Width);
                d3 = new string('-', d3Width);
                Console.WriteLine($"{d0}{d1}{d2}{d1}{d3}");
                d2Width += 1;
                d3Width -= 1;
            }

            d0Width = (3 * n)+1;
            d1Width = n-1;
            d2Width = 1;
            d3Width = n - 1;
            for (int i = 0; i < n /2; i++)
            {
                d0 = new string('*', d0Width);
                d1 = new string('-', d1Width);
                d2 = new string('*', d2Width);
                d3 = new string('-', d3Width);
                Console.WriteLine($"{d0}{d1}{d2}{d3}");
            }

            d0Width = 3 * n;
            d1Width = 1;
            d2Width = n-1;
            d3Width = n - 1;
            for (int i = 0; i < (n/2) - 1; i++)
            {
                d0 = new string('-', d0Width);
                d1 = new string('*', d1Width);
                d2 = new string('-', d2Width);
                d3 = new string('-', d3Width);
                Console.WriteLine($"{d0}{d1}{d2}{d1}{d3}");
                d0Width -= 1;
                d2Width += 2;
                d3Width -= 1;
            }

            d0Width = (3*n) - (n/2)+1;
            d2Width = n - (n / 2);
            d1Width = (5 * n) - d0Width - d2Width;
            d0 = new string('-', d0Width);
            d1 = new string('*', d1Width);
            d2 = new string('-', d2Width);
            Console.WriteLine("{0}{1}{2}", d0, d1, d2);
        }
    }
}
