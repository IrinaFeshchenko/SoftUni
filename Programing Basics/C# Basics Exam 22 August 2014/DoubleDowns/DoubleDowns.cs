

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DoubleDowns
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<ulong> nums = new List<ulong>();

            for (int i = 0; i < n; i++)
            {
                nums.Add( ulong.Parse(Console.ReadLine()));
            }

            int count = 0;
            //left
            for (int i = 0; i < nums.Count - 1; i++)
            {
                for (int j = 1; j < 31; j++)
                {
                    ulong bit1 = nums[i] >> j & 1ul;
                    ulong bit2 = nums[i + 1] >> j - 1 & 1ul;
                    if ((bit1 == 1) && (bit2 == 1))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

            count = 0;
            //right
            for (int i = 0; i < nums.Count - 1; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    ulong bit1 = nums[i] >> j & 1ul;
                    ulong bit2 = nums[i + 1] >> j+1 & 1ul;
                    if ((bit1 == 1) && (bit2 == 1))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

            count = 0;
            //vertical
            for (int i = 0; i < nums.Count - 1; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    ulong bit1 = nums[i] >> j & 1ul;
                    ulong bit2 = nums[i + 1] >> j & 1ul;
                    if ((bit1 == 1) && (bit2 == 1))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
