

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MagicCombination
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int length = 10;

            for (int d1 = 0; d1 < length; d1++)
            {
                for (int d2 = 0; d2 < length; d2++)
                {
                    for (int d3 = 0; d3 < length; d3++)
                    {
                        for (int d4 = 0; d4 < length; d4++)
                        {
                            for (int d5 = 0; d5 < length; d5++)
                            {
                                for (int d6 = 0; d6 < length; d6++)
                                {
                                    if (d1*d2*d3*d4*d5*d6==n)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ",d1,d2,d3,d4,d5,d6);
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
