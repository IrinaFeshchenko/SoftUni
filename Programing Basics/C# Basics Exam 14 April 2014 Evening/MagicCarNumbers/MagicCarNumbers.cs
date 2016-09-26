

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MagicCarNumbers
    {
        static void Main()
        {
            int magicWeight = int.Parse(Console.ReadLine());

            int[] w = new int[] { 10, 20, 30, 50, 80, 110, 130, 160, 200, 240 };
            char[] c = new char[] { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

            int count = 0;
            for (int d1 = 0; d1 < 10; d1++)
            {
                for (int d2 = 0; d2 < 10; d2++)
                {
                    for (int d3 = 0; d3 < 10; d3++)
                    {
                        for (int d4 = 0; d4 < 10; d4++)
                        {
                            for (int c1 = 0; c1 < 10; c1++)
                            {
                                for (int c2 = 0; c2 < 10; c2++)
                                {
                                    int weight = 30 + 10 + d1 + d2 + d3 + d4 + w[c1] + w[c2];
                                    if (weight == magicWeight)
                                    {
                                        if ((d1 == d2 && d2 == d3 && d3 == d4) ||
                                            (d1 != d2 && d2 == d3 && d3 == d4) ||
                                            (d1 == d2 && d2 == d3 && d3 != d4) ||
                                            (d1 == d2 && d2 != d3 && d3 == d4) ||
                                            (d1 == d3 && d2 == d4 && d1 != d2) ||
                                            (d1 == d4 && d2 == d3 && d1 != d2))
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
