

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitSwapper
    {
        static void Main()
        {
            ulong[] n = new ulong[4];
            n[0] = ulong.Parse(Console.ReadLine());
            n[1] = ulong.Parse(Console.ReadLine());
            n[2] = ulong.Parse(Console.ReadLine());
            n[3] = ulong.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()).Trim() != "End")
            {
                int[] param1 = command.Split().Select(int.Parse).ToArray();
                int num1 = param1[0];
                int pos1 = param1[1];

                int[] param2 = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                int num2 = param2[0];
                int pos2 = param2[1];

                // mask of the positions of the two groups to swap
                ulong fromMask = 15u << pos1 * 4;
                ulong toMask = 15u << pos2 * 4;
                // copy the groups from the numbers
                ulong fromBits = (n[num1] & fromMask) >> pos1 * 4;
                ulong toBits = (n[num2] & toMask) >> pos2 * 4;
                // zeroing the two groups in the numbers
                n[num1] &= ~fromMask;
                n[num2] &= ~toMask;
                // swap paste the two groups in the numbers
                n[num1] |= toBits << pos1*4;
                n[num2] |= fromBits << pos2*4;
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(n[i]);
            }
        }
    }
}
