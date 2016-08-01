

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitwiseOperators
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<uint> nums = new List<uint>();
            for (int i = 0; i < n; i++)
            {
                nums.Add(uint.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < nums.Count; i++)
            {
                int lastBit = 0;
                for (int j = 0; j < 32; j++)
                {
                    if ((nums[i]>>j & 1u) == 1)
                    {
                        lastBit = j;
                    }
                }
                ulong result = 0;
                int bPos=0;
                for (int j = lastBit; j >= 0; j--,bPos++)
                {
                    result |= ((nums[i]  >> j)&1u) << bPos;
                }
                Console.WriteLine(result);
            }
        }
    }
}
