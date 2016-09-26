


namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Boat
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string d0, d1, d2, d3;

            for (int i = 1; i < (n / 2)+2; i++)
            {
                d0 = new string('.', n - (i*2-1));
                d1 = new string('*', (i * 2 - 1));
                d2 = new string('.', n);
                Console.WriteLine("{0}{1}{2}", d0, d1, d2);
            }

            for (int i = (n / 2); i >= 1; i--)
            {
                d0 = new string('.', n - (i * 2 - 1));
                d1 = new string('*', (i * 2 - 1));
                d2 = new string('.', n);
                Console.WriteLine("{0}{1}{2}", d0, d1, d2);
            }

            for (int i = 0; i < (n / 2); i++)
            {
                d0 = new string('.', i);
                d1 = new string('*', (n-i)*2);
                Console.WriteLine("{0}{1}{0}", d0, d1);
            }
        }
    }
}
