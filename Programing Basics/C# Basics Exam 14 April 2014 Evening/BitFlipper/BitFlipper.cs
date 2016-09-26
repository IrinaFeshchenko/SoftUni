

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitFlipper
    {
        static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());

            int count = 0;
            ulong lastBit = 0;
            for (int i = 63; i >= 0; i--)
            {
                ulong currentBit = (num >> i) & 1;

                if (count == 0)
                {
                    lastBit = currentBit;
                    count++;
                }
                else
                {
                    if (currentBit == lastBit)
                    {
                        count++;
                    }
                    else
                    {
                        lastBit = currentBit;
                        count = 1;                      
                    }

                    if (count == 3)
                    {
                        num ^= (7ul << i);
                        count = 0;
                    }
                }
            }

            Console.WriteLine(num);
        }
    }
}
