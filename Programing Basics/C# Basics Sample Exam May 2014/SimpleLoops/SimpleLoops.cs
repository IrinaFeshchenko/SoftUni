

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class SimpleLoops
    {
        static void Main()
        {
            BigInteger[] nums = new BigInteger[3];
            nums[0] = BigInteger.Parse(Console.ReadLine());
            nums[1] = BigInteger.Parse(Console.ReadLine());
            nums[2] = BigInteger.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 3; i < n; i++)
            {
                nums[i%3]=nums[(i-1)%3]+ nums[(i - 2) % 3]+ nums[(i - 3) % 3];
            }
            Console.WriteLine(nums[(n - 1) % 3]);
        }
    }
}
