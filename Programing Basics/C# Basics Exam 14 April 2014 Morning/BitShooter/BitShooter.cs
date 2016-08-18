

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitShooter
    {
        static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                int[] param = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

                int center = param[0];
                int width = param[1];
                int bitcount = 0;
                int bitshift = 0;

                GetValues(center, width, out bitcount, out bitshift);

                ulong mask = 0;
                for (int j = 0; j < bitshift; j++, bitcount--)
                {
                    mask <<= 1;
                    if (bitcount > 0)
                    {
                        mask |= 1;
                    }
                }
                mask = ~mask;
                num &= mask;
            }

            ulong leftCount = 0;
            for (int i = 32; i < 64; i++)
            {
                leftCount += (num >> i) & 1;
            }

            ulong rightCount = 0;
            for (int i = 0; i < 32; i++)
            {
                rightCount += (num >> i) & 1;
            }

            Console.WriteLine("left: " + leftCount);
            Console.WriteLine("right: " + rightCount);
        }
        private static void GetValues(int center, int width, out int bitcount, out int bitshift)
        {
            int mostLeftBit = center + width / 2;
            if (mostLeftBit > 64)
            {
                mostLeftBit = 64;
            }

            int mostRightBit = center - width / 2;
            if (mostRightBit < 0)
            {
                mostRightBit = 0;
            }

            bitcount = mostLeftBit - mostRightBit + 1;
            bitshift = mostLeftBit + 1;
        }
    }
}
