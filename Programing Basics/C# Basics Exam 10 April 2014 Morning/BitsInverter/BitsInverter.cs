

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitsInverter
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());

            List<int> nums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }

            int nextPos = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                while (nextPos<8)
                {
                    int mask = 1 << 7;
                    nums[i]^=mask>>nextPos;
                    nextPos += step;
                }
                nextPos -= 8;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
