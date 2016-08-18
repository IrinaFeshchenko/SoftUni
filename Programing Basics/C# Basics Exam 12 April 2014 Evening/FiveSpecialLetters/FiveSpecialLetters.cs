

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            bool found = false;
            char[] c = "abcde".ToCharArray();
            int[] w = { 5, -12, 47, 7, -32 };

            for (int d1 = 0; d1 < 5; d1++)
            {
                for (int d2 = 0; d2 < 5; d2++)
                {
                    for (int d3 = 0; d3 < 5; d3++)
                    {
                        for (int d4 = 0; d4 < 5; d4++)
                        {
                            for (int d5 = 0; d5 < 5; d5++)
                            {
                                HashSet<int> hs= new HashSet<int>{d1,d2,d3,d4,d5};

                                int weight = 0;
                                int i = 1;
                                foreach (var num in hs)
                                {
                                    weight += i * w[num];
                                    i++;
                                }

                                if (weight>=start&&weight<=end)
                                {
                                    Console.Write("{0}{1}{2}{3}{4} ",c[d1], c[d2], c[d3], c[d4], c[d5]);
                                    found = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}
