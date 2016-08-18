

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            int maxF = 0;
            int maxL = 0;
            int max = 0;
            int first = 0;
            int last = 0;
            ulong expected = 1;

            for (int i = 0; i <  (sizeof(ulong)*8); i++)
            {
                if (((n >> i) & 1) == expected)
                {
                    first = i;
                    while ((((n >> i) & 1) == expected) && (i <  (sizeof(ulong)*8)))
                    {
                        if (expected == 1)
                        {
                            expected = 0;
                        }
                        else
                        {
                            expected = 1;
                        }

                        if (((n >> i) & 1) == 1)
                        {
                            last = i;
                        }
                        i++;
                    }
                    expected = 1;

                    if ((last-first+1)>max)
                    {
                        max = (last - first + 1);
                        maxF = first;
                        maxL = last;
                    }
                }
            }

            if (max>=3)
            {
                ulong result = 0;

                for (int i = 0, j = 0; j < (sizeof(ulong) * 8); i++, j++)
                {
                    if (j == maxF)
                    {
                        j = maxL + 1;
                    }

                    if (((n >> j) & 1) == 1)
                    {
                        result |= ((ulong)1 << i);
                    }
                    else
                    {
                        result = result & ~((ulong)1 << i);
                    }
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No waves found!");
            }
        }
    }
}
