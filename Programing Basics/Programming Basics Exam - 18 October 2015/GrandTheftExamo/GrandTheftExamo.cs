

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GrandTheftExamo
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long slaps = 0;
            long escapes = 0;
            long beers = 0;

            for (int i = 0; i < n; i++)
            {
                long tCount = long.Parse(Console.ReadLine());
                long newBeers = long.Parse(Console.ReadLine());
                beers += newBeers;

                if (tCount<=5)
                {
                    slaps += tCount;
                }
                else
                {
                    slaps += 5;
                    escapes += tCount - 5;
                }

            }

            Console.WriteLine("{0} thieves slapped.",slaps);
            Console.WriteLine("{0} thieves escaped.",escapes);
            Console.WriteLine("{0} packs, {1} bottles.",beers/6,beers%6);
        }
    }
}
