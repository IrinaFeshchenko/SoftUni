

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitRoller
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());

            for (int i = 0; i < r; i++)
            {
                int frozenBit = (n >> f) & 1;
                int rollOverBit = n & 1;
                int previousBit = (n >> f + 1) & 1;

                if (f == 18)
                {
                    n ^= frozenBit << 18;
                    n |= rollOverBit << 18;
                    n >>= 1;
                    n |= frozenBit << 18;
                }
                else
                {
                    if (f == 0)
                    {
                        rollOverBit = (n>>1) & 1;
                    }
                    n ^= previousBit << f + 1;
                    n ^= frozenBit << f;

                    n |= previousBit << f;
                    n |= frozenBit << f + 1;

                    n >>= 1;
                    n |= rollOverBit << 18;
                }
            }
            Console.WriteLine(n);
        }
    }
}
