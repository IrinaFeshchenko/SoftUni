

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DrawFort
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("/{0}\\{1}/{2}\\", new string('^', n / 2), new string('_',2*n-(n/2+n/2+4)), new string('^', n / 2));
            for (int i = 0; i < n-3; i++)
            {
                Console.WriteLine("|{0}|", new string(' ',(2*n)-2));
            }
            Console.WriteLine("|{0} {1} {2}|", new string(' ', n / 2), new string('_', 2 * n - (n / 2 + n / 2 + 4)), new string(' ', n / 2));
            Console.WriteLine("\\{0}/{1}\\{2}/", new string('_', n / 2), new string(' ', 2 * n - (n / 2 + n / 2 + 4)), new string('_', n / 2));
        }
    }
}
