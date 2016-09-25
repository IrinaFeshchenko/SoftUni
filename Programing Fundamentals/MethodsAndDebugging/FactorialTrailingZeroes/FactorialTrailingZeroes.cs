namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Diagnostics;
    using System.Net;

    class FactorialTrailingZeroes
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int count = CountTrailingZeroes(number);
            Console.WriteLine(count);
        }

        public static int CountTrailingZeroes(int n)
        {
            if (n < 0)
                return -1;

            int count = 0;
            for (int i = 5; n / i >= 1; i *= 5)
            {
                count += n / i;
            }

            return count;
        }
    }
}
