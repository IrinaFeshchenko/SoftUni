

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Tables
    {
        static void Main()
        {
            long b1 = long.Parse(Console.ReadLine());
            long b2 = long.Parse(Console.ReadLine());
            long b3 = long.Parse(Console.ReadLine());
            long b4 = long.Parse(Console.ReadLine());
            long tops = long.Parse(Console.ReadLine());
            long n = long.Parse(Console.ReadLine());

            long legs = b1 + b2 * 2 + b3 * 3 + b4 * 4;

            long topsNeeded = n;
            long legsNeeded = n * 4;

            long canBeMade = Math.Min(legs/4,tops);

            if (canBeMade > n)
            {
                Console.WriteLine("more: {0}",canBeMade-n);
                Console.WriteLine("tops left: {0}, legs left: {1}",tops-topsNeeded, legs-legsNeeded);
            }
            else if (n > canBeMade)
            {
                Console.WriteLine("less: {0}",  canBeMade - n);
                Console.WriteLine("tops needed: {0}, legs needed: {1}",  topsNeeded-tops >= 0 ?  topsNeeded - tops: 0,  legsNeeded - legs >= 0 ?  legsNeeded - legs : 0);
            }
            else
            {
                Console.WriteLine("Just enough tables made: {0}",n);
            }
        }
    }
}
