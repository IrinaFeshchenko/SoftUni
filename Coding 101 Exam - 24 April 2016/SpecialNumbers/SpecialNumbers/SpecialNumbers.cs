

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SpecialNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int n = 10;
            for (int d1 = 1; d1 < n; d1++)
            {
                if (number%d1==0)
                {
                    for (int d2 = 1; d2 < n; d2++)
                    {
                        if (number % d2 == 0)
                        {
                            for (int d3 = 1; d3 < n; d3++)
                            {
                                if (number % d3 == 0)
                                {
                                    for (int d4 = 1; d4 < n; d4++)
                                    {
                                        if (number % d4 == 0)
                                        {
                                            Console.Write($"{d1}{d2}{d3}{d4} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
