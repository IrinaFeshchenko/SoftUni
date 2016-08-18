

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BitsUp
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

            int nextStep = 1;
            for (int i = 0; i < n; i++)
            {             
                while (nextStep < 8)
                {
                    int mask = 1 << 7;
                    nums[i] |= mask >> nextStep;
                    nextStep += step;
                }
                nextStep -= 8;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
