

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WiggleWiggle
    {
        static void Main()
        {
            ulong[] nums = Console.ReadLine()
                            .Split()
                            .Select(ulong.Parse)
                            .ToArray();

            ulong num1 = 0, num2 = 0, currentBit = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                for (int j = 0; j < 64; j += 2)
                {
                    currentBit = nums[i + 1] & (1UL << j);
                    currentBit ^= (1UL << j);
                    num1 |= currentBit;
          
                    currentBit = nums[i] & (1UL << j);
                    currentBit ^= (1UL << j);
                    num2 |= currentBit;

                    if (j<62)
                    {
                        currentBit = nums[i] & (1UL << j + 1);
                        currentBit ^= (1UL << j + 1);
                        num1 |= currentBit;

                        currentBit = nums[i + 1] & (1UL << j + 1);
                        currentBit ^= (1UL << j + 1);
                        num2 |= currentBit;
                    }
                }

                nums[i] = num1;
                nums[i + 1] = num2;
                num1 = 0;
                num2 = 0;
                currentBit = 0;
            }

            foreach (var num in nums)
            {
                Console.Write("{0} ",num);
                for (int i = (63 - 1); i >= 0; i--)
                {
                    Console.Write((num >> i) & 1);
                }
                Console.WriteLine();
            }
        }
    }
}
