

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilledSquare
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeader(n);
            for (int i = 0; i < n-2; i++)
            {
                PrintMiddle(n);
            }
            if (n>1)
            {
                PrintHeader(n);
            }
        }

        private static void PrintHeader(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }

        private static void PrintMiddle(int n)
        {
            Console.WriteLine("-" + string.Join("", Enumerable.Repeat("\\/", n-1)) + "-");
        }
    }
}
